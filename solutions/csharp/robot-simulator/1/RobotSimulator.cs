using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    private const char TURN_RIGHT = 'R';
    private const char TURN_LEFT = 'L';
    private const char AHEAD = 'A';

    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public void Move(string instructions)
    {
        foreach (char instruction in instructions)
        {
            if (instruction == AHEAD)
                MoveAhead();
            else
                Turn(instruction);
        }
    }

    private void MoveAhead()
    {
        switch (this.Direction)
        {
            case Direction.North:
                Y += 1;
                break;
            case Direction.South:
                Y -= 1;
                break;
            case Direction.West:
                X -= 1;
                break;
            case Direction.East:
                X += 1;
                break;
            default:
                throw new Exception($"Oops that is not supposed to happen in {nameof(MoveAhead)} method.");
        }
    }
    private void Turn(char direction)
    {
        switch (this.Direction)
        {
            case Direction.North:
                this.Direction = direction == TURN_RIGHT ? Direction.East : Direction.West;
                break;
            case Direction.South:
                this.Direction = direction == TURN_RIGHT ? Direction.West : Direction.East;
                break;
            case Direction.West:
                this.Direction = direction == TURN_RIGHT ? Direction.North : Direction.South;
                break;
            case Direction.East:
                this.Direction = direction == TURN_RIGHT ? Direction.South : Direction.North;
                break;
            default:
                throw new Exception($"Oops that is not supposed to happen in {nameof(Turn)} method.");
        }
    }
}
