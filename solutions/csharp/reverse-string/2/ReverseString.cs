public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] revInputArr = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
            revInputArr[input.Length - 1 - i] = input[i];

        return new string(revInputArr);
    }
}
