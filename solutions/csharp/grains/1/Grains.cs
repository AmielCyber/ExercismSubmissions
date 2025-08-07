public static class Grains
{
    private const ulong StartingBit = (ulong)1;
    private const int MinSquareNum = 1;
    private const int MaxSquareNum = 64;

    public static ulong Square(int n) =>
        IsWithinRange(n) ? StartingBit << (n - 1) : throw new ArgumentOutOfRangeException();

    public static ulong Total() => ulong.MaxValue;

    private static bool IsWithinRange(int n) => n >= MinSquareNum && n <= MaxSquareNum;
}
