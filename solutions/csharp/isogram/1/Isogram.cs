public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if(String.IsNullOrEmpty(word)){
            return true;
        }
        for(char xLetter = 'a'; xLetter<='z'; xLetter++){
            if(word.ToLower().Count(ch => ch == xLetter)>1){
                return false;
            }
        }
        return true;
    }
}
