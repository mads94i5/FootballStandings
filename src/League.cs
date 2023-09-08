public class League
{
	public string Name { get; set; }
	public int PositionsToChampionsLeague { get; set; }
	public int PositionsToEuropeLeague { get; set; }
	public int PositionsToConferenceLeague { get; set; }
	public int PositionsToUpperLeague { get; set; }
	public int PositionsToLowerLeague { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    public int Round { get; set; } = 0;

    public League(string name, int positionsToChampionsLeague, int positionsToEuropeLeague, 
        int positionsToConferenceLeague, int positionsToUpperLeague, int positionsToLowerLeague)
    {
        Name = name;
        PositionsToChampionsLeague = positionsToChampionsLeague;
        PositionsToEuropeLeague = positionsToEuropeLeague;
        PositionsToConferenceLeague = positionsToConferenceLeague;
        PositionsToUpperLeague = positionsToUpperLeague;
        PositionsToLowerLeague = positionsToLowerLeague;
    }
}
