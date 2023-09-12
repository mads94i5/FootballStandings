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
			try
			{
				File.AppendAllText(filePath, System.Text.RegularExpressions.Regex.Replace(line, @"\x1b\[\d+m", "") + $"\n");
			}
			catch (UnauthorizedAccessException ex)
			{
				Console.WriteLine("Error: Unauthorized access to the file.", ex);
			}
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
			try
			{
				File.Delete(filePath);
			}
			catch (UnauthorizedAccessException ex)
            {
				Console.WriteLine("Error: Unauthorized access to deleting the file.", ex);
			}
		}
    }

	private static List<string> GetStandingsStrings(League league)
	{
		List<string> standings = new List<string>();
		string fullLine = $"-------------------------------------------------------------------------------------------";
		string headers = $"|  # |              Klub              |  K  |  V  |  U  |  T  |  Mål  | Dif | Point | Str |";

		standings.Add($"{fullLine}");
		standings.Add($"| League: {FillString(league.Name, 79, false)} |");
		standings.Add($"| Round: {FillString(league.Round.ToString(), 80, false)} |");
		if (league.Round > 22)
		{
			standings.Add($"{fullLine}");
			standings.Add($"| Fraction: {FillString("Upper", 77, false)} |");
        }
		standings.Add($"{fullLine}");
		standings.Add($"{headers}");
		standings.Add($"{fullLine}");
		for (int i = 0; i < league.Teams.Count; i++)
		{
			Team team = league.Teams[i];
			if (league.PositionsToUpperLeague != 0 && i + 1 <= league.PositionsToUpperLeague)
			{
				standings.Add($"| {(league.Round > 22 ? team.Fraction == "Upper" ? $"\x1b[33m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : $"\x1b[34m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : FillString(team.Position.ToString(), 2, true))} | " +
					$"{FillString(team.SpecialRanking != "" ? "(" + team.SpecialRanking + ")" : "", 3, true)}{FillString("\x1b[32m" + team.ClubName + " \x1b[0m(\x1b[32m" + team.Abbreviation + "\x1b[0m)", 27, false)} | " +
                    $"{FillString(team.GamesPlayed.ToString(), 3, true)} | {FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | " +
                    $"{FillString(team.GamesLost.ToString(), 3, true)} | {FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | " +
                    $"{FillString(team.GoalsDifference.ToString(), 3, true)} | {FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
				standings.Add($"{fullLine}");
			}
			else if (i + 1 > league.Teams.Count - league.PositionsToLowerLeague)
			{
				standings.Add($"| {(league.Round > 22 ? team.Fraction == "Upper" ? $"\x1b[33m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : $"\x1b[34m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : FillString(team.Position.ToString(), 2, true))} | " +
					$"{FillString(team.SpecialRanking != "" ? "(" + team.SpecialRanking + ")" : "", 3, true)}{FillString("\x1b[31m" + team.ClubName + " \x1b[0m(\x1b[31m" + team.Abbreviation + "\x1b[0m)", 27, false)} | " +
					$"{FillString(team.GamesPlayed.ToString(), 3, true)} | {FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | " +
					$"{FillString(team.GamesLost.ToString(), 3, true)} | {FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | " +
					$"{FillString(team.GoalsDifference.ToString(), 3, true)} | {FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
				standings.Add($"{fullLine}");
			}
			else
			{
				standings.Add($"| {(league.Round > 22 ? team.Fraction == "Upper" ? $"\x1b[33m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : $"\x1b[34m{FillString(team.Position.ToString(), 2, true)}\x1b[0m" : FillString(team.Position.ToString(), 2, true))} | " +
					$"{FillString(team.SpecialRanking != "" ? "(" + team.SpecialRanking + ")" : "", 3, true)}{FillString(team.ClubName + " (" + team.Abbreviation + ")", 27, false)} | " +
					$"{FillString(team.GamesPlayed.ToString(), 3, true)} | {FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | " +
					$"{FillString(team.GamesLost.ToString(), 3, true)} | {FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | " +
					$"{FillString(team.GoalsDifference.ToString(), 3, true)} | {FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
				standings.Add($"{fullLine}");
			}
			if (league.Round > 22 && i + 1 == Math.Ceiling((double)league.Teams.Count / 2))
			{
				standings.Add($"| Fraction: {FillString("Lower", 77, false)} |");
				standings.Add($"{fullLine}");
				standings.Add($"{headers}");
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
