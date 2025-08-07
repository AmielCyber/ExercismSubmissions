using System.Collections.Generic;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        HashSet<(int, int)> largestRowPositions = GetLargestRowPositions(matrix);
        HashSet<(int, int)> smallestColumnPositions = GetSmallestColumnPositions(matrix);

        return GetIdealPositions(largestRowPositions, smallestColumnPositions);
    }

    private static HashSet<(int, int)> GetLargestRowPositions(int[,] matrix)
    {
        HashSet<(int, int)> largestRowPositions = new();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int largest = int.MinValue;
            List<(int, int)> largestPositions = new();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] > largest)
                {
                    largest = matrix[row, col];
                    largestPositions.Clear();
                    largestPositions.Add((row + 1, col + 1));
                }
                else if (matrix[row, col] == largest)
                {
                    largestPositions.Add((row + 1, col + 1));
                }
            }
            largestRowPositions.UnionWith(largestPositions);
        }

        return largestRowPositions;
    }

    private static HashSet<(int, int)> GetSmallestColumnPositions(int[,] matrix)
    {
        HashSet<(int, int)> smallestColumnPositions = new();
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            int smallest = int.MaxValue;
            List<(int, int)> smallestPositions = new();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] < smallest)
                {
                    smallest = matrix[row, col];
                    smallestPositions.Clear();
                    smallestPositions.Add((row + 1, col + 1));
                }
                else if (matrix[row, col] == smallest)
                {
                    smallestPositions.Add((row + 1, col + 1));
                }
            }
            smallestColumnPositions.UnionWith(smallestPositions);
        }

        return smallestColumnPositions;
    }

    private static List<(int, int)> GetIdealPositions(HashSet<(int, int)> largestRowPositions, HashSet<(int, int)> smallestColumnPositions)
    {
        List<(int, int)> idealPositions = new();

        foreach ((int, int) pos in largestRowPositions)
            if (smallestColumnPositions.Contains(pos))
                idealPositions.Add(pos);

        return idealPositions;
    }

}
