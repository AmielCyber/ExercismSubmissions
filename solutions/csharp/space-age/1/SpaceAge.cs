public class SpaceAge
{
    private int _ageInSeconds;

    private readonly double _earthYearInSeconds = 31557600;

    private readonly double _earthYears = 1;
    private readonly double _mercuryEarthYears = 0.2408467;
    private readonly double _venusEarthYears = 0.615179726;
    private readonly double _marsEarthYears = 1.8808185;
    private readonly double _jupiterEarthYears = 11.862615;
    private readonly double _saturnEarthYears = 29.447498;
    private readonly double _uranusEarthYears = 84.016846;
    private readonly double _neptuneEarthYears = 164.79132;


    public SpaceAge(int seconds)
    {
        _ageInSeconds = seconds;
    }

    private double GetPlanetYears(double planetEarthYears)
    {
        return _ageInSeconds / (planetEarthYears * _earthYearInSeconds);
    }

    public double OnEarth()
    {
        return GetPlanetYears(_earthYears);
    }

    public double OnMercury()
    {
        return GetPlanetYears(_mercuryEarthYears);
    }

    public double OnVenus()
    {
        return GetPlanetYears(_venusEarthYears);
    }

    public double OnMars()
    {
        return GetPlanetYears(_marsEarthYears);
    }

    public double OnJupiter()
    {
        return GetPlanetYears(_jupiterEarthYears);
    }

    public double OnSaturn()
    {
        return GetPlanetYears(_saturnEarthYears);
    }

    public double OnUranus()
    {
        return GetPlanetYears(_uranusEarthYears);
    }

    public double OnNeptune()
    {
        return GetPlanetYears(_neptuneEarthYears);
    }
}
