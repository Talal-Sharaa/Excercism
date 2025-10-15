public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, (double)r._Numerator / r._Denominator);
    }
}

public struct RationalNumber
{
    public int _Numerator;
    public int _Denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException("Can't Divide By Zero");

        _Numerator = numerator;
        _Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1._Numerator * r2._Denominator + r2._Numerator * r1._Denominator;
        int denominator = r1._Denominator * r2._Denominator;
        return new RationalNumber(numerator, denominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1._Numerator * r2._Denominator - r2._Numerator * r1._Denominator;
        int denominator = r1._Denominator * r2._Denominator;
        return new RationalNumber(numerator, denominator).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._Numerator * r2._Numerator, r1._Denominator * r2._Denominator).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        if (r2._Numerator == 0)
            throw new DivideByZeroException("Can't Divide By Zero");

        return new RationalNumber(r1._Numerator * r2._Denominator, r2._Numerator * r1._Denominator).Reduce();
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(_Numerator), Math.Abs(_Denominator)).Reduce();
    }

public RationalNumber Reduce()
{
    int gcd = GCD(_Numerator, _Denominator);
    int numerator = _Numerator / gcd;
    int denominator = _Denominator / gcd;

    // Ensure denominator is positive
    if (denominator < 0)
    {
        numerator = -numerator;
        denominator = -denominator;
    }

    return new RationalNumber(numerator, denominator);
}


private static int GCD(int a, int b)
{
    a = Math.Abs(a);
    b = Math.Abs(b);

    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }

    return a == 0 ? 1 : a;
}


public RationalNumber Exprational(int power)
{
    if (power == 0)
        return new RationalNumber(1, 1);

    bool isNegative = _Numerator < 0;
    int absNum = Math.Abs(_Numerator);
    int absDen = Math.Abs(_Denominator);

    int numPow = (int)Math.Pow(absNum, Math.Abs(power));
    int denPow = (int)Math.Pow(absDen, Math.Abs(power));

    // Determine sign after exponentiation
    int sign = (isNegative && power % 2 != 0) ? -1 : 1;

    if (power > 0)
        return new RationalNumber(sign * numPow, denPow).Reduce();

    // negative power -> reciprocal
    return new RationalNumber(sign * denPow, numPow).Reduce();
}


    public double Expreal(int baseNumber)
    {
        return Math.Pow(baseNumber, (double)_Numerator / _Denominator);
    }
}
