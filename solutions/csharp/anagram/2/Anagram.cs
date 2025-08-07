using System;
using System.Collections.Generic;

public class Anagram
{
    private string _lowerCaseWord;
    private Dictionary<char, int> _wordCount;

    public Anagram(string baseWord)
    {
        _lowerCaseWord = baseWord.ToLower();
        _wordCount = new();
        foreach (char ch in _lowerCaseWord)
        {
            if (_wordCount.ContainsKey(ch))
            {
                _wordCount[ch] += 1;
            }
            else
            {
                _wordCount[ch] = 1;
            }
        }
    }

    private bool IsAnagram(string otherWord)
    {
        if (otherWord.ToLower() == _lowerCaseWord || otherWord.Length != _lowerCaseWord.Length) return false;

        Dictionary<char, int> newWordCount = new(_wordCount);
        foreach (char ch in otherWord)
        {
            char lowerCaseCh = Char.ToLower(ch);
            if (!newWordCount.ContainsKey(lowerCaseCh))
            {
                return false;
            }
            else
            {
                newWordCount[lowerCaseCh] -= 1;
                if (newWordCount[lowerCaseCh] == 0)
                {
                    newWordCount.Remove(lowerCaseCh);
                }
            }
        }
        return newWordCount.Count == 0;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new();
        foreach (string word in potentialMatches)
        {
            if (IsAnagram(word))
            {
                matches.Add(word);
            }
        }

        return matches.ToArray();
    }
}
