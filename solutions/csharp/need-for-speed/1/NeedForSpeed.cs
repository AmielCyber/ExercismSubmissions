class RemoteControlCar
{
  private int _batteryPercentage = 100;
  private int _distanceDriven = 0;
  private int _batteryDrain;
  private int _speed;

  public RemoteControlCar(int speed, int batteryDrain)
  {
    // Guard against infinite loops.
    _speed = speed > 0 ? speed : 1;
    _batteryDrain = batteryDrain > 0 ? batteryDrain : 1;
  }

  public bool BatteryDrained()
  {
    return _batteryPercentage < _batteryDrain;
  }

  public int DistanceDriven()
  {
    return _distanceDriven;
  }

  public void Drive()
  {
    if (!BatteryDrained())
    {
      _batteryPercentage -= _batteryDrain;
      _distanceDriven += _speed;
    }
  }

  public static RemoteControlCar Nitro()
  {
    return new RemoteControlCar(50, 4);
  }
}

class RaceTrack
{
  private int _distance;

  public RaceTrack(int distance)
  {
    _distance = distance;
  }

  public bool TryFinishTrack(RemoteControlCar car)
  {
    while (!car.BatteryDrained())
    {
      car.Drive();
    }
    return car.DistanceDriven() >= _distance;
  }
}
