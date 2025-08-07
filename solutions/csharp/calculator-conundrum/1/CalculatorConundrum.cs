using System;

public static class SimpleCalculator
{
    private static string GetExpressionResult(int operand1, int operand2, string operation, string total) => $"{operand1} {operation} {operand2} = {total}";

    public static string Calculate(int operand1, int operand2, string operation) =>
        operation switch
        {
            "+" => GetExpressionResult(operand1, operand2, operation, SimpleOperation.Addition(operand1, operand2).ToString()),
            "*" => GetExpressionResult(operand1, operand2, operation, SimpleOperation.Multiplication(operand1, operand2).ToString()),
            "/" => operand2 == 0 ? "Division by zero is not allowed." : GetExpressionResult(operand1, operand2, operation, SimpleOperation.Division(operand1, operand2).ToString()),
            "" => throw new ArgumentException(),
            null => throw new ArgumentNullException(),
            _ => throw new ArgumentOutOfRangeException(),
        };
}
