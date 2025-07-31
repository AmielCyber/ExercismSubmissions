class Lasagna
{
    private const int EXPECTED_MINS_IN_OVEN = 40;
    private const int LAYER_PREPARATION_TIME = 2;

    public int ExpectedMinutesInOven() => EXPECTED_MINS_IN_OVEN;

    public int RemainingMinutesInOven(int minLapse)
    {
        var remainingMins = EXPECTED_MINS_IN_OVEN - minLapse;
        return remainingMins > 0 ? remainingMins : 0;
    }

    public int PreparationTimeInMinutes(int layers) =>
        layers < 1 ? 0 : LAYER_PREPARATION_TIME * layers;

    public int ElapsedTimeInMinutes(int layers, int minsInOven) =>
        minsInOven + PreparationTimeInMinutes(layers);
}
