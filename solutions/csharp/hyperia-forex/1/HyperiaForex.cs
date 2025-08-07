using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            left.amount == right.amount : throw new ArgumentException();

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            left.amount != right.amount : throw new ArgumentException();

    public static bool operator <(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            left.amount < right.amount : throw new ArgumentException();

    public static bool operator >(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            left.amount > right.amount : throw new ArgumentException();

    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            new CurrencyAmount(left.amount + right.amount, left.currency) : throw new ArgumentException();

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            new CurrencyAmount(left.amount - right.amount, left.currency) : throw new ArgumentException();

    public static CurrencyAmount operator *(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            new CurrencyAmount(left.amount * right.amount, left.currency) : throw new ArgumentException();

    public static CurrencyAmount operator /(CurrencyAmount left, CurrencyAmount right) =>
        HaveSameCurrency(left, right) ?
            new CurrencyAmount(left.amount / right.amount, left.currency) : throw new ArgumentException();

    public static explicit operator double(CurrencyAmount currencyAmount) =>
        (double)currencyAmount.amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount) => currencyAmount.amount;

    private static bool HaveSameCurrency(CurrencyAmount a, CurrencyAmount b) => a.currency == b.currency;
}
