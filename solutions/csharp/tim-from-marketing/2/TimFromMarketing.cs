using System;

static class Badge
{
  private static string OWNER = "OWNER";

  private static string GetIdString(int? id)
  {
    return $"[{id}]";
  }

  private static string GetDepartment(string? department)
  {
    return department is null ? OWNER : department.ToUpper();
  }

  public static string Print(int? id, string name, string? department)
  {
    if (id is null)
    {
      return $"{name} - {GetDepartment(department)}";
    }
    return $"{GetIdString(id)} - {name} - {GetDepartment(department)}";
  }
}
