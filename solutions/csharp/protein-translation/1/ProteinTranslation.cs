using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static string GetProtein(string codon)
    {
        switch (codon)
        {
            case "AUG":
                return "Methionine";
            case "UUU":
            case "UUC":
                return "Phenylalanine";
            case "UUA":
            case "UUG":
                return "Leucine";
            case "UCU":
            case "UCC":
            case "UCA":
            case "UCG":
                return "Serine";
            case "UAU":
            case "UAC":
                return "Tyrosine";
            case "UGU":
            case "UGC":
                return "Cysteine";
            case "UGG":
                return "Tryptophan";
            case "UAA":
            case "UAG":
            case "UGA":
            default:
                return string.Empty;
        }
    }
    public static string[] Proteins(string strand)
    {
        List<string> proteins = new();
        int index = 0;
        while (index < strand.Length)
        {
            string protein = GetProtein(strand.Substring(index, 3));
            if (string.IsNullOrEmpty(protein))
            {
                break;
            }
            proteins.Add(protein);
            index += 3;
        }

        return proteins.ToArray();
    }
}
