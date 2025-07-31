class Badge {
  public String print(Integer id, String name, String department) {
    return getBadgeFormat(id) + name + getDepartmantFormat(department);
  }

  private String getBadgeFormat(Integer id) {
    if (id == null)
      return "";
    return "[" + id + "] - ";
  }

  private String getDepartmantFormat(String department) {
    if (department == null)
      department = "OWNER";
    else
      department = department.toUpperCase();
    return " - " + department;
  }
}
