using System.Text;
public class SimpleCipher
{
    private const int Letters = 26;
    private const int Offset = (int)'a';

    public SimpleCipher() => Key = GetRandomKey(100);

    public SimpleCipher(string key) => Key = key;

    public string Key { get; }

    public string Encode(string plaintext)
    {
        var builder = new StringBuilder();
        for (int i = 0, keyIndex = 0; i < plaintext.Length; i++, keyIndex++)
        {
            if (keyIndex >= Key.Length)
                keyIndex = 0;
            builder.Append(GetEncodedChar(plaintext[i], Key[keyIndex]));
        }
        return builder.ToString();
    }

    public string Decode(string ciphertext)
    {
        var builder = new StringBuilder();
        for (int i = 0, keyIndex = 0; i < ciphertext.Length; i++, keyIndex++)
        {
            if (keyIndex >= Key.Length)
                keyIndex = 0;
            builder.Append(GetDecodedChar(ciphertext[i], Key[keyIndex]));
        }
        return builder.ToString();
    }

    private string GetRandomKey(int length)
    {
        var random = new Random();
        var builder = new StringBuilder();
        for (int i = 0; i < length; i++)
            builder.Append(GetRandomLetter(random));

        return builder.ToString();
    }

    private char GetRandomLetter(Random random) => (char)(random.Next(0, Letters) + Offset);

    private char GetEncodedChar(char original, char key)
    {
        int letterIndex = GetLetterIndex(original);
        int shiftValue = GetLetterIndex(key);
        return (char)(((letterIndex + shiftValue) % Letters) + Offset);
    }
    
    private char GetDecodedChar(char codedCh, char key)
    {
        int letterIndex = GetLetterIndex(codedCh);
        int shiftValue = GetLetterIndex(key);
        int originalLetterIndex = letterIndex - shiftValue;
        if (originalLetterIndex < 0)
            originalLetterIndex += Letters;
        return (char)((originalLetterIndex) + Offset);
    }

    private int GetLetterIndex(char ch) => ch - Offset;
}
