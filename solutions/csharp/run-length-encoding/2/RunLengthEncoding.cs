using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        StringBuilder stringBuilder = new();
        int index = 0;
        while (index < input.Length)
        {
            int nextIndex = GetNextUniqueCharLocation(index, input);
            int count = nextIndex - index;
            if (count > 1)
                stringBuilder.Append(nextIndex - index);
            stringBuilder.Append(input[index]);
            index = nextIndex;
        }
        return stringBuilder.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder stringBuilder = new();
        int index = 0;
        while (index < input.Length)
        {
            int nextIndex = GetNextCharLocation(index, input);

            if (nextIndex == index)
            {
                stringBuilder.Append(input[index]);
                index++;
            }
            else
            {
                bool success = int.TryParse(input.Substring(index, nextIndex - index), out int num);
                if (!success)
                    throw new ArgumentException("Not a valid format.");

                stringBuilder.Append(input[nextIndex], num);
                index = nextIndex + 1;
            }
        }
        return stringBuilder.ToString();
    }

    private static int GetNextUniqueCharLocation(int startIndex, string input)
    {
        int index = startIndex + 1;
        while (index < input.Length && input[index] == input[startIndex])
            index++;

        return index;
    }

    private static int GetNextCharLocation(int startIndex, string input)
    {
        int index = startIndex;
        while (
            index < input.Length
            && !(Char.IsLetter(input[index]) || Char.IsWhiteSpace(input[index]))
        )
            index++;

        return index;
    }
}
