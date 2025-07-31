public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string delimeter)
    {
        int startIndex = str.IndexOf(delimeter);
        return str.Substring(startIndex + delimeter.Length);
    }

    public static string SubstringBetween(
        this string str,
        string firstDelimeter,
        string secondDelimeter
    )
    {
        int startIndex = str.IndexOf(firstDelimeter) + firstDelimeter.Length;
        int endIndex = str.IndexOf(secondDelimeter, startIndex) - startIndex;

        return str.Substring(startIndex, endIndex);
    }

    public static string Message(this string str) => str.SubstringAfter(":").Trim();

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}
