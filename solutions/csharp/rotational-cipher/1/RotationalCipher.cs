using System;

public static class RotationalCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    private static char GetCipherLetter(char ch, int shiftKey)
    {
        if (!Char.IsLetter(ch))
        {
            return ch;
        }

        int value = Char.ToLower(ch) - 'a';
        int shiftIndex = (value + shiftKey) % Alphabet.Length;
        char cipherChar = Alphabet[shiftIndex];

        return Char.IsUpper(ch) ? Char.ToUpper(cipherChar) : cipherChar;
    }

    public static string Rotate(string text, int shiftKey)
    {
        char[] cipherText = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            cipherText[i] = GetCipherLetter(text[i], shiftKey);
        }
        return new string(cipherText);
    }
}
