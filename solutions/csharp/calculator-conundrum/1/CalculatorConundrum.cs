public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if(!String.IsNullOrEmpty(operation)){
            switch(operation){
                case "+":
                    return $"{operand1} {operation} {operand2} = {SimpleOperation.Addition(operand1, operand2)}";
                case "*":
                    return $"{operand1} {operation} {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}";
                case "/":
    return (operand2 == 0)
        ? "Division by zero is not allowed."
        : $"{operand1} {operation} {operand2} = {SimpleOperation.Division(operand1, operand2)}";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
            else if(operation == ""){
                throw new ArgumentException();
            }
            else{
                throw new ArgumentNullException();
            }
        return "";
    }
}
