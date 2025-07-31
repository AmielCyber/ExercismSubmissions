using System;
using System.Collections.Generic;

/*
 * a < b < c
 * a**2 + b**2 = c**2
 * a + b + c = sum
 * a < sum/3
 * c = sum - a - b
 * b < sum - a - b
 */
public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        List<(int a, int b, int c)> list = new();
        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a + 1; b < sum - a - b; b++)
            {
                if (IsPythagoreanTriplet(a, b, sum))
                {
                    list.Add((a, b, sum - a - b));
                    break;
                }
            }
        }
        return list;
    }

    private static bool IsPythagoreanTriplet(int a, int b, int sum) =>
        (Math.Pow(a, 2) + Math.Pow(b, 2)) == Math.Pow(sum - a - b, 2);
}
