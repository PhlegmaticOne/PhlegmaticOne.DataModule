using System.Threading.Tasks;
using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Menu.Features.Statistics.Dialog;
using Cysharp.Threading.Tasks;
using Firebase.Auth;
using PhlegmaticOne.ViewModels.Commands;

namespace App.Scripts.Menu.Features.Leaderboard.ViewModels
{
    public class LeaderboardEntryViewModel
    {
        private readonly IDialogsManager _dialogsManager;
        private readonly FirebaseUser _currentUser;
        
        public string UserName { get; private set; }
        public int GlobalScore { get; private set; }
        public string UserId { get; private set; }
        public bool IsCurrentUser => _currentUser.UserId == UserId;
        
        public IRelayCommand ShowStatisticsCommand { get; }

        public LeaderboardEntryViewModel(IDialogsManager dialogsManager)
        {
            _dialogsManager = dialogsManager;
            _currentUser = FirebaseAuth.DefaultInstance.CurrentUser;
            ShowStatisticsCommand = RelayCommandFactory.CreateEmptyAsyncCommand(ShowStatisticsDialog);
        }

        public LeaderboardEntryViewModel WithSetup(string userName, int globalScore, string userId)
        {
            UserName=userName;
            GlobalScore=globalScore;
            UserId = userId;
            return this;
        }

        private Task ShowStatisticsDialog()
        {
            return _dialogsManager.ShowDialog<StatisticsDialog>(d => d.UserId = UserId).AsTask();
        }
    }
}
