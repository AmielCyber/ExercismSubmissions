using System;

class WeighingMachine
{
    public int Precision { get; init; }
    private double _weight;
    public double Weight
    {
        get { return _weight; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than zero.");
            _weight = value;
        }
    }
    public double TareAdjustment { get; set; } = 5.0;
    public string DisplayWeight
    {
        get
        {
            return (Weight - TareAdjustment).ToString($"F{Precision}") + " kg";
        }
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
