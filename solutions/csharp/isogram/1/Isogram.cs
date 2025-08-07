using System;
using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        HashSet<char> letters = new();
        foreach (char ch in word)
        {
            if (Char.IsLetter(ch) && letters.Contains(Char.ToLower(ch)))
            {
                return false;
            }
            letters.Add(Char.ToLower(ch));
        }
        return true;
    }
}
