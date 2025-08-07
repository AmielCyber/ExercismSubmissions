using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        int sum = 0;
        for (int i = 1; i < max; i++)
        {
            if (multiples.Any(val => val != 0 && i % val == 0))
            {
                sum += i;
            }
        }

        return sum;
    }
}
