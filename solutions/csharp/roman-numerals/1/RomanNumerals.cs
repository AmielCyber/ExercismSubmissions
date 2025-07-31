using System;
using System.Text;

public static class RomanNumeralExtension
{
    public static string GetRomanThousand(int num) =>
        num switch
        {
            1 => "M",
            2 => "MM",
            3 => "MMM",
            _ => "",
        };
    public static string GetRomanHoundred(int num) =>
        num switch
        {
            1 => "C",
            2 => "CC",
            3 => "CCC",
            4 => "CD",
            5 => "D",
            6 => "DC",
            7 => "DCC",
            8 => "DCCC",
            9 => "CM",
            _ => "",
        };
    public static string GetRomanTenth(int num) =>
        num switch
        {
            1 => "X",
            2 => "XX",
            3 => "XXX",
            4 => "XL",
            5 => "L",
            6 => "LX",
            7 => "LXX",
            8 => "LXXX",
            9 => "XC",
            _ => "",
        };
    public static string GetRomanNumber(int num) =>
        num switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            4 => "IV",
            5 => "V",
            6 => "VI",
            7 => "VII",
            8 => "VIII",
            9 => "IX",
            _ => "",
        };

    public static string ToRoman(this int value)
    {
        StringBuilder stringBuilder = new();

        int currentValue = value;
        if (currentValue >= 1000)
        {
            stringBuilder.Append(GetRomanThousand(currentValue / 1000));
            currentValue %= 1000;
        }
        if (currentValue >= 100)
        {
            stringBuilder.Append(GetRomanHoundred(currentValue / 100));
            currentValue %= 100;
        }
        if (currentValue >= 10)
        {
            stringBuilder.Append(GetRomanTenth(currentValue / 10));
            currentValue %= 10;
        }
        if (currentValue >= 1)
        {
            stringBuilder.Append(GetRomanNumber(currentValue));
        }

        return stringBuilder.ToString();
    }
}
