using System;
using System.Collections.Generic;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        ValidateArguments(inputBase, outputBase);
        long decimalNum = GetBase10(inputDigits, inputBase);
        return GetRebaseDigits(decimalNum, outputBase);
    }

    private static long GetBase10(int[] inputDigits, int inputBase)
    {
        int numOfDigits = inputDigits.Length;
        long num = 0;
        for (int i = 0; i < numOfDigits; i++)
        {
            ValidateDigit(i, inputDigits, inputBase);
            num += inputDigits[i] * (long)(Math.Pow(inputBase, numOfDigits - i - 1));
        }
        return num;
    }

    private static int[] GetRebaseDigits(long decimalNum, int outputBase)
    {
        if (decimalNum == 0)
            return new int[] { 0 };

        List<int> num = new List<int>();
        while (decimalNum > 0)
        {
            int remainder = (int)(decimalNum % outputBase);
            decimalNum /= outputBase;
            num.Add(remainder);
        }

        return num.Reverse<int>().ToArray();
    }

    private static void ValidateArguments(int inputBase, int outputBase)
    {
        if (inputBase <= 1)
            throw new ArgumentException($"{nameof(inputBase)} must be greater than one.");
        if (outputBase <= 1)
            throw new ArgumentException($"{nameof(outputBase)} must be greater than one.");
    }

    private static void ValidateDigit(int index, int[] inputDigits, int inputBase)
    {
        if (inputDigits[index] < 0)
            throw new ArgumentException(
                $"Negative value found at index {index} in digits. Digits must only contain non-negative values."
            );
        if (inputDigits[index] >= inputBase)
            throw new ArgumentException(
                $"Invalid value found at index {index} in digits. Digits must be less than the input base."
            );
    }
}
