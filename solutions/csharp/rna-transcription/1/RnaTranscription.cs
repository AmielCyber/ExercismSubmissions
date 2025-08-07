using System.Collections.Generic;
using System.Text;

public static class RnaTranscription
{
    private static Dictionary<char, char> strand = new()
    {
        {'G', 'C'},{'C', 'G'},{'T', 'A'},{'A', 'U'}
    };
    public static string ToRna(string nucleotide)
    {
        StringBuilder stringBuilder = new();
        foreach (char ch in nucleotide)
        {
            if (strand.ContainsKey(ch))
                stringBuilder.Append(strand[ch]);
        }
        return stringBuilder.ToString();
    }
}
