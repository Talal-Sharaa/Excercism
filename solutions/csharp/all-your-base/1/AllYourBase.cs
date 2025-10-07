public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1 || outputBase <= 1)
        {
            throw new ArgumentException("Both input and output bases must be greater than 1");
        }


        if(inputDigits.Any(i => i>inputBase-1) || inputDigits.Any(i => i<0)){
            throw new ArgumentException("input Array not valid");
        }
        if (inputDigits == null || inputDigits.Length == 0)
        {
            return new int[]{0};
        }
        if (inputBase == outputBase)
        {
            return inputDigits;
        }

        int xDecimalNumber = 0;
        for (int i = 0; i < inputDigits.Length; i++)
        {
            xDecimalNumber += inputDigits[inputDigits.Length - 1 - i] * (int)Math.Pow(inputBase, i);
        }

        List<int> xLstNumberDigits = new List<int>();
        if (xDecimalNumber == 0)
        {
            xLstNumberDigits.Add(0);
        }
        else
        {
            while (xDecimalNumber > 0)
            {
                xLstNumberDigits.Insert(0, xDecimalNumber % outputBase);
                xDecimalNumber /= outputBase;
            }
        }

        return xLstNumberDigits.ToArray();
    }
}
