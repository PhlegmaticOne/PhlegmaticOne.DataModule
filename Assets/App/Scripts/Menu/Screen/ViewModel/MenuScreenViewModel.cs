using System.Threading.Tasks;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Menu.Services.Exit;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Screen.ViewModel {
    public class MenuScreenViewModel : BaseViewModel {
        private readonly IExitGameService _exitGameService;
        private readonly ISceneProvider _sceneProvider;

        public MenuScreenViewModel(IExitGameService exitGameService, ISceneProvider sceneProvider) {
            _exitGameService = exitGameService;
            _sceneProvider = sceneProvider;
            ExitCommand = RelayCommandFactory.CreateEmptyCommand(ExitGame);
            PlayCommand = RelayCommandFactory.CreateEmptyAsyncCommand(ShowStatistics);
        }
        
        public IRelayCommand ExitCommand { get; }
        public IRelayCommand PlayCommand { get; }

        private Task ShowStatistics() => _sceneProvider.LoadSceneAsync(SceneType.Game);
        private void ExitGame() => _exitGameService.Exit();
    }
}