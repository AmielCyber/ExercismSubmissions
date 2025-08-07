using System;
using System.Collections.Generic;
using System.Linq;

public enum Owner
{
    None,
    Black,
    White,
}

public class GoCounting
{
    private readonly string[] _board;
    private readonly int _rows;
    private readonly int _columns;

    public GoCounting(string input)
    {
        if (input.Length == 0)
            throw new ArgumentException("Empty board not permitted");
        _board = input.Split("\n");
        _rows = _board.Length;
        _columns = _board[0].Length;
    }

    public Tuple<Owner, HashSet<(int, int)>> Territory((int x, int y) coord) =>
        Territory(coord.y, coord.x, new HashSet<(int, int)>());

    private Tuple<Owner, HashSet<(int, int)>> Territory(
        int row,
        int col,
        HashSet<(int, int)> visited
    )
    {
        if (!IsValidCoordinates(row, col))
            throw new ArgumentException("Invalid coordinates.");

        HashSet<(int, int)> territories = new HashSet<(int, int)>();
        if (!IsTerritory(row, col))
            return new Tuple<Owner, HashSet<(int, int)>>(Owner.None, territories);

        HashSet<Owner> stonesSeen = new();
        ExploreTerritory(row, col, territories, stonesSeen, visited);
        Owner owner = GetOwnerFromStonesSeen(stonesSeen);

        return new Tuple<Owner, HashSet<(int, int)>>(owner, territories);
    }

    public Dictionary<Owner, HashSet<(int, int)>> Territories()
    {
        HashSet<(int, int)> visited = new();
        Dictionary<Owner, HashSet<(int, int)>> ownerTerritories = new()
        {
            { Owner.Black, new HashSet<(int, int)>() },
            { Owner.White, new HashSet<(int, int)>() },
            { Owner.None, new HashSet<(int, int)>() },
        };
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if (!visited.Contains((i, j)) && IsTerritory(i, j))
                {
                    Tuple<Owner, HashSet<(int, int)>> territory = Territory(i, j, visited);
                    ownerTerritories[territory.Item1].UnionWith(territory.Item2);
                }
            }
        }

        return ownerTerritories;
    }

    private void ExploreTerritory(
        int row,
        int col,
        HashSet<(int x, int y)> territories,
        HashSet<Owner> stonesSeen,
        HashSet<(int, int)> visited
    )
    {
        if (!IsValidCoordinates(row, col) || visited.Contains((row, col)))
            return;
        if (!IsTerritory(row, col))
        {
            stonesSeen.Add(GetOwner(row, col));
            return;
        }

        visited.Add((row, col));
        territories.Add((col, row)); // store as coords: {x,y}, col = x, row = y
        ExploreTerritory(row, col + 1, territories, stonesSeen, visited); // Visit Right
        ExploreTerritory(row - 1, col, territories, stonesSeen, visited); // Visit Above
        ExploreTerritory(row + 1, col, territories, stonesSeen, visited); // Visit Below
        ExploreTerritory(row, col - 1, territories, stonesSeen, visited); // Visit Left
    }

    private bool IsTerritory(int row, int col) => _board[row][col] == ' ';

    private bool IsValidCoordinates(int row, int col) =>
        row < _rows && row > -1 && col < _columns && col > -1;

    private Owner GetOwner(int row, int col) =>
        _board[row][col] switch
        {
            'W' => Owner.White,
            'B' => Owner.Black,
            _ => Owner.None,
        };

    private Owner GetOwnerFromStonesSeen(HashSet<Owner> stonesSeen) =>
        stonesSeen.Count == 1 ? stonesSeen.Single() : Owner.None;
}
