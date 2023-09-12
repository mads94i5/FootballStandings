public static class MatchScheduler
{
    public static void ScheduleDoubleRoundRobinMatches(List<string> teams)
    {
        List<string> matches = new List<string>();
        List<List<string>> rounds = new List<List<string>>();

        int totalRounds = (teams.Count - 1) * 2;
        Console.WriteLine("Total rounds: " + totalRounds);
        int matchesPerRound = teams.Count / 2;
        Console.WriteLine("Matches Per Round: " + matchesPerRound);
        if (totalRounds == 10)
        {
            matches.Add($"{teams[1]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[4]},{GenerateRandomScore()}");

            matches.Add($"{teams[2]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[4]},{GenerateRandomScore()}");

            matches.Add($"{teams[5]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[0]},{teams[4]},{GenerateRandomScore()}");

            matches.Add($"{teams[3]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[1]},{GenerateRandomScore()}");

            matches.Add($"{teams[4]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[0]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[1]},{GenerateRandomScore()}");

            // Reversed
            matches.Add($"{teams[0]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[3]},{GenerateRandomScore()}");

            matches.Add($"{teams[3]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[0]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[1]},{GenerateRandomScore()}");

            matches.Add($"{teams[3]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[0]},{GenerateRandomScore()}");

            matches.Add($"{teams[0]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[5]},{GenerateRandomScore()}");

            matches.Add($"{teams[5]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[3]},{GenerateRandomScore()}");
        }
        if (totalRounds == 22)
        {
            // round 1
            matches.Add($"{teams[0]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[6]},{GenerateRandomScore()}");
            // round 2
            matches.Add($"{teams[0]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[5]},{GenerateRandomScore()}");
            // round 3
            matches.Add($"{teams[0]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[4]},{GenerateRandomScore()}");
            // round 4
            matches.Add($"{teams[0]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[3]},{GenerateRandomScore()}");
            // round 5
            matches.Add($"{teams[0]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[2]},{GenerateRandomScore()}");
            // round 6
            matches.Add($"{teams[0]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[1]},{GenerateRandomScore()}");
            // round 7
            matches.Add($"{teams[0]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[11]},{GenerateRandomScore()}");
            // round 8
            matches.Add($"{teams[0]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[10]},{GenerateRandomScore()}");
            // round 9
            matches.Add($"{teams[0]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[9]},{GenerateRandomScore()}");
            // round 10
            matches.Add($"{teams[0]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[8]},{GenerateRandomScore()}");
            // round 11
            matches.Add($"{teams[0]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[7]},{GenerateRandomScore()}");

            // round 12 onwards - reversed order matches - switch home and away

            matches.Add($"{teams[11]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[5]},{GenerateRandomScore()}");
            // round 13
            matches.Add($"{teams[10]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[4]},{GenerateRandomScore()}");
            // round 14
            matches.Add($"{teams[9]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[3]},{GenerateRandomScore()}");
            // round 15
            matches.Add($"{teams[8]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[1]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[2]},{GenerateRandomScore()}");
            // round 16
            matches.Add($"{teams[7]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[6]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[11]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[1]},{GenerateRandomScore()}");
            // round 17
            matches.Add($"{teams[6]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[5]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[10]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[11]},{GenerateRandomScore()}");
            // round 18
            matches.Add($"{teams[5]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[4]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[9]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[10]},{GenerateRandomScore()}");
            // round 19 
            matches.Add($"{teams[4]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[3]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[8]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[9]},{GenerateRandomScore()}");
            // round 20
            matches.Add($"{teams[3]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[2]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[7]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[8]},{GenerateRandomScore()}");
            // round 21
            matches.Add($"{teams[2]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[1]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[6]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[7]},{GenerateRandomScore()}");
            // round 22
            matches.Add($"{teams[1]},{teams[0]},{GenerateRandomScore()}");
            matches.Add($"{teams[11]},{teams[2]},{GenerateRandomScore()}");
            matches.Add($"{teams[10]},{teams[3]},{GenerateRandomScore()}");
            matches.Add($"{teams[9]},{teams[4]},{GenerateRandomScore()}");
            matches.Add($"{teams[8]},{teams[5]},{GenerateRandomScore()}");
            matches.Add($"{teams[7]},{teams[6]},{GenerateRandomScore()}");

        }

        // Print out matches
        Console.WriteLine($"Matches ({matches.Count}):");
        int round = 1;
        for (int i = 0; i < matches.Count; i++)
        {
            if (i % matchesPerRound == 0)
            {
                Console.WriteLine($"Round {round}:");
                round++;
            }
            Console.WriteLine(matches[i]);
        }
    }



    public static void ScheduleMatches(int totalRounds, List<string> teams)
    {
        List<string> matches = new List<string>();
        List<string> playedMatches = new List<string>();
        List<List<string>> rounds = new List<List<string>>();

        // Generate all matchups for season
        for (int i = 0; i < teams.Count; i++)
        {
            for (int j = 0; j < teams.Count; j++)
            {
                if (teams[i] != teams[j])
                {
                    string homeTeam = teams[i];
                    string awayTeam = teams[j];
                    string match = $"{homeTeam},{awayTeam}";
                    string reverseMatch = $"{awayTeam},{homeTeam}";

                    // Check if the match or reverse match has already been played
                    if (!playedMatches.Contains(match))
                    {
                        matches.Add(match + $",{GenerateRandomScore()}");
                        playedMatches.Add(match);
                    }
                    else if (!playedMatches.Contains(reverseMatch))
                    {
                        matches.Add(reverseMatch + $",{GenerateRandomScore()}");
                        playedMatches.Add(reverseMatch);
                    }
                }
            }
        }
        // Split matches into rounds of double round robin
        int matchesPerRound = teams.Count / 2;
        int totalMatches = matches.Count;

        for (int round = 0; round < totalRounds; round++)
        {
            List<string> roundMatches = new List<string>();

            for (int matchIndex = 0; matchIndex < matchesPerRound; matchIndex++)
            {
                int homeIndex = (round + matchIndex) % teams.Count;
                int awayIndex = (round + teams.Count - matchIndex) % teams.Count;

                if (homeIndex != awayIndex)
                {
                    string homeTeam = teams[homeIndex];
                    string awayTeam = teams[awayIndex];

                    string match = $"{homeTeam},{awayTeam},{matches[round * matchesPerRound + matchIndex].Split(',')[2]}";

                    roundMatches.Add(match);
                }
            }

            rounds.Add(roundMatches);
        }









        // Print out matches
        Console.WriteLine($"Matches ({matches.Count}):");
        for (int i = 0; i < matches.Count; i++)
        {
            Console.WriteLine(matches[i]);
        }
        // Print out rounds
        for (int round = 0; round < rounds.Count; round++)
        {
            Console.WriteLine($"Round {round + 1}:");
            foreach (string match in rounds[round])
            {
                Console.WriteLine(match);
            }
        }
    }

    private static string FindMatchForRound(List<string> remainingMatches, List<string> teamsPlayedInRound)
    {
        string match = null!;
        while (match == null)
        {
            for (int i = 0; i < remainingMatches.Count; i++)
            {
                string[] teams = remainingMatches[i].Split(',');
                if (!teamsPlayedInRound.Contains(teams[0]) && !teamsPlayedInRound.Contains(teams[1]))
                {
                    match = remainingMatches[i];
                    remainingMatches.Remove(match);
                    teamsPlayedInRound.Add(teams[0]);
                    teamsPlayedInRound.Add(teams[1]);
                    Console.WriteLine($"Found match: {teams[0]} vs {teams[1]} - Teams in round: {string.Join(", ", teamsPlayedInRound)} - Remaining matches: {remainingMatches.Count}");
                    return match;
                }
            }
        }
        Console.WriteLine($"Didn't find match.");
        return match;
    }

    private static string GenerateRandomScore()
    {
        Random rand = new Random();
        string score1 = rand.Next(0, 4).ToString();
        string score2 = rand.Next(0, 4).ToString();
        return $"{score1}-{score2}";
    }
}
