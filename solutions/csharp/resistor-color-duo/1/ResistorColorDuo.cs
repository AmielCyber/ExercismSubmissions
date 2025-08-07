using System;

public static class ResistorColorDuo
{
    private static string[] Color = new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    private static int ColorCode(string color)
    {
        for (int i = 0; i < Color.Length; i++)
        {
            if (Color[i] == color)
            {
                return i;
            }
        }
        return -1;
    }

    public static int Value(string[] colors)
    {
        int value = 0;
        for (int i = 0; i < Color.Length && i < 2; i++)
        {
            value *= 10;
            value += ColorCode(colors[i]);
        }
        return value;
    }
}
