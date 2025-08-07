using System;

public class BankAccount
{
    private readonly object _locker = new object();
    private bool _openedAccount = false;
    private decimal _balance = 0m;

    public void Open() => _openedAccount = true;

    public void Close() => _openedAccount = false;

    public decimal Balance
    {
        get => _openedAccount ? _balance : throw new InvalidOperationException();
    }

    public void UpdateBalance(decimal change)
    {
        lock (_locker)
        {
            _balance += change;
        }
    }
}
