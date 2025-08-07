public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) =>
        (
            IsNewYorkAreaCode(phoneNumber),
            IsFakePhoneNumber(phoneNumber),
            GetLocalPhoneNumber(phoneNumber)
        );

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) =>
        phoneNumberInfo.IsFake;

    private static bool IsNewYorkAreaCode(string phoneNumber) =>
        phoneNumber.Substring(0, 3) == "212";

    private static bool IsFakePhoneNumber(string phoneNumber) =>
        phoneNumber.Substring(4, 3) == "555";

    private static string GetLocalPhoneNumber(string phoneNumber) => phoneNumber.Substring(8);
}
