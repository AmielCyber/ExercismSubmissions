public static class Bob
{
    private static string QuestionResponse = "Sure.";
    private static string YellingResponse = "Whoa, chill out!";
    private static string YellingQuestionResponse = "Calm down, I know what I'm doing!";
    private static string SilenceResponse = "Fine. Be that way!";
    private static string DefaultResponse = "Whatever.";

    private static bool IsQuestion(this string statement)
    {
        return statement.TrimEnd().EndsWith("?");
    }

    private static bool IsYelling(this string statement)
    {
        bool hasLetters = false;
        foreach (char ch in statement)
        {
            if (char.IsLetter(ch))
            {
                if (!hasLetters)
                {
                    hasLetters = true;
                }
                if (char.IsLower(ch))
                {
                    return false;
                }
            }
        }
        return hasLetters;
    }

    private static bool IsSilence(this string statement)
    {
        return string.IsNullOrWhiteSpace(statement);
    }

    public static string Response(string statement)
    {
        if (statement.IsSilence())
        {
            return SilenceResponse;
        }
        if (statement.IsYelling())
        {
            if (statement.IsQuestion())
            {
                return YellingQuestionResponse;
            }
            return YellingResponse;
        }
        if (statement.IsQuestion())
        {
            return QuestionResponse;
        }
        return DefaultResponse;
    }
}
