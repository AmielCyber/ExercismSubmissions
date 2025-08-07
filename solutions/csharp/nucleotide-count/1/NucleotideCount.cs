using System.Collections.Generic;
using System;

public static class NucleotideCount
{
    private static Dictionary<char, int> _nucleotides = new()
    {
        {'A' , 0},   {'C' , 0},   {'G' , 0},   {'T' , 0},
    };
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> nucleotideCount = new Dictionary<char, int>(_nucleotides);
        foreach (char n in sequence)
        {
            char nucleotide = Char.ToUpper(n);
            if (!nucleotideCount.ContainsKey(nucleotide))
                throw new ArgumentException($"{nameof(sequence)} contains invalid characters. Only characters: 'A', 'C', 'G', and 'T' are valid.");

            nucleotideCount[nucleotide]++;
        }

        return nucleotideCount;
    }
}
