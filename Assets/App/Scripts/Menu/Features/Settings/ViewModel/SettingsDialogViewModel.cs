using App.Scripts.Shared.Progress.Services;
using App.Scripts.Shared.Sounds.Services;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;
using PhlegmaticOne.ViewModels.Properties;
using System.Threading.Tasks;

namespace Assets.App.Scripts.Menu.Features.Settings.ViewModel
{
    public class SettingsDialogViewModel : BaseViewModel
    {
        private readonly ISoundPlayService _soundPlayService;
        private readonly IPlayerService _playerService;

        public SettingsDialogViewModel(ISoundPlayService soundPlayService, IPlayerService playerService)
        {
            _soundPlayService = soundPlayService;
            _playerService = playerService;
            UserName = new ReactiveProperty<string>();
            MuteSound = new ReactiveProperty<bool>();
            SaveNameCommand = RelayCommandFactory.CreateEmptyCommand(SaveUserName);
        }

        public IRelayCommand SaveNameCommand { get; }

        public ReactiveProperty<string> UserName { get; }
        public ReactiveProperty<bool> MuteSound { get; }

        public override async Task InitializeAsync()
        {
            await _playerService.InitializeAsync();
            UserName.Value = _playerService.UserName;
            MuteSound.Value = _soundPlayService.IsMuted;
            MuteSound.PropertyChanged.AddListener(OnChangeSound);
        }

        protected override void OnDisposing()
        {
            UserName.PropertyChanged.RemoveAllListeners();
            MuteSound.PropertyChanged.RemoveAllListeners();
        }

        private void SaveUserName()
        {
            _playerService.ChangeName(UserName.Value);
        }

        private void OnChangeSound()
        {
            _soundPlayService.SetSoundMuted(MuteSound.Value);
        }
    }
}
