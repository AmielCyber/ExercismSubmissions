public static class LargestSeriesProduct
{
    private static char offset = '0';

    public static long GetLargestProduct(string digits, int span)
    {
        if (span > digits.Length || span < 0)
            throw new ArgumentException();
        if (span == 0)
            return 1;

        long maxProd = 0;
        long currProd = -1;
        for (int right = span - 1; right < digits.Length; right++)
        {
            int left = right - span + 1;
            if (currProd < 0)
            {
                currProd = GetSpanProduct(digits, left, span);
            }
            else
            {
                int lastLeftDigit = GetDigit(digits[left - 1]);
                if (lastLeftDigit == 0)
                {
                    currProd = GetSpanProduct(digits, left, span);
                }
                else
                {
                    currProd /= GetDigit(digits[left - 1]);
                    currProd *= GetDigit(digits[right]);
                }
            }
            maxProd = Math.Max(currProd, maxProd);
        }
        return maxProd;
    }

    private static int GetDigit(char ch)
    {
        if (!Char.IsDigit(ch))
            throw new ArgumentException();
        return ch - offset;
    }

    private static long GetSpanProduct(string digits, int start, int span)
    {
        int product = 1;
        for (int i = 0; i < span; i++)
        {
            int right = start + i;
            product *= GetDigit(digits[right]);
        }
        return product;
    }
}
