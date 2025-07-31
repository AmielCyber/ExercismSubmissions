using System.Collections.Generic;

// Without using LINQ
public static class Languages
{
  private static string _favoriteLanguage = "C#";
  private static List<string> _existingLanguages = new() { "C#", "Clojure", "Elm" };

  public static List<string> NewList()
  {
    return new List<string>();
  }

  public static List<string> GetExistingLanguages()
  {
    return _existingLanguages;
  }

  public static List<string> AddLanguage(List<string> languages, string language)
  {
    List<string> newLanguagesList = new List<string>(languages);
    newLanguagesList.Add(language);

    return newLanguagesList;
  }

  public static int CountLanguages(List<string> languages)
  {
    return languages.Count;
  }

  public static bool HasLanguage(List<string> languages, string language)
  {
    return languages.Contains(language);
  }

  public static List<string> ReverseList(List<string> languages)
  {
    List<string> reverseLanguages = new(languages);
    reverseLanguages.Reverse();

    return reverseLanguages;
  }

  public static bool IsExciting(List<string> languages)
  {
    if (languages.Count < 1) return false;

    return languages[0] == _favoriteLanguage || (languages.Count > 1 && languages[1] == _favoriteLanguage && languages.Count < 4);
  }

  public static List<string> RemoveLanguage(List<string> languages, string language)
  {
    List<string> filteredLanguages = new List<string>();
    foreach (string l in languages)
    {
      if (l != language)
      {
        filteredLanguages.Add(l);
      }
    }

    return filteredLanguages;
  }

  public static bool IsUnique(List<string> languages)
  {
    // N^2 method.
    for (int i = 0; i < languages.Count - 1; i++)
    {
      if (languages.LastIndexOf(languages[i]) != i)
      {
        return false;
      }
    }
    return true;
  }
}
