public class Matrix
{
    private int[][] _matrix;

    public Matrix(string input)
    {
        string[] rows = input.Split("\n");
        _matrix = new int[rows.Length][];
        for (int i = 0; i < rows.Length; i++)
        {
            string[] nums = rows[i].Split(" ");
            _matrix[i] = new int[nums.Length];
            for (int j = 0; j < nums.Length; j++)
            {
                int.TryParse(nums[j], out int num);
                _matrix[i][j] = num;
            }
        }
    }

    public int[] Row(int row) => _matrix[row - 1];

    public int[] Column(int col)
    {
        int[] column = new int[_matrix.Length];
        for (int i = 0; i < column.Length; i++)
            column[i] = _matrix[i][col - 1];
        return column;
    }
}
