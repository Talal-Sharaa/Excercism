public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        long xNumber = number;
        List<long> xFactors = new List<long>();
            while(xNumber % 2 == 0){
                xFactors.Add(2);
                xNumber /= 2;
            }
            for(int i = 3; i * i <= xNumber; i+=2){
                
            while(xNumber % i == 0){
            xFactors.Add(i);
                xNumber /= i;
            }
            }
        if(xNumber>1){
            xFactors.Add(xNumber);
        }
        return xFactors.ToArray();
    }
}