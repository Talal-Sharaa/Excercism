public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        if(max<=0){
            throw new ArgumentOutOfRangeException("Number must be a natural number");
        }
        return (int)Math.Pow((max*(max+1))/2, 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        if(max<=0){
            throw new ArgumentOutOfRangeException("Number must be a natural number");
        }
         return (max*(max+1)*(2*max+1)) / 6;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}