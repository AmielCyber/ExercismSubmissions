using System;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        StringBuilder strB = new();
        if (number % 3 == 0)
            strB.Append("Pling");
        if (number % 5 == 0)
            strB.Append("Plang");
        if (number % 7 == 0)
            strB.Append("Plong");
        if (strB.Length == 0)
            strB.Append(number);
        return strB.ToString();
    }
}
