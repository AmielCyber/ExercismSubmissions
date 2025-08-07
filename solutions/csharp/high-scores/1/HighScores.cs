using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> _scores;
    private List<int> _scoresByDescendingOrder;

    public HighScores(List<int> list)
    {
        _scores = new List<int>(list);
        _scoresByDescendingOrder = GetScoreListByDescOrder(list);
    }

    public List<int> Scores()
    {
        return _scores;
    }

    public int Latest()
    {
        return _scores[_scores.Count - 1];
    }

    public int PersonalBest()
    {
        return _scoresByDescendingOrder[0];
    }

    public List<int> PersonalTopThree()
    {
        return _scoresByDescendingOrder.Take(3).ToList();
    }
    private List<int> GetScoreListByDescOrder(List<int> scores)
    {
        int[] scoresByDescOrder = scores.ToArray();
        Array.Sort(scoresByDescOrder);
        Array.Reverse(scoresByDescOrder);
        return new List<int>(scoresByDescOrder);
    }
}
