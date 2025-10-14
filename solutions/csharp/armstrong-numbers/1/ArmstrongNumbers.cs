public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string xNumberString  = number.ToString().TrimStart(new char[] { '0' }).Trim();
        int xSum = 0;
        foreach(char iDigit in xNumberString){
            int xDigit = iDigit - '0';
            xSum += (int)Math.Pow(xDigit, xNumberString.Length);
        }
        return xSum == number;
    }
}