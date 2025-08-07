public static class LogAnalysis
{
  // TODO: define the 'SubstringAfter()' extension method on the `string` type
  public static string SubstringAfter(this string str, string delimeter)
  {
    int start = str.IndexOf(delimeter);
    return str.Substring(start + delimeter.Length);
  }
  // TODO: define the 'SubstringBetween()' extension method on the `string` type
  public static string SubstringBetween(this string str, string firstDelimeter, string secondDelimeter)
  {
    int start = str.IndexOf(firstDelimeter) + firstDelimeter.Length;
    int end = str.IndexOf(secondDelimeter, start) - start;

    return str.Substring(start, end);
  }
  // TODO: define the 'Message()' extension method on the `string` type
  public static string Message(this string str)
  {
    return str.SubstringAfter(":").Trim();
  }
  // TODO: define the 'LogLevel()' extension method on the `string` type
  public static string LogLevel(this string str)
  {
    return str.SubstringBetween("[", "]");
  }
}
