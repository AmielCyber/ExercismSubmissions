using System;
using System.Text;

public static class Acronym
{
    private static char[] Seperators = new char[] { ' ', '-' };

    public static string Abbreviate(string phrase)
    {
        StringBuilder acronym = new();
        string[] words = phrase.Split(Seperators);

        foreach (string word in words)
        {
            char firstLetter = GetFirstLetterToUpper(word);
            if (!Char.IsWhiteSpace(firstLetter))
                acronym.Append(firstLetter);
        }
        return acronym.ToString();
    }

    private static char GetFirstLetterToUpper(string word)
    {
        foreach (char ch in word)
        {
            if (Char.IsLetter(ch))
                return Char.ToUpper(ch);
        }
        return ' ';
    }
}
