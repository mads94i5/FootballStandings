public static class StandingsPrinter
{
	public static void PrintStandings(League league)
	{
		List<string> standings = GetStandingsStrings(league);

		foreach (string line in standings)
        {
			Console.WriteLine(line);
        }
	}
	public static void SaveStandings(string testData, League league)
	{
		List<string> standings = GetStandingsStrings(league);
		string fileName = $"test/{testData}/standings.txt";
		string workingDirectory = Environment.CurrentDirectory;
		string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
		string filePath = Path.Combine(currentDirectory, fileName);

		foreach (string line in standings)
		{
			File.AppendAllText(filePath, System.Text.RegularExpressions.Regex.Replace(line, @"\x1b\[\d+m", "") + $"\n");
		}
	}
	public static void DeleteStandings(string testData)
	{
		string fileName = $"test/{testData}/standings.txt";
		string workingDirectory = Environment.CurrentDirectory;
		string currentDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
		string filePath = Path.Combine(currentDirectory, fileName);
		if (File.Exists(filePath))
        {
			File.Delete(filePath);
        }
    }

	private static List<string> GetStandingsStrings(League league)
	{
		List<string> standings = new List<string>();
		string fullLine = $"------------------------------------------------------------------------------------";

		standings.Add($"{fullLine}");
		standings.Add($"| League: {FillString(league.Name, 72, false)} |");
		standings.Add($"| Round: {FillString(league.Round.ToString(), 73, false)} |");
		standings.Add($"{fullLine}");
		standings.Add($"|  # |          Klub           |  K  |  V  |  U  |  T  |  Mål  | Dif | Point | Str |");
		standings.Add($"{fullLine}");
		for (int i = 0; i < league.Teams.Count; i++)
		{
			Team team = league.Teams[i];
			if (league.PositionsToUpperLeague != 0 && i + 1 >= league.PositionsToUpperLeague)
			{
				standings.Add($"| {(league.Round > 22 ? i >= league.Teams.Count / 2 ? $"\x1b[34m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : $"\x1b[33m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : FillString(team.Position.ToString(), 2, true))} | " +
                    $"\x1b[32m{FillString(team.SpecialRanking != "" ? team.ClubName + $"\x1b[0m (" + team.SpecialRanking + ")" : team.ClubName + $"\x1b[0m", 23, false)} | " +
                    $"{FillString(team.GamesPlayed.ToString(), 3, true)} | {FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | " +
                    $"{FillString(team.GamesLost.ToString(), 3, true)} | {FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | " +
                    $"{FillString(team.GoalsDifference.ToString(), 3, true)} | {FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
				standings.Add($"{fullLine}");
			}
			else if (i + 1 > league.Teams.Count - league.PositionsToLowerLeague)
			{
				standings.Add($"| {(league.Round > 22 ? i >= league.Teams.Count / 2 ? $"\x1b[34m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : $"\x1b[33m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : FillString(team.Position.ToString(), 2, true))} | " +
					$"\x1b[31m{FillString(team.SpecialRanking != "" ? team.ClubName + $"\x1b[0m (" + team.SpecialRanking + ")" : team.ClubName + $"\x1b[0m", 23, false)} | " +
					$"{FillString(team.GamesPlayed.ToString(), 3, true)} | {FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | " +
					$"{FillString(team.GamesLost.ToString(), 3, true)} | {FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | " +
					$"{FillString(team.GoalsDifference.ToString(), 3, true)} | {FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
				standings.Add($"{fullLine}");
			}
			else
			{
				standings.Add($"| {(league.Round > 22 ? i >= league.Teams.Count/2 ? $"\x1b[34m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : $"\x1b[33m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : FillString(team.Position.ToString(), 2, true))} | " +
					$"{FillString(team.SpecialRanking != "" ? team.ClubName + $" (" + team.SpecialRanking + ")" : team.ClubName, 23, false)} | " +
					$"{FillString(team.GamesPlayed.ToString(), 3, true)} | {FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | " +
					$"{FillString(team.GamesLost.ToString(), 3, true)} | {FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | " +
					$"{FillString(team.GoalsDifference.ToString(), 3, true)} | {FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
				standings.Add($"{fullLine}");
			}
		}
		standings.Add($"");
		return standings;
	}

	private static string FillString(string inputStr, int desiredLength, bool leftSide, char fillCharacter = ' ')
	{
		string cleanInputStr = System.Text.RegularExpressions.Regex.Replace(inputStr, @"\x1b\[\d+m", "");

		if (cleanInputStr.Length >= desiredLength)
		{
			return inputStr;
		}

		int fillCount = desiredLength - cleanInputStr.Length;
		string filledStr;

		if (leftSide)
		{
			filledStr = new string(fillCharacter, fillCount) + inputStr;
		}
		else
		{
			filledStr = inputStr + new string(fillCharacter, fillCount);
		}

		return filledStr;
	}
}
