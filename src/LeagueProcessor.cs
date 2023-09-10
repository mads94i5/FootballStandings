public static class LeagueProcessor
{
    public static void ProcessLeague(string testData)
    {
        League league = CSVReader.ReadLeague(testData);
        CSVReader.ReadTeams(testData, league);
        AdjustPlacements(league);
        StandingsPrinter.PrintStandings(league);
        StandingsPrinter.DeleteStandings(testData);
        StandingsPrinter.SaveStandings(testData, league);
        ProcessRounds(testData, league);
    }
    private static void AdjustPlacements(League league)
    {
        league.Teams.Sort(new TeamComparer());
        int currentPosition = 1;

        for (int i = 0; i < league.Teams.Count; i++)
        {
            Team team = league.Teams[i];

            if (i > 0 && TeamComparer.AreTeamsEqual(league.Teams[i - 1], team))
            {
                team.Position = "-";
            }
            else
            {
                team.Position = currentPosition.ToString();
            }

            currentPosition++;
        }
    }

    private static void ProcessRounds(string testData, League league)
    {
        string subPath = $"test/{testData}/rounds";
        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string filePath = Path.Combine(currentDirectory, subPath);
        string[] roundFiles = Directory.GetFiles(filePath);

        for (int i = 1; i <= roundFiles.Length; i++)
        {
            league.Round++;
            SetFractions(league);
            CSVReader.ReadRound(testData, league, i);
            AdjustPlacements(league);
            StandingsPrinter.PrintStandings(league);
            StandingsPrinter.SaveStandings(testData, league);
        }
    }

    private static void SetFractions(League league)
    {
        if (league.Round == 23)
        {
            for (int i = 0; i < league.Teams.Count; i++)
            {
                if (i < league.Teams.Count / 2)
                {
                    league.Teams[i].Fraction = "Upper";
                }
                else
                {
                    league.Teams[i].Fraction = "Lower";
                }
            }
        }
    }
}
