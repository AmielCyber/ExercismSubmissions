public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        for (int i = 0; i < takeDown; i++, startBottles--)
        {
            yield return GetLastVerse(startBottles);
        }
    }

    private static string GetFirstAndSecondVerse(int amount)
    {
        string bottle = "bottle" + (amount != 1 ? "s" : "");
        string wordNumber = GetWordNumber(amount);

        return $"{wordNumber} green {bottle} hanging on the wall,";
    }

    private static string GetThirdVerse() => "And if one green bottle should accidentally fall,";

    private static string GetLastVerse(int amount) =>
        $"There'll be {GetFirstAndSecondVerse(amount - 1).ToLower()}";

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
