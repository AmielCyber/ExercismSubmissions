using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        var levelEnd = logLine.IndexOf(":");
        var msgStart = levelEnd + 1;
        if(levelEnd >= 0 && msgStart < logLine.Length){
            return logLine.Substring(msgStart).Trim();
        }
        return logLine;
    }

    public static string LogLevel(string logLine)
    {
        var levelStart = logLine.IndexOf("[");
        var levelEnd = logLine.IndexOf("]");
        if(levelStart >= 0 && levelStart + 1 < logLine.Length && levelEnd >= 0 && levelEnd < logLine.Length){
            return logLine.Substring(levelStart + 1, levelEnd - levelStart-1).ToLower();
        }
        return logLine;
    }

    public static string Reformat(string logLine)
    {
        return Message(logLine) + $" ({LogLevel(logLine)})";
    }
}
