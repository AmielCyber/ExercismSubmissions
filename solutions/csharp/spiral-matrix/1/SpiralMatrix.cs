using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int currentNum = 1;
        int[,] matrix = new int[size, size];
        int mid = size / 2;
        for (int ringNum = 0; ringNum < mid; ringNum++)
        {
            currentNum = FillTopRing(currentNum, ringNum, matrix);
            currentNum = FillRightRing(currentNum, ringNum, matrix);
            currentNum = FillBottomRing(currentNum, ringNum, matrix);
            currentNum = FillLeftRing(currentNum, ringNum, matrix);
        }

        if (size % 2 != 0)
        {
            FillMiddleRing(currentNum, matrix);
        }
        return matrix;
    }

    private static int FillTopRing(int currentNum, int ringNum, int[,] m)
    {
        int row = ringNum;  // Row remains static.
        // Left to right.
        for (int col = row; col < m.GetLength(0) - ringNum - 1; col++)
        {
            m[row, col] = currentNum;
            currentNum++;
        }
        return currentNum;
    }

    private static int FillRightRing(int currentNum, int ringNum, int[,] m)
    {
        int col = m.GetLength(0) - ringNum - 1;   // Column remains static.
        // Top to bottom.
        for (int row = ringNum; row < col; row++)
        {
            m[row, col] = currentNum;
            currentNum++;
        }
        return currentNum;
    }

    private static int FillBottomRing(int currentNum, int ringNum, int[,] m)
    {
        int row = m.GetLength(0) - ringNum - 1;   // Row remains static.
        // Right to left.
        for (int col = row; col > ringNum; col--)
        {
            m[row, col] = currentNum;
            currentNum++;
        }
        return currentNum;
    }

    private static int FillLeftRing(int currentNum, int ringNum, int[,] m)
    {
        int col = ringNum;  // Column remains static.
        // Bottom to top.
        for (int row = m.GetLength(0) - ringNum - 1; row > ringNum; row--)
        {
            m[row, col] = currentNum;
            currentNum++;
        }
        return currentNum;
    }

    private static void FillMiddleRing(int currentNum, int[,] m)
    {
        int row = (int)Math.Ceiling((double)(m.GetLength(0) / 2));
        int col = row;
        m[row, col] = currentNum;
    }
}
