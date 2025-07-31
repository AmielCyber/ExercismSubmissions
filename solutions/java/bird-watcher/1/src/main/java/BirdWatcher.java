
class BirdWatcher {
  private final int[] birdsPerDay;
  private final int birdsInBusyDay = 5;

  public BirdWatcher(int[] birdsPerDay) {
    this.birdsPerDay = birdsPerDay.clone();
  }

  public int[] getLastWeek() {
    return new int[] { 0, 2, 5, 3, 7, 8, 4 };
  }

  public int getToday() {
    return birdsPerDay.length > 0 ? birdsPerDay[birdsPerDay.length - 1] : 0;
  }

  public void incrementTodaysCount() {
    if (birdsPerDay.length > 0) {
      birdsPerDay[birdsPerDay.length - 1]++;
    }
  }

  public boolean hasDayWithoutBirds() {
    for (int birds : birdsPerDay) {
      if (birds == 0)
        return true;
    }
    return false;
  }

  public int getCountForFirstDays(int numberOfDays) {
    int count = 0;
    if (numberOfDays >= birdsPerDay.length)
      numberOfDays = birdsPerDay.length;
    for (int i = 0; i < numberOfDays; i++) {
      count += birdsPerDay[i];
    }
    return count;
  }

  public int getBusyDays() {
    int count = 0;
    for (int birds : birdsPerDay) {
      if (birds >= birdsInBusyDay)
        count++;
    }
    return count;
  }
}
