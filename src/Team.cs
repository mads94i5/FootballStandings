public class Team
{
	public string Abbreviation { get; set; }
	public string ClubName { get; set; }
	public string SpecialRanking { get; set; }
	public string Position { get; set; } = "-";
	public int GamesPlayed { get; set; }
	public List<string> GamesAgainstHome { get; set; } = new List<string>();
	public List<string> GamesAgainstAway { get; set; } = new List<string>();
	public int GamesWon { get; set; }
	public int GamesDrawn { get; set; }
	public int GamesLost { get; set; }
	public int GoalsFor { get; set; }
	public int GoalsAgainst { get; set; }
	public int GoalsDifference { get { return GoalsFor - GoalsAgainst; } }
	public int PointsAchieved { get; set; }
	public string WinStreak { get; set; } = "-";
	public string Fraction { get; set; } = "-";

    public Team(string abbreviation, string clubName, string specialRanking)
    {
        Abbreviation = abbreviation;
        ClubName = clubName;
        SpecialRanking = specialRanking;
    }
}
