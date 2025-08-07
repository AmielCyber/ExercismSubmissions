class BirdCount
{
  private static int[] _lastWeekBirdsPerDay = new int[] { 0, 2, 5, 3, 7, 8, 4 };
  private int[] birdsPerDay;
  private const int _numOfBirdsInBusyDay = 5;

  public BirdCount(int[] birdsPerDay)
  {
    this.birdsPerDay = birdsPerDay;
  }

  public static int[] LastWeek()
  {
    return _lastWeekBirdsPerDay;
  }

  public int Today()
  {
    return birdsPerDay.Length > 0 ? birdsPerDay[birdsPerDay.Length - 1] : 0;
  }

  public void IncrementTodaysCount()
  {
    if (birdsPerDay.Length > 0)
    {
      birdsPerDay[birdsPerDay.Length - 1]++;
    }
    else
    {
      birdsPerDay = new int[] { 1 };
    }
  }

  public bool HasDayWithoutBirds()
  {
    foreach (int numOfBirds in birdsPerDay)
    {
      if (numOfBirds == 0) return true;
    }
    return false;
  }

  public int CountForFirstDays(int numberOfDays)
  {
    int count = 0;
    if (numberOfDays >= birdsPerDay.Length)
    {
      numberOfDays = birdsPerDay.Length - 1;
    }

    for (int i = 0; i < numberOfDays; i++)
    {
      count += birdsPerDay[i];
    }
    return count;
  }

  public int BusyDays()
  {
    int count = 0;

    foreach (int numOfBirds in birdsPerDay)
    {
      if (numOfBirds >= _numOfBirdsInBusyDay)
      {
        count++;
      }
    }
    return count;
  }
}
