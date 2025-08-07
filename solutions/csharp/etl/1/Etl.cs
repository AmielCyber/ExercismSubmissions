using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> newDictionary = new();
        foreach (KeyValuePair<int, string[]> pair in old)
        {
            foreach (string val in pair.Value)
            {
                newDictionary.Add(val.ToLower(), pair.Key);
            }
        }

        return newDictionary;
    }
}
