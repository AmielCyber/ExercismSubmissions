class RemoteControlCar
{
  private const int _metersPerDrive = 20;
  private const int _batteryDrainagePerDrive = 1;

  private int _metersDriven = 0;
  private int _batteryPercentage = 100;

  public static RemoteControlCar Buy()
  {
    return new RemoteControlCar();
  }

  public string DistanceDisplay()
  {
    return $"Driven {_metersDriven} meters";
  }

  public string BatteryDisplay()
  {
    if (_batteryPercentage > 0) return $"Battery at {_batteryPercentage}%";

    return "Battery empty";
  }

  public void Drive()
  {
    if (_batteryPercentage > 0)
    {
      _metersDriven += _metersPerDrive;
      _batteryPercentage -= _batteryDrainagePerDrive;
    }
  }
}
