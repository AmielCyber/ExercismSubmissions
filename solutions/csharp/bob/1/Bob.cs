public static class Bob
{
    private static string QuestionResponse = "Sure.";
    private static string YellingResponse = "Whoa, chill out!";
    private static string YellingQuestionResponse = "Calm down, I know what I'm doing!";
    private static string SilenceResponse = "Fine. Be that way!";
    private static string DefaultResponse = "Whatever.";

    private static bool IsQuestion(string statement)
    {
        return statement.TrimEnd().EndsWith("?");
    }

    private static bool IsYelling(string statement)
    {
        return statement.Equals(statement.ToUpper());
    }

    private static bool IsSilence(string statement)
    {
        return string.IsNullOrWhiteSpace(statement);
    }

    public static string Response(string statement)
    {
        if (IsYelling(statement))
        {
            if (IsQuestion(statement))
            {
                return YellingQuestionResponse;
            }
            return YellingResponse;
        }
        if (IsQuestion(statement))
        {
            return QuestionResponse;
        }
        if (IsSilence(statement))
        {
            return SilenceResponse;
        }
        return DefaultResponse;
    }
}
