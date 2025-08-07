using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static string GetManagerInfo(Manager manager)
    {
        string club = manager.Club is null ? "" : $" ({manager.Club})";

        return manager.Name + club;
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int i:
                return $"There are {report} supporters at the match.";
            case string s:
                return s;
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager:
                return GetManagerInfo(manager);
            default:
                throw new ArgumentException();
        }
    }
}
