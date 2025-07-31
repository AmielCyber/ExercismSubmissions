using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) => CanAttackAcross(white, black) || CanAttackDiagonal(white, black);

    private static bool CanAttackAcross(Queen white, Queen black) => white.Row == black.Row || white.Column == black.Column;
    private static bool CanAttackDiagonal(Queen white, Queen black) => Math.Abs(white.Row - black.Row) == Math.Abs(white.Column - black.Column);

    public static Queen Create(int row, int column)
    {
        if (row > 7 || row < 0)
            throw new ArgumentOutOfRangeException(nameof(row));
        if (column > 7 || column < 0)
            throw new ArgumentOutOfRangeException(nameof(column));
        return new Queen(row, column);
    }
}
