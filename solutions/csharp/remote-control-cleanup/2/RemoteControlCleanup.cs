public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    public ITelemetry Telemetry { get; private set; }
    private Speed currentSpeed;

    public interface ITelemetry
    {
        public void Calibrate(RemoteControlCar remoteControlCar);
        public bool SelfTest();
        public void ShowSponsor(string sponsorName);
        public void SetSpeed(decimal amount, string unitsString);
    }

    public RemoteControlCar()
    {
        Telemetry = new _Telemetry(this);
        CurrentSponsor = string.Empty;
    }

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed) => currentSpeed = speed;

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond,
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }

    private class _Telemetry : ITelemetry
    {
        private readonly RemoteControlCar _parent;

        // TODO encapsulate the methods suffixed with "_Telemetry" in their own class
        // dropping the suffix from the method name
        public _Telemetry(RemoteControlCar remoteControlCar)
        {
            _parent = remoteControlCar;
        }

        public void Calibrate(RemoteControlCar remoteControlCar) { }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => _parent.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
                speedUnits = SpeedUnits.CentimetersPerSecond;

            _parent.SetSpeed(new Speed(amount, speedUnits));
        }
    }
}
