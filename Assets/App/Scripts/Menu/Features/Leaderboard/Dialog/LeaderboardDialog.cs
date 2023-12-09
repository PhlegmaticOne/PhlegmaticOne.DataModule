using App.Scripts.Common.Dialogs;
using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Leaderboard.ViewModels;
using UnityEngine;

namespace Assets.App.Scripts.Menu.Features.Leaderboard.Dialog
{
    public class LeaderboardDialog : BaseDialogController
    {
        [SerializeField] private ViewModelView<LeaderboardViewModel> _leaderboardView;

        protected override Task OnShowing()
        {
            return _leaderboardView.InitializeAsync();
        }

        protected override void OnClosing()
        {
            _leaderboardView.Dispose();
        }
    }
}
