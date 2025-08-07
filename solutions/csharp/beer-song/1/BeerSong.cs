using System.Text;

public static class BeerSong
{
    public static string GetNumOfBottlesVerse(int numOfBottles) =>
    numOfBottles switch
    {
        > 1 => $"{numOfBottles} bottles of beer on the wall, {numOfBottles} bottles of beer.\n",
        1 => "1 bottle of beer on the wall, 1 bottle of beer.\n",
        _ => "No more bottles of beer on the wall, no more bottles of beer.\n",
    };

    public static string GetTakeDownVerse(int numOfBottles) =>
    numOfBottles switch
    {
        > 1 => $"Take one down and pass it around, {numOfBottles} bottles of beer on the wall.",
        1 => "Take one down and pass it around, 1 bottle of beer on the wall.",
        0 => "Take it down and pass it around, no more bottles of beer on the wall.",
        _ => $"Go to the store and buy some more, 99 bottles of beer on the wall.",
    };

    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 1, numOfBottles = startBottles; i <= takeDown; i++, numOfBottles--)
        {
            stringBuilder.Append(GetNumOfBottlesVerse(numOfBottles));
            stringBuilder.Append(GetTakeDownVerse(numOfBottles - 1));
            if (i < takeDown)
            {
                stringBuilder.Append("\n\n");
            }
        }
        return stringBuilder.ToString();
    }
}
