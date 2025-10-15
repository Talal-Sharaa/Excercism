using System.Collections.Generic;

public static class BottleSong
{
    private static Dictionary<int, string> xNumbersToString = new Dictionary<int, string>(){
        [0] = "no",
        [1] = "One",
        [2] = "Two", 
        [3] = "Three", 
        [4] = "Four",
        [5] = "Five",
        [6] = "Six",
        [7] = "Seven",
        [8] = "Eight",
        [9] = "Nine",
        [10] = "Ten"
    };
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> xSong = new List<string>();
        int i = 0;
        for(i = startBottles; i>(startBottles - takeDown); i--){
            string xOriginalBottlesGrammaticalNumber = i == 1? "bottle": "bottles";
            for(int j = 1; j<=2; j++){
                xSong.Add($"{xNumbersToString[i]} green {xOriginalBottlesGrammaticalNumber} hanging on the wall,");
            }
            string xNextBottlesGrammaticalNumber = i == 2? "bottle": "bottles";
            xSong.Add("And if one green bottle should accidentally fall,");
            xSong.Add($"There'll be {xNumbersToString[i-1].ToLower()} green {xNextBottlesGrammaticalNumber} hanging on the wall.");
        if (i > (startBottles - takeDown + 1))
        {
            xSong.Add("");
        }
        }
        return xSong;
    }
}
