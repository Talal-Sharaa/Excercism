using System;

public static class Pangram
{
    private static char[] _Alphabet = new char[] {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    };
    public static bool IsPangram(string input)
    {
        foreach(char iLetter in _Alphabet){
            if(!input.ToLower().Contains(iLetter)){
                return false;
            }
        }
        return true;
    }
}
