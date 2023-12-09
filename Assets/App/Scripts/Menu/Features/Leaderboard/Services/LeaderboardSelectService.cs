using App.Scripts.Shared.Progress.Models;
using Firebase.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Menu.Features.Leaderboard.ViewModels;

public class LeaderboardSelectService : ILeaderboadSelectService
{
    private readonly IDialogsManager _dialogsManager;
    private readonly FirebaseDatabase _database;
    public LeaderboardSelectService(IDialogsManager dialogsManager)
    {
        _dialogsManager = dialogsManager;
        _database = FirebaseDatabase.DefaultInstance;
    }

    public async Task<IReadOnlyList<LeaderboardEntryViewModel>> SelectTopPlayersAsync(int count)
    {
        var usersReference = _database.RootReference.Child("users");

        var querySnapshot = await usersReference
            .OrderByChild(nameof(PlayerState.MaxScore))
            .LimitToLast(count)
            .GetValueAsync();

        return ToLeaderboardEntries(querySnapshot).OrderByDescending(x => x.GlobalScore).ToList();
    }

    private IEnumerable<LeaderboardEntryViewModel> ToLeaderboardEntries(DataSnapshot snapshot)
    {
        return snapshot.Children.Reverse().Select(x => {
            var stateChild = x.Child(nameof(PlayerState));
            var maxScoreChild = stateChild.Child(nameof(PlayerState.MaxScore));
            var nameChild = stateChild.Child(nameof(PlayerState.Name));
            var maxScore = int.Parse(maxScoreChild.Value.ToString());
            var name = nameChild.Value.ToString();
            var userId = x.Key;
            
            return new LeaderboardEntryViewModel(_dialogsManager)
                .WithSetup(name, maxScore, userId);
        });
    }
}
