class NeedForSpeed {
  private int totalBattery = 100;
  private int totalDistance = 0;
  private final int batteryDrain;
  private final int speed;

  NeedForSpeed(int speed, int batteryDrain) {
    this.speed = speed;
    this.batteryDrain = batteryDrain;
  }

  public boolean batteryDrained() {
    return totalBattery < batteryDrain;
  }

  public int distanceDriven() {
    return totalDistance;
  }

  public void drive() {
    if (this.batteryDrained())
      return;
    totalBattery -= batteryDrain;
    totalDistance += speed;
  }

  public static NeedForSpeed nitro() {
    return new NeedForSpeed(50, 4);
  }
}

class RaceTrack {
  private int distance;

  RaceTrack(int distance) {
    this.distance = distance;
  }

  public boolean canFinishRace(NeedForSpeed car) {
    while (!car.batteryDrained())
      car.drive();
    return car.distanceDriven() >= this.distance;
  }
}
