using System;

public static class RotationalCipher
{
    private const int AplphabetLength = 26;

    private static char GetCipherLetter(char ch, int shiftKey)
    {
        if (!Char.IsLetter(ch))
        {
            return ch;
        }

        char a = Char.IsLower(ch) ? 'a' : 'A';
        return (char)(((ch - a + shiftKey) % AplphabetLength) + a);
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
