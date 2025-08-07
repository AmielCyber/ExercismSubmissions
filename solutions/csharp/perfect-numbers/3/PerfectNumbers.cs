using System;

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
        if (number < 1)
            throw new ArgumentOutOfRangeException($"{nameof(number)} must be greater than 0.");

        int aliquotSum = GetAliquotSum(number);
        if (aliquotSum < number)
            return Classification.Deficient;
        if (aliquotSum > number)
            return Classification.Abundant;
        return Classification.Perfect;
    }
    private static int GetAliquotSum(int number)
    {
        int sum = 0;
        int divisor = 1;
        int maxDivisor = number / 2;
        while (divisor <= maxDivisor)
        {
            if (number % divisor == 0)
                sum += divisor;
            divisor++;
        }
        return sum;
    }
}
