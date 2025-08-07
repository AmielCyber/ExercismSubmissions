using System;
using System.Collections.Generic;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public enum Student
{
    Alice,
    Bob,
    Charlie,
    David,
    Eve,
    Fred,
    Ginny,
    Harriet,
    Ileana,
    Joseph,
    Kincaid,
    Larry
}

public class KindergartenGarden
{
    private string[] _gardenGrid;
    private const int BOX_SIZE = 2;

    public KindergartenGarden(string diagram)
    {
        _gardenGrid = diagram.Split("\n");
    }

    public IEnumerable<Plant> Plants(string student) => GetStudentPlants(GetStudentColumnNumber(student));

    private int GetStudentColumnNumber(string student)
    {
        foreach (Student s in Enum.GetValues(typeof(Student)))
        {
            if (student.Equals(s.ToString(), StringComparison.OrdinalIgnoreCase))
                return (int)s * 2;
        }
        throw new ArgumentException($"{student} not found!");
    }

    private Plant[] GetStudentPlants(int studentColumnNum)
    {
        Plant[] plants = new Plant[BOX_SIZE * BOX_SIZE];
        int index = 0;
        for (int row = 0; row < BOX_SIZE; row++)
        {
            for (int col = studentColumnNum; col < studentColumnNum + BOX_SIZE; col++)
            {
                plants[index] = (Plant)_gardenGrid[row][col];
                index++;
            }
        }
        return plants;
    }

}
