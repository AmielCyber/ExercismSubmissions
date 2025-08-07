using System;
public static class Darts
{
    private static readonly int _innerCircleRadius = 1;
    private static readonly int _middleCircleRadius = 5;
    private static readonly int _outerCircleRadius = 10;

    private static readonly int _innerPoints = 10;
    private static readonly int _middlePoints = 5;
    private static readonly int _outerPoints = 1;
    private static readonly int _outsidePoints = 0;

    private static double GetRadius(double x, double y)
    {
        return Math.Sqrt(x * x + y * y);
    }

    private static bool IsInnerCircle(double radius)
    {
        return radius <= _innerCircleRadius;
    }

    private static bool IsMiddleCircle(double radius)
    {
        return radius <= _middleCircleRadius;
    }

    private static bool IsOuterCircle(double radius)
    {
        return radius <= _outerCircleRadius;
    }

    public static int Score(double x, double y)
    {
        double radius = GetRadius(x, y);
        if (IsInnerCircle(radius))
        {
            return _innerPoints;
        }
        if (IsMiddleCircle(radius))
        {
            return _middlePoints;
        }
        if (IsOuterCircle(radius))
        {
            return _outerPoints;
        }
        return _outsidePoints;
    }
}
