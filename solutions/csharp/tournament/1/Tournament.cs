public static class Tournament
{
    private const int TeamAlignment = -30;
    private const int Team1Index = 0;
    private const int Team2Index = 1;
    private const int Team1WinResultIndex = 2;

    public static void Tally(Stream inStream, Stream outStream)
    {
        List<Team> teamTally = GetTeamTallyList(inStream);
        SortTeamTallyList(teamTally);

        using TextWriter writer = new StreamWriter(outStream);
        writer.Write($"{"Team", TeamAlignment} | MP |  W |  D |  L |  P");
        foreach (Team team in teamTally)
        {
            writer.Write('\n');
            writer.Write(
                $"{team.Name, TeamAlignment} | {team.Matches, 2} | {team.Wins, 2} | {team.Draws, 2} | {team.Losses, 2} | {team.Points, 2}"
            );
        }
    }

    private static List<Team> GetTeamTallyList(Stream inStream)
    {
        List<Team> list = new();
        using TextReader reader = new StreamReader(inStream);
        string? line = reader.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            string[] game = line.Split(";");
            if (game.Length < 3)
                throw new ArgumentException(
                    "Invalid inStream. Format must be: 'team1;team2;team1WinResult"
                );

            Team team1 = list.FirstOrDefault(
                t => t.Name.Contains(game[Team1Index]),
                new Team(game[Team1Index])
            );
            if (team1.Matches == 0)
                list.Add(team1);

            Team team2 = list.FirstOrDefault(
                t => t.Name.Contains(game[Team2Index]),
                new Team(game[Team2Index])
            );
            if (team2.Matches == 0)
                list.Add(team2);

            Team.SetGameResult(team1, team2, game[Team1WinResultIndex]);
            line = reader.ReadLine();
        }

        return list;
    }

    private static void SortTeamTallyList(List<Team> teamTally) =>
        teamTally.Sort(
            (a, b) =>
            {
                int result = b.Points - a.Points;
                if (result == 0)
                    result = string.Compare(a.Name, b.Name, StringComparison.Ordinal);
                return result;
            }
        );

    private class Team
    {
        public string Name { get; }
        public int Matches { get; private set; }
        public int Wins { get; private set; }
        public int Draws { get; private set; }
        public int Losses { get; private set; }
        public int Points { get; private set; }

        public Team(string name) => Name = name;

        private void AddWin()
        {
            Matches++;
            Wins++;
            Points += 3;
        }

        private void AddDraw()
        {
            Matches++;
            Draws++;
            Points += 1;
        }

        private void AddLoss()
        {
            Matches++;
            Losses++;
        }

        public static void SetGameResult(Team team1, Team team2, string team1WinResult)
        {
            switch (team1WinResult)
            {
                case "win":
                    team1.AddWin();
                    team2.AddLoss();
                    break;
                case "loss":
                    team1.AddLoss();
                    team2.AddWin();
                    break;
                case "draw":
                    team1.AddDraw();
                    team2.AddDraw();
                    break;
            }
        }
    }
}