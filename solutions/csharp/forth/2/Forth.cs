using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        var stack = new Stack<int>();
        
        // User-defined words (case-insensitive); each maps to the *expanded* token list
        var words = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        // Turn all input into a single token stream (case-insensitive)
        var input = new LinkedList<string>(Tokenize(instructions));

        while (input.First is not null)
        {
            var token = PopFirst(input);

            if (token == ":")
            {
                DefineWord(input, words);
                continue;
            }

            if (IsNumber(token))
            {
                stack.Push(ParseNumber(token));
                continue;
            }

            // If user-defined, inline-expand its body at the front of the stream
            if (words.TryGetValue(token, out var body))
            {
                // prepend in reverse order so first token of body is processed next
                for (int i = body.Count - 1; i >= 0; i--)
                    input.AddFirst(body[i]);
                continue;
            }

            // Built-ins
            switch (token)
            {
                case "+":
                    Require(stack, 2);
                    { var b = stack.Pop(); var a = stack.Pop(); checked { stack.Push(a + b); } }
                    break;
                case "-":
                    Require(stack, 2);
                    { var b = stack.Pop(); var a = stack.Pop(); checked { stack.Push(a - b); } }
                    break;
                case "*":
                    Require(stack, 2);
                    { var b = stack.Pop(); var a = stack.Pop(); checked { stack.Push(a * b); } }
                    break;
                case "/":
                    Require(stack, 2);
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        if (b == 0) throw new DivideByZeroException();
                        // C# integer division truncates toward zero
                        stack.Push(a / b);
                    }
                    break;

                case "DUP":
                    Require(stack, 1);
                    { var a = stack.Peek(); stack.Push(a); }
                    break;

                case "DROP":
                    Require(stack, 1);
                    stack.Pop();
                    break;

                case "SWAP":
                    Require(stack, 2);
                    { var b = stack.Pop(); var a = stack.Pop(); stack.Push(b); stack.Push(a); }
                    break;

                case "OVER":
                    Require(stack, 2);
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(a);
                        stack.Push(b);
                        stack.Push(a);
                    }
                    break;

                default:
                    throw new InvalidOperationException("Unknown word");
            }
        }

        // Return stack from bottom to top as space-separated numbers
        return string.Join(" ", stack.Reverse());
    }

    // ------- helpers -------

    private static IEnumerable<string> Tokenize(string[] lines)
    {
        foreach (var line in lines ?? Array.Empty<string>())
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            foreach (var t in line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
                yield return t.ToUpperInvariant();
        }
    }

    private static void DefineWord(LinkedList<string> input, Dictionary<string, List<string>> words)
    {
        if (input.First is null) throw new InvalidOperationException("Invalid definition");

        var name = PopFirst(input);
        if (IsNumber(name)) throw new InvalidOperationException("Invalid definition"); // cannot redefine a number

        var body = new List<string>();
        bool terminated = false;

        // Collect tokens until ';' and *expand* any already-defined words now
        while (input.First is not null)
        {
            var tok = PopFirst(input);
            if (tok == ";")
            {
                terminated = true;
                break;
            }

            if (words.TryGetValue(tok, out var existing))
            {
                // inline-expand into definition (snapshot current meaning)
                body.AddRange(existing);
            }
            else
            {
                body.Add(tok);
            }
        }

        if (!terminated) throw new InvalidOperationException("Invalid definition");

        // Overwrite/define (can override built-ins and previous defs)
        words[name] = body;
    }

    private static string PopFirst(LinkedList<string> list)
    {
        var v = list.First!.Value;
        list.RemoveFirst();
        return v;
    }

    private static bool IsNumber(string token)
{
    if (string.IsNullOrEmpty(token)) return false;

    // Allow an optional leading +/-
    int start = (token[0] == '-' || token[0] == '+') ? 1 : 0;
    if (start == token.Length) return false; // sign only is not a number

    for (int i = start; i < token.Length; i++)
        if (token[i] < '0' || token[i] > '9')
            return false;

    return true;
}

private static int ParseNumber(string token) => int.Parse(token, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);

    private static void Require(Stack<int> stack, int need)
    {
        if (stack.Count < need) throw new InvalidOperationException("Stack empty");
    }
}
