using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public ushort X { get; }
    public ushort Y { get; }

    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }
}

public struct Plot : IComparable<Plot>
{
    public Coord Coord1;
    public Coord Coord2;
    public Coord Coord3;
    public Coord Coord4;
    public readonly int MaxDistanceSquared;

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;
        MaxDistanceSquared = GetMaxDistanceSquared();
    }

    public int CompareTo(Plot other) => MaxDistanceSquared - other.MaxDistanceSquared;

    // c1 - c2
    //  | X |
    // c3 - c4
    private int GetMaxDistanceSquared() =>
        Math.Max(
            Math.Max(
                Math.Max(GetDistanceSquared(Coord1, Coord2), GetDistanceSquared(Coord2, Coord4)),
                Math.Max(GetDistanceSquared(Coord4, Coord3), GetDistanceSquared(Coord3, Coord1))
            ),
            Math.Max(GetDistanceSquared(Coord1, Coord4), GetDistanceSquared(Coord2, Coord4))
        );

    private int GetDistanceSquared(Coord coord1, Coord coord2) =>
        (int)(Math.Pow((coord2.X - coord1.X), 2) + Math.Pow(coord1.Y - coord2.Y, 2));
}

public class ClaimsHandler
{
    private readonly Stack<Plot> _stakeClaims = new();

    public void StakeClaim(Plot plot) => _stakeClaims.Push(plot);

    public bool IsClaimStaked(Plot plot) => _stakeClaims.Contains(plot);

    public bool IsLastClaim(Plot plot) => plot.Equals(_stakeClaims.Peek());

    public Plot GetClaimWithLongestSide() => _stakeClaims.Max();
}
