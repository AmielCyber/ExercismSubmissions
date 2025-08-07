using System;
using System.Text;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        StringBuilder stringBuilder = new();
        foreach (char ch in phoneNumber)
        {
            if (Char.IsDigit(ch))
                stringBuilder.Append(ch);
        }
        RemoveCountryCode(stringBuilder);

        string cleanPhoneNumber = stringBuilder.ToString();
        ValidatePhoneNumber(cleanPhoneNumber);

        return cleanPhoneNumber;
    }
    private static void RemoveCountryCode(StringBuilder stringBuilder)
    {
        if (stringBuilder.Length == 11)
        {
            if (stringBuilder[0] == '1')
                stringBuilder.Remove(0, 1);
            else
                throw new ArgumentException("Phone number can only contain 1 as its country code.");
        }
    }

    private static void ValidatePhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 10)
            throw new ArgumentException("Invalid number of digits entered.");

        int firstDigit = (int)Char.GetNumericValue(phoneNumber[0]);
        int secondDigit = (int)Char.GetNumericValue(phoneNumber[3]);

        if (N_DigitIsInvalid(firstDigit))
            throw new ArgumentException("First digit must be greater than 1.");
        if (N_DigitIsInvalid(secondDigit))
            throw new ArgumentException("Fourth digit must be greater than 1.");
    }

    private static bool N_DigitIsInvalid(int digit) => digit < 2;
}
