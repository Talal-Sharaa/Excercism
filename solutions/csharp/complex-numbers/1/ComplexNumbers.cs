public struct ComplexNumber
{
    public double _Real;
    public double _Imaginary;
    public ComplexNumber(double real, double imaginary)
    {
        _Real = real;
        _Imaginary = imaginary;
    }

    public double Real()
    {
        return this._Real;
    }

    public double Imaginary()
    {
        return this._Imaginary;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        double xRealResult = this._Real * other._Real - this._Imaginary * other._Imaginary;
        double xImaginaryResult = this._Imaginary * other._Real + this._Real * other._Imaginary;
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }
    public ComplexNumber Mul(int other)
    {
        double xRealResult = this._Real * other;
        double xImaginaryResult = this._Imaginary * other;
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        double xRealResult = this._Real + other._Real;
        double xImaginaryResult = this._Imaginary + other._Imaginary;
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }
    public ComplexNumber Add(int other)
    {
        return new ComplexNumber(this._Real + other, this._Imaginary);
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        double xRealResult = this._Real - other._Real;
        double xImaginaryResult = this._Imaginary - other._Imaginary;
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        double xRealResult = (this._Real * other._Real + this._Imaginary * other._Imaginary)/(other._Real * other._Real + other._Imaginary * other._Imaginary);
        double xImaginaryResult = (this._Imaginary * other._Real - this._Real * other._Imaginary)/(other._Real * other._Real + other._Imaginary * other._Imaginary);
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }

        public ComplexNumber Div(int other)
    {
        double xRealResult = this._Real / other;
        double xImaginaryResult = this._Imaginary / other;
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }

    public double Abs()
    {
        return Math.Sqrt((Math.Pow(this._Real, 2) + Math.Pow(this._Imaginary, 2)));
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(this._Real, -1 * this._Imaginary);
    }
    
    public ComplexNumber Exp()
    {
        double xRealResult = Math.Pow(Math.E, this._Real) * Math.Cos(this._Imaginary);
        double xImaginaryResult = Math.Pow(Math.E, this._Real) * Math.Sin(this._Imaginary);
        return new ComplexNumber(xRealResult, xImaginaryResult);
    }
}