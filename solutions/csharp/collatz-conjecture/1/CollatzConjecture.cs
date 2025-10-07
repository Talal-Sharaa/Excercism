public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int xStep = 0;
        int xNumber = number;
         if (number < 1)
            throw new ArgumentOutOfRangeException("Number must be positive and greater than zero.");
        if (number == 1)
            return 0;
        do{
            if(xNumber%2 == 0){
                xNumber = xNumber/2;
                xStep++;
            }
            else{
                xNumber = 3*xNumber + 1;
                xStep++;
            }
        }while(xNumber != 1);
        return xStep;
    }
}