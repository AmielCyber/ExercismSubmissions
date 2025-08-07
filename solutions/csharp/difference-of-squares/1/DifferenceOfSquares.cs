using System;

public static class DifferenceOfSquares
{
    private static int CalculateSummation(int n)
    {
        return (n * n + n) / 2;
    }
    public static int CalculateSquareOfSum(int max)
    {
        return (int)Math.Pow(CalculateSummation(max), 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        return max * (max + 1) * (2 * max + 1) / 6;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}
