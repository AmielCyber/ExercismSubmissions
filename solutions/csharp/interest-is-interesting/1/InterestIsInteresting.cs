static class SavingsAccount
{
  private static float NegativeBalanceInterestRate = 3.213f;
  private static float LowBalanceInterestRate = 0.5f;
  private static float MediumBalanceInterestRate = 1.621f;
  private static float HighBalanceInterestRate = 2.475f;

  private static int NoBalance = 0;
  private static int LowBalance = 1000;
  private static int HighBalance = 5000;

  public static float InterestRate(decimal balance)
  {
    if (balance < NoBalance) return NegativeBalanceInterestRate;
    if (balance < LowBalance) return LowBalanceInterestRate;
    if (balance < HighBalance) return MediumBalanceInterestRate;

    return HighBalanceInterestRate;
  }

  public static decimal Interest(decimal balance)
  {
    return balance * (decimal)(InterestRate(balance) / 100);
  }

  public static decimal AnnualBalanceUpdate(decimal balance)
  {
    return balance + Interest(balance);
  }

  public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
  {
    int years = 0;
    while (balance < targetBalance)
    {
      balance = AnnualBalanceUpdate(balance);
      years++;
    }

    return years;
  }
}
