using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    private const int offset = (int)'a';

    public static bool IsPangram(string input)
    {
        bool[] containsLetter = new bool[26];
        foreach (char letter in input)
        {
            char lowerCaseLetter = Char.ToLower(letter);
            if (Char.IsLetter(lowerCaseLetter))
            {
                int index = (int)lowerCaseLetter - offset;
                containsLetter[index] = true;
            }
        }
        return containsLetter.All(hasLetter => hasLetter);
    }
}
