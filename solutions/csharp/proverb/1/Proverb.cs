public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] xResult = new string[subjects.Length];
        if(xResult.Length>0){
            for(int i = 0; i<subjects.Length-1; i++){
                xResult[i] = $"For want of a {subjects[i]} the {subjects[i+1]} was lost.";
            }
            xResult[subjects.Length-1] = $"And all for the want of a {subjects[0]}.";
        }
        return xResult;
    }
}