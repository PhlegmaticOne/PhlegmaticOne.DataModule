using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Leaderboard.ViewModels;
using App.Scripts.Menu.Features.Leaderboard.Views;
using UnityEngine;

namespace Assets.App.Scripts.Menu.Features.Leaderboard.Views
{
    public class LeaderboardViewModelView : ViewModelViewInject<LeaderboardViewModel>
    {
        [SerializeField] private LeaderboardListView _leaderboardList;

        protected override void OnInitializing()
        {
            _leaderboardList.Setup(ViewModel.LeaderboardEntries);
        }

        protected override void OnDisposing()
        {
            _leaderboardList.Dispose();
        }
    }
}
