public static class StandingsPrinter
{
	public static void PrintStandings(League league)
	{
		string fullLine = $"------------------------------------------------------------------------------";
		Console.WriteLine($"{fullLine}");
		Console.WriteLine($"| League: {FillString(league.Name, 66, false)} |");
		Console.WriteLine($"| Round: {FillString(league.Round.ToString(), 67, false)} |");
		Console.WriteLine($"{fullLine}");
		Console.WriteLine($"|  # | Klub              |  K  |  V  |  U  |  T  |  Mål  | Dif | Point | Str |"); 
		Console.WriteLine($"{fullLine}");
		foreach (var team in league.Teams)
		{
			Console.WriteLine($"| {FillString(team.Position.ToString(), 2, true)} | {FillString(team.ClubName, 17, true)} | {FillString(team.GamesPlayed.ToString(), 3, true)} | " +
                $"{FillString(team.GamesWon.ToString(), 3, true)} | {FillString(team.GamesDrawn.ToString(), 3, true)} | {FillString(team.GamesLost.ToString(), 3, true)} | " +
                $"{FillString(team.GoalsFor.ToString(), 2, true)}-{FillString(team.GoalsAgainst.ToString(), 2, false)} | {FillString(team.GoalsDifference.ToString(), 3, true)} | " +
                $"{FillString(team.PointsAchieved.ToString(), 5, true)} | {FillString(team.WinStreak, 3, true)} |");
			Console.WriteLine($"{fullLine}");
		}
	}

	private static string FillString(string inputStr, int desiredLength, bool leftSide, char fillCharacter = ' ')
	{
		if (inputStr.Length >= desiredLength)
		{
			return inputStr;
		}

		int fillCount = desiredLength - inputStr.Length;
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
