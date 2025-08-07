using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class LogParser
{
    private static readonly HashSet<string> Levels = ["TRC", "DBG", "INF", "WRN", "ERR", "FTL"];

    public bool IsValidLine(string text)
    {
        string pattern = @"^\s*\[(\w{3})\].*";
        Match m = Regex.Match(text, pattern);
        string logLevel = m.Groups[1].Value;

        return Levels.Contains(logLevel);
    }

    public string[] SplitLogLine(string text) => Regex.Split(text, @"<[\^\*=-]*>");

    public int CountQuotedPasswords(string lines)
    {
        string pattern = """
            \"(?:.*\s)?password(?:\s.*)?\"
            """;
        MatchCollection m = Regex.Matches(lines, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        return m.Count;
    }

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\w*", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        List<string> linesWithPassword = new List<string>();
        string pattern = @"\w+password|password\w+";
        foreach (string line in lines)
        {
            var m = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
                linesWithPassword.Add($"{m.Captures.First()}: {line}");
            else
                linesWithPassword.Add($"--------: {line}");
        }
        return linesWithPassword.ToArray();
    }
}


