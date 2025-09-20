public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    {
         Operand1 = operand1;
        Operand2 = operand2;
        Inner  = inner;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
    public Exception Inner {get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try{
            this.Multiply(x, y);
        }
        catch (CalculationException xEx) when (x < 0 && y < 0)
        {
            return $"Multiply failed for negative operands. {xEx.Inner.Message}";
        }
        catch (CalculationException xEx) when (x > 0 || y > 0)
        {
            return $"Multiply failed for mixed or positive operands. {xEx.Inner.Message}";
        }
        return "Multiply succeeded";
    }

    public void Multiply(int x, int y)
    {
        try{
            calculator.Multiply(x, y);
        }
        catch (OverflowException xEx)
        {
            throw new CalculationException(x, y, "Multiplication caused an overflow", xEx);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
