class Program
{
    public static void Main()
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        Console.WriteLine($"Running program..\n");
        // Match scheduling algorithm to prevent teams playing against themselves
        // And make sure teams only play each other once on home, and once on away field:
        // MatchScheduler.ScheduleDoubleRoundRobinMatches(new List<string> { "LBK", "OB", "BIF", "FCK", "RFC", "SIF", "AaB", "FCH", "EFC", "HFC", "AGF", "FCN" });
        // MatchScheduler.ScheduleDoubleRoundRobinMatches(new List<string> { "FCK", "AGF", "EFC", "OB", "AaB", "BIF" });
        // MatchScheduler.ScheduleDoubleRoundRobinMatches(new List<string> { "HFC", "RFC", "SIF", "FCH", "LBK", "FCN" });
        // MatchScheduler.ScheduleDoubleRoundRobinMatches(new List<string> { "ACH", "FCH", "VFF", "EIK", "HOB", "SIF", "VFK", "HFC", "FCR", "FCN", "FCM", "FCC" });
        // MatchScheduler.ScheduleDoubleRoundRobinMatches(new List<string> { "EIK", "FCR", "HOB", "FCH", "FCM", "FCN" });
        // MatchScheduler.ScheduleDoubleRoundRobinMatches(new List<string> { "VFF", "ACH", "FCC", "HFC", "SIF", "VFK" });

        // Process test data
        LeagueProcessor.ProcessLeague("nordicbetligaen");
        LeagueProcessor.ProcessLeague("superligaen");
        LeagueProcessor.ProcessLeague("extrateam");
        LeagueProcessor.ProcessLeague("lessrounds");
        LeagueProcessor.ProcessLeague("firstroundmissingmatch");
        LeagueProcessor.ProcessLeague("matchreschedule");

        // Uncomment to test error cases:
        // LeagueProcessor.ProcessLeague("faceagainstself");
        // LeagueProcessor.ProcessLeague("eleventeams");
        // LeagueProcessor.ProcessLeague("extraround");
        // LeagueProcessor.ProcessLeague("firstroundextramatch");
        // LeagueProcessor.ProcessLeague("fractionextramatch");
    }


}