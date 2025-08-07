using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static bool IsTag(string text, string tag) => text.StartsWith($"<{tag}>");

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = Wrap("$1", tag);
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse_(Parse__((markdown)));
        return list ? parsedText : Wrap(parsedText, "p");
    }

    private static bool IsHeader(char ch) => ch == '#';

    private static int GetHeaderSize(string markdown)
    {
        int headerSize = 0;
        for (int i = 0; i < markdown.Length && IsHeader(markdown[i]); i++)
            headerSize += 1;
        return headerSize;
    }
    private static bool IsNotHeader(int headerSize) => headerSize == 0 || headerSize > 6;

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        int headerSize = GetHeaderSize(markdown);

        if (IsNotHeader(headerSize))
        {
            inListAfter = list;
            return null;
        }

        var headerTag = "h" + headerSize;
        var headerHtml = Wrap(markdown.Substring(headerSize + 1), headerTag);

        if (list)
        {
            inListAfter = false;
            return "</ul>" + headerHtml;
        }
        else
        {
            inListAfter = false;
            return headerHtml;
        }
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");

            if (list)
            {
                inListAfter = true;
                return innerHtml;
            }
            else
            {
                inListAfter = true;
                return "<ul>" + innerHtml;
            }
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool hasListBefore, out bool inListAfter)
    {
        inListAfter = false;
        string text = ParseText(markdown, false);
        return hasListBefore ? "</ul>" + text : text;
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        string header = ParseHeader(markdown, list, out inListAfter);
        if (header != null)
            return header;

        string line = ParseLineItem(markdown, list, out inListAfter);
        if (line != null)
            return line;

        string paragraph = ParseParagraph(markdown, list, out inListAfter);
        if (paragraph != null)
            return paragraph;

        throw new ArgumentException("Invalid markdown");
    }

    public static string Parse(string markdown)
    {
        string[] lines = markdown.Split('\n');
        StringBuilder result = new();
        bool isList = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string lineResult = ParseLine(lines[i], isList, out isList);
            result.Append(lineResult);
        }

        if (isList)
            result.Append("</ul>");

        return result.ToString();
    }
}
