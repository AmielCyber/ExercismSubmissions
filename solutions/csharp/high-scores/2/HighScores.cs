using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> _scores;

    public HighScores(List<int> list)
    {
        _scores = new List<int>(list);
    }

    public List<int> Scores() => new List<int>(_scores);

    public int Latest() => _scores.Last();

    public int PersonalBest() => _scores.Max();

    public List<int> PersonalTopThree() => _scores.OrderDescending().Take(3).ToList();
}
