using System;

public class Clock : IEquatable<Clock>
{
    private readonly int _hours;
    private readonly int _minutes;

    public Clock(int hours, int minutes)
    {
        var totalMinutes = GetTotalMinutes(hours, minutes);
        _hours = GetNormalizedHours(totalMinutes);
        _minutes = GetNormalizedMinutes(totalMinutes);
        if (totalMinutes < 0 && _minutes == 0)
        {
            // Special case where we do not start back from 23:00
            _hours++;
        }
    }

    public Clock Add(int minutesToAdd) => new(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new(_hours, _minutes - minutesToSubtract);

    public bool Equals(Clock other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _hours == other._hours && _minutes == other._minutes;
    }

    public override string ToString() => $"{_hours:00}:{_minutes:00}";

    private int GetTotalMinutes(int hours, int minutes) => hours * 60 + minutes;

    private int GetNormalizedHours(int totalMinutes)
    {
        var hours = totalMinutes / 60;
        if (totalMinutes < 0)
        {
            return GetWrapHours(hours);
        }
        return hours % 24;
    }

    private int GetWrapHours(int hours) => hours % 24 + 23;

    private int GetNormalizedMinutes(int totalMinutes)
    {
        var minutes = totalMinutes % 60;
        if (minutes < 0)
        {
            minutes = 60 + minutes;
        }
        return minutes;
    }

}
