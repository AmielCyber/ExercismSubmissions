using System;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 0)
            throw new ArgumentOutOfRangeException($"No negaitive numbers for {nameof(limit)}");

        HashSet<int> visited = new();
        List<int> primes = new();
        for (int num = 2; num <= limit; num++)
        {
            if (!visited.Contains(num))
            {
                primes.Add(num);
                for (int factor = num; factor <= limit; factor += num)
                {
                    visited.Add(factor);
                }
            }
        }

        return primes.ToArray();
    }
}
