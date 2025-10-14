public static class Darts
{
    public static int Score(double x, double y)
    {
        double xDistance = Math.Sqrt((x*x) + (y*y));
        if(xDistance<=1){
            return 10;
        }
        else if(xDistance<=5){
            return 5;
        }
        else if(xDistance<=10){
            return 1;
        }
        return 0;
    }
}
