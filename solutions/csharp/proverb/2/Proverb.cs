using System;

public static class Proverb
{
    private static string ReciteLine(string subject1, string subject2) => $"For want of a {subject1} the {subject2} was lost.";
    private static string ReciteLastLine(string subject) => $"And all for the want of a {subject}.";

    public static string[] Recite(string[] subjects)
    {
        string[] song = new string[subjects.Length];
        if (subjects.Length == 0)
        {
            return song;
        }

        for (int i = 1; i < subjects.Length; i++)
        {
            song[i - 1] = ReciteLine(subjects[i - 1], subjects[i]);
        }
        song[song.Length - 1] = ReciteLastLine(subjects[0]);

        return song;
    }
}
