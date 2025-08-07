using System.Collections.Concurrent;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        ConcurrentDictionary<char, int> dic = new();
        Parallel.ForEach(texts, text => CountCharacters(dic, text));

        return dic.ToDictionary();
    }

    private static void CountCharacters(ConcurrentDictionary<char, int> dictionary, string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (
                !Char.IsWhiteSpace(text[i])
                && !Char.IsPunctuation(text[i])
                && !Char.IsNumber(text[i])
            )
                dictionary.AddOrUpdate(Char.ToLower(text[i]), 1, (key, oldVal) => oldVal + 1);
        }
    }
}

