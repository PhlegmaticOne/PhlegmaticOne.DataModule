using App.Scripts.Shared.Progress.Models;
using Firebase.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class LeaderboardSelectService : ILeaderboadSelectService
{
    private readonly FirebaseDatabase _database;
    public LeaderboardSelectService()
    {
        _database = FirebaseDatabase.DefaultInstance;
    }

    public async Task<IReadOnlyList<LeaderboardEntry>> SelectTopPlayersAsync(int count)
    {
        var usersReference = _database.RootReference.Child("users");

        var querySnapshot = await usersReference
            .OrderByChild(nameof(PlayerState.MaxScore))
            .LimitToLast(count)
            .GetValueAsync();

        return ToLeaderboardEntries(querySnapshot).ToList();
    }

    private IEnumerable<LeaderboardEntry> ToLeaderboardEntries(DataSnapshot snapshot)
    {
        return snapshot.Children.Select(x => {
            var stateChild = x.Child(nameof(PlayerState));
            var maxScoreChild = stateChild.Child(nameof(PlayerState.MaxScore));
            var nameChild = stateChild.Child(nameof(PlayerState.Name));
            var maxScore = int.Parse(maxScoreChild.Value.ToString());
            var name = nameChild.Value.ToString();
            return new LeaderboardEntry(name, maxScore);
        });
    }
}
