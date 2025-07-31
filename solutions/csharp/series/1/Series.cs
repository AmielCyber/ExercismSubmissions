using System;

public static class Series
{
    private static void ValidateSlicesArgs(string numbers, int sliceLength)
    {
        if (string.IsNullOrEmpty(numbers))
            throw new ArgumentException($"{nameof(numbers)} must be a non-empty string.");
        if (sliceLength < 1)
            throw new ArgumentException($"{nameof(sliceLength)} must be a positive number.");
        if (sliceLength > numbers.Length)
            throw new ArgumentException($"{nameof(sliceLength)} is larger({sliceLength}) than the length of numbers({numbers.Length})");
    }
    public static string[] Slices(string numbers, int sliceLength)
    {
        ValidateSlicesArgs(numbers, sliceLength);

        int length = numbers.Length - sliceLength + 1;
        string[] digits = new string[length];
        for (int i = 0; i < length; i++)
        {
            digits[i] = numbers.Substring(i, sliceLength);
        }
        return digits;
    }
}
