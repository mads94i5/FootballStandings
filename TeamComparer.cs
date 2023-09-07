public class TeamComparer : IComparer<Team>
{
    public int Compare(Team? x, Team? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("Both teams must not be null.");
        }

        // Compare by points
        if (x.PointsAchieved != y.PointsAchieved)
            return y.PointsAchieved.CompareTo(x.PointsAchieved);

        // Compare by goal difference
        if (x.GoalsDifference != y.GoalsDifference)
            return y.GoalsDifference.CompareTo(x.GoalsDifference);

        // Compare by goals for
        if (x.GoalsFor != y.GoalsFor)
            return y.GoalsFor.CompareTo(x.GoalsFor);

        // Compare by goals against
        if (x.GoalsAgainst != y.GoalsAgainst)
            return x.GoalsAgainst.CompareTo(y.GoalsAgainst);

        // Compare alphabetically
        return string.Compare(x.ClubName, y.ClubName, StringComparison.Ordinal);
    }
}
