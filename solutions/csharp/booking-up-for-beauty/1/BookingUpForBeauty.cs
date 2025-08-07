using System;
using System.Globalization;

static class Appointment
{
  private static CultureInfo _cultureInfo = new CultureInfo("en-US");

  public static DateTime Schedule(string appointmentDateDescription)
  {
    return DateTime.Parse(appointmentDateDescription, _cultureInfo);
  }

  public static bool HasPassed(DateTime appointmentDate)
  {
    return DateTime.Compare(appointmentDate, DateTime.Now) < 0;
  }

  public static bool IsAfternoonAppointment(DateTime appointmentDate)
  {
    return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
  }

  public static string Description(DateTime appointmentDate)
  {
    return $"You have an appointment on {appointmentDate.ToString(_cultureInfo)}.";
  }

  public static DateTime AnniversaryDate()
  {
    return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
  }
}
