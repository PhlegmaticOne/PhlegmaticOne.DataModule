public class LeaderboardEntry
{
    public string UserName { get; }
    public int GlobalScore { get; }

    public LeaderboardEntry(string userName, int globalScore)
    {
        UserName=userName;
        GlobalScore=globalScore;
    }
}
