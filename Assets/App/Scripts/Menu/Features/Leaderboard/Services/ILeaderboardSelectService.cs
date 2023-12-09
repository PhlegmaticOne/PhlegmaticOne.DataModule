using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Leaderboard.ViewModels;

public interface ILeaderboadSelectService
{
    Task<IReadOnlyList<LeaderboardEntryViewModel>> SelectTopPlayersAsync(int count);
}