class Program
{
    static void Main()
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        League league = CSVReader.ReadLeague();
        CSVReader.ReadTeams(league);
        league.Teams.Sort(new TeamComparer());
        StandingsPrinter.PrintStandings(league);
    }
}