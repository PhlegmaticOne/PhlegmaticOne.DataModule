using System.Threading.Tasks;
using App.Scripts.Shared.Progress.Models;
using PhlegmaticOne.DataStorage.Storage;
using PhlegmaticOne.DataStorage.Storage.Base;

namespace App.Scripts.Shared.Progress.Services {
    public class PlayerScoreService : IPlayerScoreService {
        private readonly IDataStorage _dataStorage;

        private IValueSource<PlayerProgress> _playerProgress;
 
        public PlayerScoreService(IDataStorage dataStorage) {
            _dataStorage = dataStorage;
        }

        public async Task InitializeAsync() {
            _playerProgress = await _dataStorage.ReadAsync<PlayerProgress>();

            if (_playerProgress.NoValue()) {
                _playerProgress.SetRaw(PlayerProgress.Zero);
            }
        }

        public int MaxScore => _playerProgress.AsNoTrackable().MaxScore;
        
        public void ChangeMaxScore(int maxScore) {
            _playerProgress.AsTrackable().ChangeMaxScore(maxScore);
        }
    }
}