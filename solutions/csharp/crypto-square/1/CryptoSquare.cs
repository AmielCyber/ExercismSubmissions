using System.Text;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext) =>
        string.Concat(
            plaintext
                .Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c))
                .Select(char.ToLower)
        );

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        if (plaintext.Length == 0)
            return [];
        int rows = GetNumberOfRows(plaintext.Length);
        int cols = GetNumberOfCols(plaintext.Length, rows);
        string[] segments = new string[rows];
        for (int row = 0, col = 0; row < rows; row++, col += cols)
        {
            if(col + cols < plaintext.Length)
                segments[row] = plaintext.Substring(col, cols);
            else
            {
               segments[row] = plaintext.Substring(col).PadRight(cols); 
            }
        }

        return segments;
    }

    public static string Encoded(string plaintext)
    {
        string[] segments = PlaintextSegments(plaintext).ToArray();
        if (segments.Length == 0 || segments[0].Length == 0)
            return "";
        int cols = segments[0].Length;

        StringBuilder builder = new StringBuilder();
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < segments.Length; row++)
            {
                builder.Append(segments[row][col]);
            }

            if (col + 1 < cols)
                builder.Append(' ');
        }

        return builder.ToString();
    }

    public static string Ciphertext(string plaintext) => Encoded(NormalizedPlaintext(plaintext));

    private static int GetNumberOfRows(int strLength) => (int)Math.Round(Math.Sqrt(strLength));

    private static int GetNumberOfCols(int strLength, int rows) => (int)Math.Ceiling((double)strLength / rows);

}
