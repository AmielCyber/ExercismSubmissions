using System;

public static class BinarySearch
{
    private static bool IsWithinBounds<T>(int left, int right, T[] arr) => left >= 0 && right < arr.Length;

    public static int Find(int[] input, int value)
    {
        int left = 0;
        int right = input.Length - 1;

        while (left <= right && IsWithinBounds<int>(left, right, input))
        {
            int mid = (left + right) / 2;

            if (value == input[mid])
            {
                return mid;
            }
            else if (value > input[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}
