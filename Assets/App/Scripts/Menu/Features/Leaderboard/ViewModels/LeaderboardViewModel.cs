using System.Threading.Tasks;
using Assets.App.Scripts.Menu.Features.Leaderboard.Configs;
using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Features.Leaderboard.ViewModels
{
    public class LeaderboardViewModel : BaseViewModel
    {
        private readonly ILeaderboadSelectService _leaderboardSelectService;
        private readonly LeaderboardConfig _leaderboardConfig;

        public LeaderboardViewModel(ILeaderboadSelectService leaderboardSelectService, LeaderboardConfig leaderboardConfig)
        {
            _leaderboardSelectService=leaderboardSelectService;
            _leaderboardConfig=leaderboardConfig;
            LeaderboardEntries = new ReactiveCollection<LeaderboardEntryViewModel>();
        }

        public ReactiveCollection<LeaderboardEntryViewModel> LeaderboardEntries { get; }

        public override async Task InitializeAsync()
        {
            var leadersCount = _leaderboardConfig.LeadersCountToShow;
            var leaders = await _leaderboardSelectService.SelectTopPlayersAsync(leadersCount);
            LeaderboardEntries.Initialize(leaders);
        }
    }
}
