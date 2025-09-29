public class HighScores
{
    private List<int> _LstHighScores;
    public HighScores(List<int> list)
    {
        _LstHighScores = list;
    }

    public List<int> Scores() => _LstHighScores;

    public int Latest() => _LstHighScores.LastOrDefault();

    public int PersonalBest() => _LstHighScores.Max();

    public List<int> PersonalTopThree() => _LstHighScores.OrderByDescending(x => x).Take(3).ToList();
}