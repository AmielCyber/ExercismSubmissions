using System;

public static class Gigasecond
{
    private const double GigaSecond = 1E9;

    public static DateTime Add(DateTime moment)
    {
        return moment.AddSeconds(GigaSecond);

    }
}
