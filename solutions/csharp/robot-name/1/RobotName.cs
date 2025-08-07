using System;
using System.Collections.Generic;

public class Robot
{
    private string _name = RobotName.GenerateUniqueName();

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public void Reset()
    {
        RobotName.RemoveName(_name);
        _name = RobotName.GenerateUniqueName();
    }
}
public class RobotName
{
    private static Random RandomGenerator = new Random();
    private static HashSet<string> Names = new HashSet<string>();
    private static string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static string Digits = "0123456789";
    private static int NumberOfLetters = 2;
    private static int NumberOfDigits = 3;

    public static string GenerateRandomName()
    {
        int length = NumberOfLetters + NumberOfDigits;
        char[] name = new char[length];

        for (int i = 0; i < length; i++)
        {
            if (i < NumberOfLetters)
            {
                name[i] = Letters[RandomGenerator.Next(Letters.Length)];
            }
            else
            {
                name[i] = Digits[RandomGenerator.Next(Digits.Length)];
            }
        }

        return new string(name);
    }

    public static void RemoveName(string name)
    {
        if (Names.Contains(name))
        {
            Names.Remove(name);
        }
    }

    public static string GenerateUniqueName()
    {
        string name = GenerateRandomName();
        return Names.Add(name) ? name : GenerateUniqueName();
    }
}
