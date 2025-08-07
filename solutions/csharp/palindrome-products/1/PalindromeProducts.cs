using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException("Min factor cannot be greater than max factor");
        return GetLargestPalindrome(minFactor, maxFactor);
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException("Min factor cannot be greater than max factor");
        return GetSamllestPalindrome(minFactor, maxFactor);
    }

    private static (int, IEnumerable<(int, int)>) GetLargestPalindrome(int minFactor, int maxFactor)
    {
        int smallest = minFactor * minFactor - 1;
        int largest = smallest;
        List<(int, int)> pairs = new();

        for (int i = maxFactor; i >= minFactor; i--)
        {
            for (int j = i; j >= minFactor; j--)
            {
                int product = i * j;
                if (product > largest && IsPalindrome(product))
                {
                    largest = product;
                    pairs = new List<(int, int)>() { (j, i) };
                    break;
                }
                else if (product == largest)
                {
                    pairs.Add((j, i));
                    break;
                }
                else if (product < largest)
                {
                    break;
                }

            }
        }

        if (largest == smallest)
            throw new ArgumentException($"There is no palindrome in the range: [{minFactor},{maxFactor}]");

        return (largest, pairs);
    }

    private static (int, IEnumerable<(int, int)>) GetSamllestPalindrome(int minFactor, int maxFactor)
    {
        int largest = maxFactor * maxFactor + 1;
        int smallest = largest;
        List<(int, int)> pairs = new();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                int product = i * j;

                if (product < smallest && IsPalindrome(product))
                {
                    smallest = product;
                    pairs = new List<(int, int)>() { (i, j) };
                    break;
                }
                else if (product == smallest)
                {
                    pairs.Add((i, j));
                    break;
                }
                else if (product > smallest)
                {
                    break;
                }
            }
        }

        if (smallest == largest)
            throw new ArgumentException($"There is no palindrome in the range: [{minFactor},{maxFactor}]");

        return (smallest, pairs);
    }

    public static bool IsPalindrome(int number)
    {
        string numStr = number.ToString();
        for (int i = 0; i < numStr.Length / 2; i++)
        {
            if (numStr[i] != numStr[numStr.Length - 1 - i])
                return false;
        }
        return true;
    }
}
