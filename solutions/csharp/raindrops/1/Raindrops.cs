public static class Raindrops
{
    public static string Convert(int number)
    {
        string xRainDropSound = "";
        if(number%3 !=0 && number%5 !=0 && number%7 !=0)
            return number.ToString();
        if(number%3 ==0)
        {
            xRainDropSound += "Pling";
        }
        if(number%5 ==0)
        {
            xRainDropSound += "Plang";
        }
        if(number%7 ==0)
        {
            xRainDropSound += "Plong";
        }
        return xRainDropSound;
    }
}