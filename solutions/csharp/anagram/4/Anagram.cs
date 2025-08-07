using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private string _lowerCaseWord;

    private int[] _letterCount = new int[26];
    private const int offset = (int)'a';

    public Anagram(string baseWord)
    {
        _lowerCaseWord = baseWord.ToLower();
        foreach (char ch in _lowerCaseWord)
        {
            if (Char.IsLetter(ch))
            {
                int letterIndex = ch - offset;
                _letterCount[letterIndex]++;
            }
        }
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new();
        foreach (string word in potentialMatches)
        {
            if (IsAnagram(word))
                matches.Add(word);
        }
        return matches.ToArray();
    }

    private bool IsAnagram(string otherWord)
    {
        otherWord = otherWord.ToLower();
        if (IsSameWord(otherWord) || IsDifferentLength(otherWord))
            return false;

        int[] letterCountCopy = new int[26];
        Array.Copy(_letterCount, letterCountCopy, letterCountCopy.Length);

        foreach (char ch in otherWord)
        {
            if (Char.IsLetter(ch))
            {
                int letterIndex = ch - offset;
                letterCountCopy[letterIndex]--;
                if (letterCountCopy[letterIndex] < 0)
                    return false;
            }
        }
        return letterCountCopy.All(count => count == 0);
    }

    private bool IsSameWord(string otherWord) => otherWord == _lowerCaseWord;

    private bool IsDifferentLength(string otherWord) => otherWord.Length != _lowerCaseWord.Length;
}
