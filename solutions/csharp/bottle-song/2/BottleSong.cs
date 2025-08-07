public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        for (int i = 0; i < takeDown; i++, startBottles--)
        {
            yield return $"{GetMelody(startBottles)},";
            yield return $"{GetMelody(startBottles)},";
            yield return "And if one green bottle should accidentally fall,";
            yield return $"There'll be {GetMelody(startBottles - 1).ToLower()}.";
            if (i != takeDown - 1)
                yield return "";
        }
    }

    private static string GetMelody(int amount)
    {
        string bottle = "bottle" + (amount != 1 ? "s" : "");
        string wordNumber = GetWordNumber(amount);

        return $"{wordNumber} green {bottle} hanging on the wall";
    }

    private static string GetWordNumber(int amount) =>
        amount switch
        {
            0 => "No",
            1 => "One",
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            7 => "Seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten",
            _ => throw new ArgumentOutOfRangeException(),
        };
}
