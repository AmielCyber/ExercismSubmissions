public enum Schedule
{
    First = 0,
    Second = 1,
    Third = 2,
    Fourth = 3,
    Last,
    Teenth,
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime firstDayOfWeek = GetFirstDayOfWeekOfMonth(dayOfWeek);
        return GetDaySchedule(schedule, firstDayOfWeek);
    }

    private DateTime GetFirstDayOfWeekOfMonth(DayOfWeek dayOfWeek)
    {
        DateTime date = new DateTime(_year, _month, 1);
        while(date.DayOfWeek != dayOfWeek)
            date = date.AddDays(1);
        return date;
    }

    private DateTime GetDaySchedule(Schedule schedule, DateTime date)
    {
        if (schedule == Schedule.Last)
            return GetLastDayOfWeekOfMonth(date);
        if(schedule == Schedule.Teenth)
            return GetTeenthDayOfWeekOfMonth(date); 

        int weeksToSkipTo = (int)schedule;
        for (int i = 0; i < weeksToSkipTo; i++)
            date = date.AddDays(7);

        return date;
    }

    private DateTime GetLastDayOfWeekOfMonth(DateTime date)
    {
        DateTime nextWeek = date.AddDays(7);
        while (date.Month == nextWeek.Month)
        {
            date = nextWeek;
            nextWeek = date.AddDays(7);
        }
        return date;
    }

    private DateTime GetTeenthDayOfWeekOfMonth(DateTime date)
    {
        while (date.Day < 13)
            date = date.AddDays(7);
        return date;
    }
}

