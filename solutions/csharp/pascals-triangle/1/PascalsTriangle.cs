public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var result = new List<List<int>>();
        for (int i = 0; i < rows; i++)
        {
            List<int> row = new();
            for (int j = 0; j <= i; j++)
            {
                int left = IsOutOfRange(i - 1, j - 1, result) ? 0 : result[i - 1][j - 1];
                int right = IsOutOfRange(i - 1, j, result) ? 0 : result[i - 1][j];
                int addition = left + right;

                if (addition == 0) addition = 1;
                row.Add(addition);
            }
            result.Add(row);
        }
        return result;
    }

    private static bool IsOutOfRange(int row, int col, List<List<int>> list)
        => row < 0 || col < 0 || row >= list.Count || col >= list[row].Count;

}
