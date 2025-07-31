using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);

        return new string(arr);
    }
}
