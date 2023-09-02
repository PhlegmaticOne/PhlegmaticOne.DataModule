using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Menu.Features.Statistics.Dialog;
using App.Scripts.Menu.Services.Exit;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Screen.ViewModel {
    public class MenuScreenViewModel : BaseViewModel {
        private readonly IExitGameService _exitGameService;
        private readonly IDialogsManager _dialogsManager;

        public MenuScreenViewModel(IExitGameService exitGameService, IDialogsManager dialogsManager) {
            _exitGameService = exitGameService;
            _dialogsManager = dialogsManager;
            ExitCommand = RelayCommandFactory.CreateEmptyCommand(ExitGame);
            PlayCommand = RelayCommandFactory.CreateEmptyCommand(ShowStatistics);
        }
        
        public IRelayCommand ExitCommand { get; }
        public IRelayCommand PlayCommand { get; }

        private void ShowStatistics() => _dialogsManager.ShowDialog<StatisticsDialog>();
        private void ExitGame() => _exitGameService.Exit();
    }
}