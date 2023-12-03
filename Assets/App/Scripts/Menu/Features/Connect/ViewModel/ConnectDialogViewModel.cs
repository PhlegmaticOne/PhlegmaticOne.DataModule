using App.Scripts.Common.Dialogs;
using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Common.Scenes.Base;
using Assets.App.Scripts.Common.Dialogs;
using Assets.App.Scripts.Shared.Network;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;
using PhlegmaticOne.ViewModels.Properties;
using System.Threading.Tasks;

namespace Assets.App.Scripts.Menu.Features.Connect.ViewModel
{
    public class ConnectDialogViewModel : BaseViewModel
    {
        private readonly IDialogsManager _dialogsManager;
        private readonly ISceneProvider _sceneProvider;
        private readonly INetworkDataProvider _networkDataProvider;

        public ConnectDialogViewModel(
            IDialogsManager dialogsManager,
            ISceneProvider sceneProvider,
            INetworkDataProvider networkDataProvider)
        {
            _dialogsManager=dialogsManager;
            _sceneProvider=sceneProvider;
            _networkDataProvider=networkDataProvider;
            Address = new ReactiveProperty<string>();
            Port = new ReactiveProperty<int>();
            TestNotConnect = new ReactiveProperty<bool>();
            SubmitCommand = RelayCommandFactory.CreateEmptyAsyncCommand(StartGame);
        }

        public ReactiveProperty<string> Address { get; }
        public ReactiveProperty<int> Port { get; }
        public ReactiveProperty<bool> TestNotConnect { get; }
        public IRelayCommand SubmitCommand { get; }

        public override Task InitializeAsync()
        {
            Address.Value = "localhost";
            Port.Value = 8888;
            TestNotConnect.Value = false;
            return Task.CompletedTask;
        }

        private async Task StartGame()
        {
            _networkDataProvider.NetworkData = new NetworkData(Address, Port, TestNotConnect);
            await _dialogsManager.CloseLastDialog();
            await _sceneProvider.LoadSceneAsync(SceneType.Game);
        }
    }
}
