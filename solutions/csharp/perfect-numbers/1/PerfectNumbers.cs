public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        List<int> xLstDivisors = new List<int>();
        int xAliquotSum = 0;
        if(number<=0){
            throw new ArgumentOutOfRangeException("You should enter a positive integer only");
        }
        for(int i = 1; i<=number/2; i++){
            if(number%i == 0){
                xLstDivisors.Add(i);
            }
        }
        foreach(int iDivisor in xLstDivisors){
            xAliquotSum+=iDivisor;
        }
        if(xAliquotSum == number){
            return Classification.Perfect;
        }
        else if(xAliquotSum>number){
            return Classification.Abundant;
        }
        else{
            return Classification.Deficient;
        }
    }
}
