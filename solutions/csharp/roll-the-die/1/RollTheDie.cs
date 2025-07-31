using System;

public class Player
{
  private const int MaxDieValue = 18;
  private const int MaxSpellStrength = 100;
  private readonly Random _random = new Random();

  public int RollDie()
  {
    return _random.Next(MaxDieValue) + 1;
  }

  public double GenerateSpellStrength()
  {
    return _random.NextDouble() + _random.Next(MaxSpellStrength);
  }
}
