using System.Threading.Tasks;
using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Menu.Services.Exit;
using Assets.App.Scripts.Menu.Features.Leaderboard.Dialog;
using Cysharp.Threading.Tasks;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Screen.ViewModel
{
    public class MenuScreenViewModel : BaseViewModel {
        private readonly IExitGameService _exitGameService;
        private readonly ISceneProvider _sceneProvider;
        private readonly IDialogsManager _dialogsManager;

        public MenuScreenViewModel(
            IExitGameService exitGameService, 
            ISceneProvider sceneProvider,
            IDialogsManager dialogsManager) 
        {
            _exitGameService = exitGameService;
            _sceneProvider = sceneProvider;
            _dialogsManager=dialogsManager;
            ExitCommand = RelayCommandFactory.CreateEmptyCommand(ExitGame);
            PlayCommand = RelayCommandFactory.CreateEmptyAsyncCommand(StartGame);
            ShowStatisticsCommand = RelayCommandFactory.CreateEmptyAsyncCommand(ShowStatisticsDialog);
        }
        
        public IRelayCommand ExitCommand { get; }
        public IRelayCommand PlayCommand { get; }
        public IRelayCommand ShowStatisticsCommand { get; }

        private Task StartGame() => _sceneProvider.LoadSceneAsync(SceneType.Game);
        private void ExitGame() => _exitGameService.Exit();
        private Task ShowStatisticsDialog()
        {
            return _dialogsManager.ShowDialog<LeaderboardDialog>().AsTask();
        }
    }
}