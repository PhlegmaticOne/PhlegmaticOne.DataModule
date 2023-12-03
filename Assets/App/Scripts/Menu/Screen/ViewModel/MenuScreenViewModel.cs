using System.Threading.Tasks;
using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Menu.Features.Statistics.Dialog;
using App.Scripts.Menu.Services.Exit;
using Assets.App.Scripts.Menu.Features.Connect.Dialog;
using Assets.App.Scripts.Menu.Features.Leaderboard.Dialog;
using Assets.App.Scripts.Menu.Features.Settings.Dialog;
using Cysharp.Threading.Tasks;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Screen.ViewModel
{
    public class MenuScreenViewModel : BaseViewModel {
        private readonly IExitGameService _exitGameService;
        private readonly IDialogsManager _dialogsManager;

        public MenuScreenViewModel(
            IExitGameService exitGameService, 
            IDialogsManager dialogsManager) 
        {
            _exitGameService = exitGameService;
            _dialogsManager=dialogsManager;
            ExitCommand = RelayCommandFactory.CreateEmptyCommand(ExitGame);
            PlayCommand = RelayCommandFactory.CreateEmptyAsyncCommand(StartGame);
            ShowStatisticsCommand = RelayCommandFactory.CreateEmptyAsyncCommand(ShowStatisticsDialog);
            ShowLeaderboardCommand = RelayCommandFactory.CreateEmptyAsyncCommand(ShowLeaderboardDialog);
            ShowSettingsCommand = RelayCommandFactory.CreateEmptyAsyncCommand(ShowSettingsDialog);
        }
        
        public IRelayCommand ExitCommand { get; }
        public IRelayCommand PlayCommand { get; }
        public IRelayCommand ShowStatisticsCommand { get; }
        public IRelayCommand ShowLeaderboardCommand { get; }
        public IRelayCommand ShowSettingsCommand { get; }

        private void ExitGame() => _exitGameService.Exit();

        private Task StartGame()
        {
            return _dialogsManager.ShowDialog<ConnectDialog>().AsTask();
        }

        private Task ShowStatisticsDialog()
        {
            return _dialogsManager.ShowDialog<StatisticsDialog>().AsTask();
        }

        private Task ShowLeaderboardDialog()
        {
            return _dialogsManager.ShowDialog<LeaderboardDialog>().AsTask();
        }

        private Task ShowSettingsDialog()
        {
            return _dialogsManager.ShowDialog<SettingsDialog>().AsTask();
        }
    }
}