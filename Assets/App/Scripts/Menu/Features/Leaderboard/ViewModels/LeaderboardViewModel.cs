using Assets.App.Scripts.Menu.Features.Leaderboard.Configs;
using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using PhlegmaticOne.ViewModels.Contracts;
using System.Threading.Tasks;

public class LeaderboardViewModel : BaseViewModel
{
    private readonly ILeaderboadSelectService _leaderboadSelectService;
    private readonly LeaderboardConfig _leaderboardConfig;

    public LeaderboardViewModel(ILeaderboadSelectService leaderboadSelectService, LeaderboardConfig leaderboardConfig)
    {
        _leaderboadSelectService=leaderboadSelectService;
        _leaderboardConfig=leaderboardConfig;
        LeaderboardEntries = new ReactiveCollection<LeaderboardEntry>();
    }

    public ReactiveCollection<LeaderboardEntry> LeaderboardEntries { get; }

    public override async Task InitializeAsync()
    {
        var leadersCount = _leaderboardConfig.LeadersCountToShow;
        var leaders = await _leaderboadSelectService.SelectTopPlayersAsync(leadersCount);
        LeaderboardEntries.Initialize(leaders);
    }
}
