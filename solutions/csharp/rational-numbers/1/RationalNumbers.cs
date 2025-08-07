public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    public int Numerator { get; init; }
    public int Denominator { get; init; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int newNumerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
        int newDenominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(newNumerator, newDenominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int newNumerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
        int newDenominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(newNumerator, newDenominator).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int numeratorProduct = r1.Numerator * r2.Numerator;
        int denominatorProduct = r1.Denominator * r2.Denominator;

        return new RationalNumber(numeratorProduct, denominatorProduct).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber reciprocolR2 = new RationalNumber(r2.Denominator, r2.Numerator);
        return r1 * reciprocolR2;
    }

    public RationalNumber Abs() =>
        new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator)).Reduce();

    public RationalNumber Reduce()
    {
        if (Numerator == 0)
            return new RationalNumber(0, 1);

        int newNum = Numerator;
        int newDenom = Denominator;
        int gcd = Math.Abs(GetGCD(Numerator, Denominator));

        if (gcd > 1)
        {
            newNum = newNum / gcd;
            newDenom = newDenom / gcd;
        }
        if (newDenom < 0)
        {
            newNum *= -1;
            newDenom *= -1;
        }
        return new RationalNumber(newNum, newDenom);
    }

    public RationalNumber Exprational(int power)
    {
        int absExponent = Math.Abs(power);
        if (power < 0)
        {
            return new RationalNumber(
                (int)Math.Pow(Denominator, absExponent),
                (int)Math.Pow(Numerator, absExponent)
            ).Reduce();
        }
        return new RationalNumber(
            (int)Math.Pow(Numerator, absExponent),
            (int)Math.Pow(Denominator, absExponent)
        ).Reduce();
    }

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, Numerator / (double)Denominator);

    private int GetGCD(int numerator, int denominator)
    {
        int max = Math.Max(numerator, denominator);
        int min = Math.Min(numerator, denominator);

        int gcd = max % min;
        while (gcd != 0)
        {
            max = min;
            min = gcd;
            gcd = max % min;
        }
        return min;
    }
}

