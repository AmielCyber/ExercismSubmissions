using System;
using System.Collections.Generic;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        HashSet<char> uniqueLetters = new();
        foreach (char letter in input)
        {
            char lowerCaseLetter = Char.ToLower(letter);

            if (Char.IsLetter(lowerCaseLetter) && !uniqueLetters.Contains(lowerCaseLetter))
            {
                uniqueLetters.Add(lowerCaseLetter);
            }
        }
        return uniqueLetters.Count == 26;
    }
}
