using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        string denomination = string.Empty;
        try
        {
            long result = checked(@base * multiplier);
            denomination = result.ToString();
        }
        catch (OverflowException)
        {
            denomination = "*** Too Big ***";
        }
        return denomination;
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        string gdp = string.Empty;
        try
        {
            float result = checked(@base * multiplier);
            if (float.IsInfinity(result))
                throw new OverflowException();
            gdp = result.ToString();
        }
        catch (OverflowException)
        {
            gdp = "*** Too Big ***";
        }
        return gdp;
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        string salary = string.Empty;
        try
        {
            decimal result = checked(salaryBase * multiplier);
            salary = result.ToString();
        }
        catch (OverflowException)
        {
            salary = "*** Much Too Big ***";
        }
        return salary;
    }
}
