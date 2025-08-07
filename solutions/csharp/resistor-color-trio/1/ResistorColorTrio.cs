public static class ResistorColorTrio
{
    private static Dictionary<string, int> Colors = new Dictionary<string, int>()
    {
        { "black", 0 },
        { "brown", 1 },
        { "red", 2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 },
    };
    private const int Giga = 1_000_000_000;
    private const int Mega = 1_000_000;
    private const int Kilo = 1_000;

    public static string Label(string[] colors)
    {
        string[] lowerCaseColors = colors.Select(c => c.ToLower()).ToArray();
        long decodedValue = GetDecodedValue(lowerCaseColors);
        return GetDecodedOutput(decodedValue, lowerCaseColors);
    }

    private static long GetDecodedValue(string[] colors)
    {
        long val = 0;
        if (colors.Length < 1)
            throw new ArgumentOutOfRangeException();

        if (Colors.ContainsKey(colors[0]))
            val += Colors[colors[0]];

        if (Colors.Count > 1 && Colors.ContainsKey(colors[1]))
        {
            val *= 10;
            val += Colors[colors[1]];
        }
        if (Colors.Count > 2 && Colors.ContainsKey(colors[2]))
        {
            int exponent = Colors[colors[2]];
            for (int i = exponent; i > 0; i--)
                val *= 10;
        }
        return val;
    }

    private static string GetDecodedOutput(long decodedValue, string[] colors)
    {
        if (decodedValue >= Giga)
            return $"{GetBaseNumber(decodedValue, Giga)} gigaohms";
        if (decodedValue >= Mega)
            return $"{GetBaseNumber(decodedValue, Mega)} megaohms";
        if (decodedValue >= Kilo)
            return $"{GetBaseNumber(decodedValue, Kilo)} kiloohms";
        return $"{decodedValue} ohms";
    }

    private static long GetBaseNumber(long decodedValue, int baseNumber)
    {
        while (decodedValue % baseNumber == 0)
            decodedValue /= baseNumber;
        return decodedValue;
    }
}
