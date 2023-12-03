using System.Threading.Tasks;
using App.Scripts.Shared.Progress.Models;
using PhlegmaticOne.DataStorage.Storage;
using PhlegmaticOne.DataStorage.Storage.Base;

namespace App.Scripts.Shared.Progress.Services {
    public class PlayerService : IPlayerService
    {
        private readonly IDataStorage _dataStorage;

        private IValueSource<PlayerState> _playerProgress;
 
        public PlayerService(IDataStorage dataStorage) {
            _dataStorage = dataStorage;
        }

        public async Task InitializeAsync() {
            _playerProgress = await _dataStorage.ReadAsync<PlayerState>();

            if (_playerProgress.NoValue()) {
                var userName = Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.Email;
                var initialPlayer = PlayerState.Zero;
                initialPlayer.ChangeName(userName);
                _playerProgress.SetRaw(initialPlayer);
            }
        }

        public int MaxScore => _playerProgress.AsNoTrackable().MaxScore;

        public string UserName => _playerProgress.AsNoTrackable().Name;

        public void ChangeMaxScore(int maxScore) {
            _playerProgress.AsTrackable().ChangeMaxScore(maxScore);
        }

        public void ChangeName(string name)
        {
            _playerProgress.AsTrackable().ChangeName(name);
        }
    }
}