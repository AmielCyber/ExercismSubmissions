using System.Text;

public static class FoodChain
{
    private static string[] _animal = { "", "fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse" };
    private static string[] _animalComment =
    {
        "",
        "I don't know why she swallowed the fly. Perhaps she'll die.",
        "It wriggled and jiggled and tickled inside her.\n",
        "How absurd to swallow a bird!\n",
        "Imagine that, to swallow a cat!\n",
        "What a hog, to swallow a dog!\n",
        "Just opened her throat and swallowed a goat!\n",
        "I don't know how she swallowed a cow!\n",
        "She's dead, of course!",
    };
    private const int FIRST_VERSE = 1;
    private const int LAST_VERSE = 8;
    private const int SPIDER_VERSE = 3;

    public static string Recite(int verseNumber)
    {
        StringBuilder stringBuilder = new($"I know an old lady who swallowed a {_animal[verseNumber]}.\n");
        stringBuilder.Append(_animalComment[verseNumber]);

        if (verseNumber == FIRST_VERSE || verseNumber == LAST_VERSE)
            return stringBuilder.ToString();

        while (verseNumber > FIRST_VERSE)
        {
            if (verseNumber == SPIDER_VERSE)
                stringBuilder.Append("She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n");
            else
                stringBuilder.Append($"She swallowed the {_animal[verseNumber]} to catch the {_animal[verseNumber - 1]}.\n");

            verseNumber--;
        }

        stringBuilder.Append(_animalComment[FIRST_VERSE]);
        return stringBuilder.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder stringBuilder = new();

        int currentVerse = startVerse;
        while (currentVerse <= endVerse)
        {
            stringBuilder.Append(Recite(currentVerse));
            if (currentVerse != endVerse)
                stringBuilder.Append("\n\n");

            currentVerse++;
        }
        return stringBuilder.ToString();
    }
}
