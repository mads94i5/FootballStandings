﻿public static class CSVReader
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
                        throw new FormatException($"Invalid number of columns ({data.Length}) in the CSV data.");
                    }
                }
                else
                {
                    throw new Exception($"No data found in the CSV file: {csvFilePath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message} - for: {testData}");
            Environment.Exit(1);
            return null;
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
                            throw new FormatException($"Invalid number of columns ({data.Length}) in the CSV data.");
                        }
                    }
                    else
                    {
                        throw new Exception($"Not enough data found in the CSV file: {csvFilePath}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message} - for: {testData}");
            Environment.Exit(2);
        }
        
    }
    public static void ReadRound(string testData, League league, int round, int reschedule)
    {

        string csvFileName = reschedule != -1 ? $"test/{testData}/rounds/round-{round}-{reschedule}.csv" : $"test/{testData}/rounds/round-{round}.csv";
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

                while (true)
                {
                    string dataLine = reader.ReadLine()!;

                    if (dataLine != null)
                    {
                        string[] data = dataLine.Split(',');
                        FillRoundData(league, data);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: Round: {league.Round} Message: {ex.Message} - for: {testData}"); 
            Environment.Exit(3);
        }
    }
    private static void FillRoundData(League league, string[] data)
    {
        if (data.Length <= 2)
        {
            throw new FormatException("Invalid number of columns in the CSV data.");
        }
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
            if (league.Teams[i].Abbreviation == awayTeam)
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

        if ((homeTeamIndex == -1 || awayTeamIndex == -1))
        {
            throw new Exception($"Couldn't find teams.");
        }
        if (homeTeamIndex == awayTeamIndex)
        {
            throw new Exception("Teams can't play themselves.");
        }
        if (league.Round > 22 && league.Teams[homeTeamIndex].Fraction != league.Teams[awayTeamIndex].Fraction)
        {
            throw new Exception($"Teams can't play teams from another fraction: " +
                $"{league.Teams[homeTeamIndex].ClubName}[{league.Teams[homeTeamIndex].Fraction}] vs " +
                $"{league.Teams[awayTeamIndex].ClubName}[{league.Teams[awayTeamIndex].Fraction}]");
        }
        if (league.Teams[homeTeamIndex].GamesAgainstHome.Contains(league.Teams[awayTeamIndex].Abbreviation))
        {
            throw new Exception($"Home team: {league.Teams[homeTeamIndex].ClubName} ({league.Teams[homeTeamIndex].Abbreviation}) already played {league.Teams[awayTeamIndex].ClubName} ({league.Teams[awayTeamIndex].Abbreviation}) on home field.");
        }
        if (league.Teams[awayTeamIndex].GamesAgainstAway.Contains(league.Teams[homeTeamIndex].Abbreviation))
        {
            throw new Exception($"Away team: {league.Teams[awayTeamIndex].ClubName} ({league.Teams[awayTeamIndex].Abbreviation}) already played {league.Teams[homeTeamIndex].ClubName} ({league.Teams[homeTeamIndex].Abbreviation}) on away field.");
        }
        league.Teams[homeTeamIndex].GamesPlayed++;
        league.Teams[homeTeamIndex].GamesAgainstHome.Add(league.Teams[awayTeamIndex].Abbreviation);
        league.Teams[homeTeamIndex].GoalsFor += homeScore;
        league.Teams[homeTeamIndex].GoalsAgainst += awayScore;
        league.Teams[awayTeamIndex].GamesPlayed++;
        league.Teams[awayTeamIndex].GamesAgainstAway.Add(league.Teams[homeTeamIndex].Abbreviation);
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
