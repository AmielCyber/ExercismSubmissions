using System.Text;
public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        var flowerCount = GetFlowerCount2DArray(input);
        CountAdjacentFlowers(flowerCount);
        return FlowerCountArrayToFlowerFieldStringArray(flowerCount);
    }


    private static int[][] GetFlowerCount2DArray(string[] input)
    {
        int[][] flowerCount = new int[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            flowerCount[i] = new int[input[i].Length];
            for (int j = 0; j < flowerCount[i].Length; j++)
            {
                if (input[i][j] == '*')
                    flowerCount[i][j] = -1;
            }
        }

        return flowerCount;
    }

    private static void CountAdjacentFlowers(int[][] flowerCount)
    {
        for (int i = 0; i < flowerCount.Length; i++)
        {
            for (int j = 0; j < flowerCount[i].Length; j++)
                if (flowerCount[i][j] == -1)
                    IncrementAdjacentNeighbors(flowerCount, i, j);
        }
    }

    private static string[] FlowerCountArrayToFlowerFieldStringArray(int[][] flowerCount)
    {
        string[] result = new string[flowerCount.Length];
        for (int i = 0; i < flowerCount.Length; i++)
        {
            StringBuilder str = new StringBuilder();
            for (int j = 0; j < flowerCount[i].Length; j++)
            {
                switch (flowerCount[i][j])
                {
                    case -1:
                        str.Append('*');
                        break;
                    case 0:
                        str.Append(' ');
                        break;
                    default:
                        str.Append(flowerCount[i][j]);
                        break;
                }
            }
            result[i] = str.ToString();
        }

        return result;
    }
    private static void IncrementAdjacentNeighbors(int[][] flowerCount, int row, int col)
    {
        int[][] rowCols = [[-1, 0], [-1, -1], [-1, 1], [1, -1], [0, -1], [1, 0], [0, 1], [1, 1]];
        foreach (int[] rc in rowCols)
        {
            int adjRow = rc[0] + row;
            int adjCol = rc[1] + col;
            if (IsInRange(adjRow, adjCol, flowerCount) && flowerCount[adjRow][adjCol] != -1)
                flowerCount[adjRow][adjCol]++;
        }

    }
    private static bool IsInRange(int row, int col, int[][] flowerCount) => row > -1 && row < flowerCount.Length && col > -1 && col < flowerCount[row].Length;

}
