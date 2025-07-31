using System;
using System.Text;

public static class Identifier
{
  private static bool IsGreekLetterInRange(char ch)
  {
    return ch >= 'α' && ch <= 'ω';
  }

  private static bool IsCharKebabCase(string str, int charLocation)
  {
    return charLocation > 0 && str[charLocation - 1] == '-';
  }

  public static string Clean(string identifier)
  {
    StringBuilder stringBuilder = new StringBuilder();

    for (int i = 0; i < identifier.Length; i++)
    {
      char ch = identifier[i];

      if (Char.IsWhiteSpace(ch))
      {
        stringBuilder.Append("_");
      }
      else if (Char.IsControl(ch))
      {
        stringBuilder.Append("CTRL");
      }
      else if (Char.IsLetter(ch) && !IsGreekLetterInRange(ch))
      {
        if (IsCharKebabCase(identifier, i))
        {
          stringBuilder.Append(Char.ToUpper(ch));
        }
        else
        {
          stringBuilder.Append(ch);
        }
      }
    }

    return stringBuilder.ToString();
  }
}
