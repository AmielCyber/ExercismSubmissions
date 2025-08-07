public static class MatchingBrackets
{
    private static List<(char left, char right)> _brackets = new()
    {
        ('[', ']'),
        ('{', '}'),
        ('(', ')'),
    };
    private static (char, char) _notFound = default;

    public static bool IsPaired(string input)
    {
        Stack<(char left, char right)> bracketStack = new();
        foreach (char ch in input)
        {
            (char left, char right) bracket = _brackets.Find(b => b.left == ch || ch == b.right);
            if (bracket != _notFound)
            {
                if (bracket.left == ch)
                    bracketStack.Push(bracket);
                else if (bracketStack.Count < 1 || bracketStack.Pop().right != bracket.right)
                    return false;
            }
        }
        return bracketStack.Count == 0;
    }
}
