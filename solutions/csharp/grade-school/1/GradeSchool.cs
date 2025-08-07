using System;
using System.Linq;
using System.Collections.Generic;

public class Student : IComparable<Student>
{
    public string Name { get; init; }
    public int Grade { get; set; }

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }

    public int CompareTo(Student other) => Grade == other.Grade ?
        Name.CompareTo(other.Name) : Grade - other.Grade;
}

public class GradeSchool
{
    private List<Student> _roster = new();

    public bool Add(string student, int grade)
    {
        if (_roster.Exists(s => s.Name == student))
            return false;
        _roster.Add(new Student(student, grade));
        return true;
    }

    public IEnumerable<string> Roster() => _roster.OrderBy(s => s).Select(s => s.Name);

    public IEnumerable<string> Grade(int grade) =>
        _roster.Where(s => s.Grade == grade).OrderBy(s => s.Name).Select(s => s.Name);
}
