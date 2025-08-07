public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> primes = new List<long>();
        for (int possiblePrime = 2; number > 1; possiblePrime++)
        {
            for (; number % possiblePrime == 0; number /= possiblePrime)
                primes.Add(possiblePrime);
        }
        return primes.ToArray();
    }

}
