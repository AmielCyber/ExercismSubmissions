using System;

public static class ResistorColor
{
    private static string[] Color = new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color)
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

    public static string[] Colors()
    {
        return Color;
    }
}
