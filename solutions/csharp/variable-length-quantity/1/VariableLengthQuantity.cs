using System;
using System.Collections.Generic;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var result = new List<uint>();

        foreach (var number in numbers)
        {
            if (number == 0)
            {
                result.Add(0);
                continue;
            }

            var stack = new Stack<uint>();
            uint n = number;

            // Break number into 7-bit chunks
            while (n > 0)
            {
                stack.Push(n & 0x7F); 
                n >>= 7;
            }

            // Add chunks to result
            while (stack.Count > 0)
            {
                var b = stack.Pop();
                if (stack.Count > 0) // not last chunk
                    b |= 0x80;
                result.Add(b);
            }
        }

        return result.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        var result = new List<uint>();
        uint value = 0;

        foreach (var b in bytes)
        {
            value = (value << 7) | (b & 0x7F);

            if ((b & 0x80) == 0) // last byte
            {
                result.Add(value);
                value = 0;
            }
        }

        // If last value wasn't terminated properly
        if ((bytes.Length > 0) && ((bytes[^1] & 0x80) != 0))
            throw new InvalidOperationException("Incomplete VLQ sequence.");

        return result.ToArray();
    }
}
