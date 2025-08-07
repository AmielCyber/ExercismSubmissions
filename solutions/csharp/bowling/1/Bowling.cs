using System;

public class BowlingGame
{
    private enum BowlingState
    {
        UnstartedGame,
        FirstThrow,
        SecondThrow,
        BonusThrow,
        GameOver,
    }
    private BowlingState _bowlingState = BowlingState.UnstartedGame;
    private readonly int[] _rolls = new int[21];
    private int _currentRoll = 0;
    private int _currentFrame = 0;
    private const int LastFrame = 9;

    public void Roll(int pins)
    {
        switch (_bowlingState)
        {
            case BowlingState.UnstartedGame:
                _bowlingState = BowlingState.FirstThrow;
                goto case BowlingState.FirstThrow;
            case BowlingState.FirstThrow:
                HandleFirstThrow(pins);
                break;
            case BowlingState.SecondThrow:
                HandleSecondThrow(pins);
                break;
            case BowlingState.BonusThrow:
                HandleBonusThrow(pins);
                break;
            case BowlingState.GameOver:
            default:
                throw new ArgumentException();
        }
    }

    public int? Score()
    {
        if (_bowlingState == BowlingState.UnstartedGame || _bowlingState != BowlingState.GameOver)
            throw new ArgumentException();
        int score = 0;
        int rollIndex = 0;
        for (int frame = 0; frame < 10; frame++)
        {
            if (IsStrike(rollIndex))
            {
                score += GetStrikePoints(rollIndex);
                rollIndex++;
            }
            else if (IsSpare(rollIndex))
            {
                score += GetSparePoints(rollIndex);
                rollIndex += 2;
            }
            else
            {
                score += GetOpenFramePoints(rollIndex);
                rollIndex += 2;
            }
        }

        return score;
    }

    private void HandleFirstThrow(int pins)
    {
        ValidatePins(pins);

        _rolls[_currentRoll] = pins;
        if (IsStrike(_currentRoll) && _currentFrame < LastFrame)
        {
            _bowlingState = BowlingState.FirstThrow;
            _currentFrame++;
        }
        else
        {
            _bowlingState = BowlingState.SecondThrow;
        }

        _currentRoll++;
    }

    private void HandleSecondThrow(int pins)
    {
        ValidatePins(pins);
        ValidatePinsInFrame(pins);
        _rolls[_currentRoll] = pins;

        if (_currentFrame == LastFrame)
        {
            if (IsStrike(_currentRoll - 1) || IsSpare(_currentRoll - 1))
                _bowlingState = BowlingState.BonusThrow;
            else
                _bowlingState = BowlingState.GameOver;
        }
        else
        {
            _bowlingState = BowlingState.FirstThrow;
            _currentFrame++;
        }

        _currentRoll++;
    }

    private void HandleBonusThrow(int pins)
    {
        ValidatePinsInBonusRoll(pins);
        _rolls[_currentRoll] = pins;
        _bowlingState = BowlingState.GameOver;
    }

    private void ValidatePins(int pins)
    {
        if (pins > 10 || pins < 0)
            throw new ArgumentException();
    }

    private void ValidatePinsInFrame(int pins)
    {
        if (_currentFrame == LastFrame && (IsStrike(_currentRoll - 1)))
            return;
        if ((_rolls[_currentRoll - 1] + pins) > 10)
            throw new ArgumentException();
    }

    private void ValidatePinsInBonusRoll(int pins)
    {
        ValidatePins(pins);
        if (!IsStrike(_currentRoll - 1) && !IsSpare(_currentRoll - 2))
            ValidatePinsInFrame(pins);
    }

    private bool IsStrike(int startingIndex) => _rolls[startingIndex] == 10;

    private int GetStrikePoints(int startingIndex) =>
        10 + _rolls[startingIndex + 1] + _rolls[startingIndex + 2];

    private bool IsSpare(int startingIndex) => (_rolls[startingIndex] + _rolls[startingIndex + 1]) == 10;

    private int GetSparePoints(int startingIndex) => 10 + _rolls[startingIndex + 2];

    private int GetOpenFramePoints(int startingIndex) => _rolls[startingIndex] + _rolls[startingIndex + 1];
}