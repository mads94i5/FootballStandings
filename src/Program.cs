class Program
{
    static void Main()
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        LeagueProcessor.ProcessLeague("superligaen");
        LeagueProcessor.ProcessLeague("nordicbetligaen");
        LeagueProcessor.ProcessLeague("eleventeams");
        LeagueProcessor.ProcessLeague("extrateam");
        LeagueProcessor.ProcessLeague("lessrounds");
        LeagueProcessor.ProcessLeague("extraround");
        LeagueProcessor.ProcessLeague("firstroundextramatch");
        LeagueProcessor.ProcessLeague("firstroundmissingmatch");
    }
}