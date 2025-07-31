using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) =>
        TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), GetTimeZoneInfo(location));

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentException()
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) =>
        GetTimeZoneInfo(location).IsDaylightSavingTime(dt) != GetTimeZoneInfo(location).IsDaylightSavingTime(dt.AddDays(-7));

    public static DateTime NormalizeDateTime(string dtStr, Location location) =>
        DateTime.TryParse(dtStr, GetCultureInfo(location), out DateTime date) ? date : new DateTime(1, 1, 1);

    private static TimeZoneInfo GetTimeZoneInfo(Location location) =>
        TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));

    private static string GetTimeZoneId(Location location) =>
        OperatingSystem.IsWindows() ? GetWindowsTimeZoneId(location) : GetUnixTimeZoneId(location);

    private static string GetWindowsTimeZoneId(Location location) =>
        location switch
        {
            Location.NewYork => "Eastern Standard Time",
            Location.London => "GMT Standard Time",
            Location.Paris => "W. Europe Standard Time",
            _ => throw new ArgumentException()
        };

    private static string GetUnixTimeZoneId(Location location) =>
        location switch
        {
            Location.NewYork => "America/New_York",
            Location.London => "Europe/London",
            Location.Paris => "Europe/Paris",
            _ => throw new ArgumentException()
        };

    private static IFormatProvider GetCultureInfo(Location location) => new CultureInfo(GetCultureId(location));

    private static string GetCultureId(Location location) =>
        location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentException()
        };


}
