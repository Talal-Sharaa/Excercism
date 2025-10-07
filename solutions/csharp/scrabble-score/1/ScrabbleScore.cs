public static class ScrabbleScore
{
    public static int Score(string input)
    {
        int xScore = 0;
        if(string.IsNullOrEmpty(input)){
            return xScore;
        }
        input = input.ToUpper();
        foreach(char iLetter in input){
            if(iLetter == 'A' || iLetter == 'E' || iLetter == 'I' || iLetter == 'O' || iLetter == 'U' || iLetter == 'L' || iLetter == 'N' || iLetter == 'R' || iLetter == 'S' || iLetter == 'T'){
                xScore++;
            }
            else if(iLetter == 'D' || iLetter == 'G' ){
                xScore +=2;
            }
            else if(iLetter == 'B' || iLetter == 'C' || iLetter == 'M' || iLetter == 'P'){
                xScore +=3;
            }
            else if(iLetter == 'F' || iLetter == 'H' || iLetter == 'V' || iLetter == 'W' || iLetter == 'Y'){
                xScore +=4;
            }
            else if(iLetter == 'K'){
                xScore +=5;
            }
            else if(iLetter == 'J' || iLetter == 'X' ){
                xScore +=8;
            }
            else if(iLetter == 'Q' || iLetter == 'Z' ){
                xScore +=10;
            }
        }
        return xScore;
    }
}