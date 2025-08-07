using System.Text;

public static class House
{
    public static string Recite(int verseNumber) => ReciteString(verseNumber);

    public static string Recite(int startVerse, int lastVerseNum)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = startVerse; i <= lastVerseNum; i++)
        {
            builder.Append(ReciteString(i));
            if (i != lastVerseNum)
                builder.Append("\n");
        }

        return builder.ToString();
    }

    private static string[] noun =
    [
        "house that Jack built.",
        "malt",
        "rat",
        "cat",
        "dog",
        "cow with the crumpled horn",
        "maiden all forlorn",
        "man all tattered and torn",
        "priest all shaven and shorn",
        "rooster that crowed in the morn",
        "farmer sowing his corn",
        "horse and the hound and the horn",
    ];

    private static string[] verb =
    [
        "lay in",
        "ate",
        "killed",
        "worried",
        "tossed",
        "milked",
        "kissed",
        "married",
        "woke",
        "kept",
        "belonged to",
    ];

    private static string ReciteString(int lastVerseNum)
    {
        StringBuilder builder = new StringBuilder();
        for (int verseNum = lastVerseNum - 1; verseNum > -1; verseNum--)
        {
            if (verseNum == lastVerseNum - 1)
                builder.Append($"This is the {noun[verseNum]}");
            else
                builder.Append($" that {verb[verseNum]} the {noun[verseNum]}");
        }
        return builder.ToString();
    }
}
