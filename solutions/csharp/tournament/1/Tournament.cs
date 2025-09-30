public class TeamInfo
{
    public int _Points;
    public int _Wins;
    public int _Draws;
    public int _Losses;

    public int MatchesPlayed => _Wins + _Draws + _Losses;

    public void increasePoints(int vIncreaseBy)
    {
        _Points += vIncreaseBy;
    }
    public void increaseWins()
    {
        _Wins++;
    }
    public void increaseLoss()
    {
        _Losses++;
    }
    public void increaseDraws()
    {
        _Draws++;
    }
}

public static class Tournament
{   
    static Dictionary<string, TeamInfo> xTeams = new Dictionary<string, TeamInfo>();
    public static void Tally(Stream inStream, Stream outStream)
{
    // Reset state so tests don’t bleed into each other
    xTeams.Clear();

    using (StreamReader xSR = new StreamReader(inStream))
    {
        while (xSR.Peek() >= 0)
        {
            string[] xLineParts = xSR.ReadLine().Split(";");
            string team1 = xLineParts[0];
            string team2 = xLineParts[1];
            string result = xLineParts[2];

            if (!xTeams.ContainsKey(team1))
                xTeams[team1] = new TeamInfo();
            if (!xTeams.ContainsKey(team2))
                xTeams[team2] = new TeamInfo();

            if (result == "win")
            {
                xTeams[team1].increaseWins();
                xTeams[team1].increasePoints(3);
                xTeams[team2].increaseLoss();
            }
            else if (result == "loss")
            {
                xTeams[team2].increaseWins();
                xTeams[team2].increasePoints(3);
                xTeams[team1].increaseLoss();
            }
            else if (result == "draw")
            {
                xTeams[team1].increaseDraws();
                xTeams[team2].increaseDraws();
                xTeams[team1].increasePoints(1);
                xTeams[team2].increasePoints(1);
            }
        }
    }

    var sortedTeams = xTeams
        .OrderByDescending(t => t.Value._Points)
        .ThenByDescending(t => t.Value._Wins)
        .ThenBy(t => t.Key);

   using (StreamWriter xSW = new StreamWriter(outStream))
{
    // Header
    xSW.Write("Team                           | MP |  W |  D |  L |  P");

    if (xTeams.Count > 0)
    {
        xSW.WriteLine();
        var teamLines = sortedTeams.Select(kvp =>
        {
            string team = kvp.Key;
            TeamInfo info = kvp.Value;
            return $"{team.PadRight(30)} | {info.MatchesPlayed,2} | {info._Wins,2} | {info._Draws,2} | {info._Losses,2} | {info._Points,2}";
        });

        // Join with \n instead of writing each with WriteLine()
        xSW.Write(string.Join("\n", teamLines));
    }
}
}
}
