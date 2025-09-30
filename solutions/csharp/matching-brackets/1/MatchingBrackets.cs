public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Stack<char> xCharStack = new Stack<char>();
        char xOpeningChar = 'A';
        foreach(char iChar in input){
            if(iChar == '[' || iChar == '{' || iChar == '('){
                xCharStack.Push(iChar);
            }
            else if(iChar == ']' || iChar == '}' || iChar == ')'){
                if(xCharStack.Count == 0){
                    return false;
                }
                 xOpeningChar = xCharStack.Pop();
                if (!(xOpeningChar == '(' && iChar == ')') && !(xOpeningChar == '[' && iChar == ']') && !(xOpeningChar == '{' && iChar == '}'))
                {
                    return false;
                }
            }
        }
        return xCharStack.Count == 0;
    }
        
}
