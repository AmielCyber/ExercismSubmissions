using System.Collections.Generic;

public class WordSearch
{
    private char[,] _grid { get; init; }
    private int _rows { get; init; }
    private int _cols { get; init; }
    private (int, int) _notFound = (-1, -1);

    public WordSearch(string grid)
    {
        string[] lines = grid.Split("\n");
        _rows = lines.Length;
        _cols = lines[0].Length;
        _grid = new char[_rows, _cols];

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                _grid[i, j] = lines[i][j];
            }
        }
    }
    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        Dictionary<string, ((int, int), (int, int))?> coords = new();

        foreach (string word in wordsToSearchFor)
        {
            coords.Add(word, null);
        }

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                foreach (string word in wordsToSearchFor)
                {
                    (int, int) coordinate = SearchGrid(i, j, word);
                    if (coordinate != _notFound)
                    {
                        coords[word] = ((j + 1, i + 1), (coordinate));
                    }
                }
            }
        }
        return coords;
    }
    private (int x, int y) SearchGrid(int startingRow, int startingCol, string word)
    {
        (int, int) coords = _notFound;

        coords = ContainsWordToTheRight(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        coords = ContainsWordDownwardRightDiagonal(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        coords = ContainsWordToTheBottom(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        coords = ContainsWordDownwardLeftDiagonal(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        coords = ContainsWordToTheLeft(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        coords = ContainsWordUpperLeftDiagonal(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        coords = ContainsWordToTheTop(startingRow, startingCol, 0, word);
        if (coords != _notFound)
            return coords;

        return ContainsWordUpperRightDiagonal(startingRow, startingCol, 0, word);
    }
    private (int, int) ContainsWordToTheRight(int row, int col, int startIndex, string word)
    {
        if (col >= _cols || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordToTheRight(row, col + 1, startIndex + 1, word);
    }
    private (int, int) ContainsWordToTheLeft(int row, int col, int startIndex, string word)
    {
        if (col < 0 || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordToTheLeft(row, col - 1, startIndex + 1, word);
    }
    private (int, int) ContainsWordToTheTop(int row, int col, int startIndex, string word)
    {
        if (row < 0 || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordToTheTop(row - 1, col, startIndex + 1, word);
    }
    private (int, int) ContainsWordToTheBottom(int row, int col, int startIndex, string word)
    {
        if (row >= _rows || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordToTheBottom(row + 1, col, startIndex + 1, word);
    }
    private (int, int) ContainsWordUpperRightDiagonal(int row, int col, int startIndex, string word)
    {
        if (row < 0 || col >= _cols || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordUpperRightDiagonal(row - 1, col + 1, startIndex + 1, word);
    }
    private (int, int) ContainsWordUpperLeftDiagonal(int row, int col, int startIndex, string word)
    {
        if (row < 0 || col < 0 || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordUpperLeftDiagonal(row - 1, col - 1, startIndex + 1, word);
    }
    private (int, int) ContainsWordDownwardLeftDiagonal(int row, int col, int startIndex, string word)
    {
        if (row >= _rows || col < 0 || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordDownwardLeftDiagonal(row + 1, col - 1, startIndex + 1, word);
    }
    private (int, int) ContainsWordDownwardRightDiagonal(int row, int col, int startIndex, string word)
    {
        if (row >= _rows || col >= _cols || startIndex >= word.Length || _grid[row, col] != word[startIndex])
            return _notFound;
        if (startIndex == word.Length - 1)
            return _grid[row, col] == word[startIndex] ? (col + 1, row + 1) : _notFound;
        return ContainsWordDownwardRightDiagonal(row + 1, col + 1, startIndex + 1, word);
    }
}
