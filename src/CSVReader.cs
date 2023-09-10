public static class CSVReader
{
    public static League ReadLeague(string testData)
    {
        string csvFileName = $"test/{testData}/setup/setup.csv";
        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string csvFilePath = Path.Combine(currentDirectory, csvFileName);

        try
        {
            if (!File.Exists(csvFilePath))
            {
                throw new FileNotFoundException($"CSV file not found at path: {csvFilePath}");
            }

            using (var reader = new StreamReader(csvFilePath))
            {
                reader.ReadLine();

                string dataLine = reader.ReadLine()!;

                if (dataLine != null)
                {
                    string[] data = dataLine.Split(',');

                    if (data.Length == 6)
                    {
                        string leagueName = data[0].Trim();
                        int positionsToChampionsLeague = int.Parse(data[1].Trim());
                        int positionsToEuropeLeague = int.Parse(data[2].Trim());
                        int positionsToConferenceLeague = int.Parse(data[3].Trim());
                        int positionsToUpperLeague = int.Parse(data[4].Trim());
                        int positionsToLowerLeague = int.Parse(data[5].Trim());

                        League league = new League(
                            leagueName,
                            positionsToChampionsLeague,
                            positionsToEuropeLeague,
                            positionsToConferenceLeague,
                            positionsToUpperLeague,
                            positionsToLowerLeague
                        );

                        return league;
                    }
                    else
                    {
                        throw new FormatException("Invalid number of columns in the CSV data.");
                    }
                }
                else
                {
                    throw new Exception("No data found in the CSV file.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null!;
        }
    }
    public static void ReadTeams(string testData, League league)
    {

        string csvFileName = $"test/{testData}/setup/teams.csv";
        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string csvFilePath = Path.Combine(currentDirectory, csvFileName);

        try
        {
            if (!File.Exists(csvFilePath))
            {
                throw new FileNotFoundException($"CSV file not found at path: {csvFilePath}");
            }

            using (var reader = new StreamReader(csvFilePath))
            {
                reader.ReadLine();

                for (int i = 0; i < 12; i++)
                {
                    string dataLine = reader.ReadLine()!;

                    if (dataLine != null)
                    {
                        string[] data = dataLine.Split(',');

                        if (data.Length == 2)
                        {
                            string teamAbbreviation = data[0].Trim();
                            string teamName = data[1].Trim();

                            Team team = new Team(
                                teamAbbreviation,
                                teamName,
                                ""
                            );

                            league.Teams.Add(team);
                        }
                        else if (data.Length == 3)
                        {
                            string teamAbbreviation = data[0].Trim();
                            string teamName = data[1].Trim();
                            string teamSpecialRanking = data[2].Trim();

                            Team team = new Team(
                                teamAbbreviation,
                                teamName,
                                teamSpecialRanking
                            );

                            league.Teams.Add(team);
                        }
                        else
                        {
                            throw new FormatException("Invalid number of columns in the CSV data.");
                        }
                    }
                    else
                    {
                        throw new Exception("No data found in the CSV file.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    public static void ReadRound(string testData, League league, int round)
    {

        string csvFileName = $"test/{testData}/rounds/round-{round}.csv";
        string workingDirectory = Environment.CurrentDirectory;
        string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        string csvFilePath = Path.Combine(currentDirectory, csvFileName);

        try
        {
            if (!File.Exists(csvFilePath))
            {
                throw new FileNotFoundException($"CSV file not found at path: {csvFilePath}");
            }

            using (var reader = new StreamReader(csvFilePath))
            {
                reader.ReadLine();

                for (int l = 0; l < 6; l++)
                {
                    string dataLine = reader.ReadLine()!;

                    if (dataLine != null)
                    {
                        string[] data = dataLine.Split(',');

                        FillRoundData(league, data);
                    }
                    else
                    {
                        throw new Exception("No data found in the CSV file.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
    }
    private static void FillRoundData(League league, string[] data)
    {
        if (data.Length == 3)
        {
            string homeTeam = data[0].Trim();
            string awayTeam = data[1].Trim();
            string matchScore = data[2].Trim();
            int homeTeamIndex = -1;
            int awayTeamIndex = -1;
            for (int i = 0; i < league.Teams.Count; i++)
            {
                if (league.Teams[i].Abbreviation == homeTeam)
                {
                    homeTeamIndex = i;
                }
                else if (league.Teams[i].Abbreviation == awayTeam)
                {
                    awayTeamIndex = i;
                }
                if (homeTeamIndex != -1 && awayTeamIndex != -1)
                {
                    break;
                }
            }
            string[] scores = matchScore.Split('-');
            int homeScore = int.Parse(scores[0].Trim());
            int awayScore = int.Parse(scores[1].Trim());

            if (homeTeamIndex != -1 && awayTeamIndex != -1)
            {
                league.Teams[homeTeamIndex].GamesPlayed++;
                league.Teams[homeTeamIndex].GoalsFor += homeScore;
                league.Teams[homeTeamIndex].GoalsAgainst += awayScore;
                league.Teams[awayTeamIndex].GamesPlayed++;
                league.Teams[awayTeamIndex].GoalsFor += awayScore;
                league.Teams[awayTeamIndex].GoalsAgainst += homeScore;
                if (homeScore > awayScore)
                {
                    league.Teams[homeTeamIndex].GamesWon++;
                    SetTeamStreak(league, homeTeamIndex, "W");
                    league.Teams[homeTeamIndex].PointsAchieved += 3;
                    league.Teams[awayTeamIndex].GamesLost++;
                    SetTeamStreak(league, awayTeamIndex, "L");
                }
                else if (homeScore < awayScore)
                {
                    league.Teams[homeTeamIndex].GamesLost++;
                    SetTeamStreak(league, homeTeamIndex, "L");
                    league.Teams[awayTeamIndex].GamesWon++;
                    SetTeamStreak(league, awayTeamIndex, "W");
                    league.Teams[awayTeamIndex].PointsAchieved += 3;
                }
                else
                {
                    league.Teams[homeTeamIndex].GamesDrawn++;
                    SetTeamStreak(league, homeTeamIndex, "D");
                    league.Teams[homeTeamIndex].PointsAchieved++;
                    league.Teams[awayTeamIndex].GamesDrawn++;
                    SetTeamStreak(league, awayTeamIndex, "D");
                    league.Teams[awayTeamIndex].PointsAchieved++;
                }
            }
            else
            {
                throw new Exception("Couldn't find team indexes.");
            }
        }
        else
        {
            throw new FormatException("Invalid number of columns in the CSV data.");
        }
    }
    private static void SetTeamStreak(League league, int teamIndex, string lastMatch)
    {
        if (league.Teams[teamIndex].WinStreak.Contains(lastMatch))
        {
            if (league.Teams[teamIndex].WinStreak.Contains("1"))
            {
                league.Teams[teamIndex].WinStreak = "2" + lastMatch;
            }
            else if (league.Teams[teamIndex].WinStreak.Contains("2"))
            {
                league.Teams[teamIndex].WinStreak = "3" + lastMatch;
            }
            else if (league.Teams[teamIndex].WinStreak.Contains("3"))
            {
                league.Teams[teamIndex].WinStreak = "4" + lastMatch;
            }
            else if (league.Teams[teamIndex].WinStreak.Contains("4"))
            {
                league.Teams[teamIndex].WinStreak = "5" + lastMatch;
            }
        }
        else
        {
            league.Teams[teamIndex].WinStreak = "1" + lastMatch;
        }
    }
}
