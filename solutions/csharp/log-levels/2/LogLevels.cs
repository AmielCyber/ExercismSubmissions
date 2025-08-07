static class LogLine
{
    private const string Delimeter = ":";

    public static string Message(string logLine)
    {
        int delimeterIndex = logLine.IndexOf(Delimeter);
        int msgStartIndex = delimeterIndex + 1;

        if (delimeterIndex >= 0 && msgStartIndex < logLine.Length)
            return logLine.Substring(msgStartIndex).Trim();
        return logLine;
    }

    public static string LogLevel(string logLine)
    {
        var levelStartIndex = logLine.IndexOf("[");
        var levelEndIndex = logLine.IndexOf("]");

        if (LogLevelExists(levelStartIndex, levelEndIndex, logLine.Length))
            return logLine
                .Substring(levelStartIndex + 1, levelEndIndex - levelStartIndex - 1)
                .ToLower();
        return logLine;
    }

    public static string Reformat(string logLine) => Message(logLine) + $" ({LogLevel(logLine)})";

    private static bool LogLevelExists(int levelStartIndex, int levelEndIndex, int logLineLength) =>
        levelStartIndex >= 0
        && levelStartIndex + 1 < logLineLength
        && levelEndIndex >= 0
        && levelEndIndex < logLineLength;
}
