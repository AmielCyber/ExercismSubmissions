using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string strNumber = number.ToString();
        int power = strNumber.Length;
        int armSum = 0;
        foreach (char digit in strNumber)
        {
            armSum += (int)Math.Pow(Char.GetNumericValue(digit), power);
            if (armSum > number)
                return false;
        }
        return armSum == number;
    }
}
