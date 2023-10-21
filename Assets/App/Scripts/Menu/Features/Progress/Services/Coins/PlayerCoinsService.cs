using System;
using System.Threading;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Progress.Models;
using Common.Models;
using PhlegmaticOne.DataStorage.Contracts;
using PhlegmaticOne.DataStorage.Storage.Base;

namespace App.Scripts.Menu.Features.Progress.Services.Coins {
    public class PlayerCoinsService : IPlayerCoinsService {
        private readonly IDataStorage _dataStorage;
        private IValueSource<PlayerState> _playerState;

        public PlayerCoinsService(IDataStorage dataStorage) {
            _dataStorage = dataStorage;
        }

        public event Action CoinsChanged;

        public async Task InitializeAsync() {
            _playerState = await _dataStorage.ReadAsync<PlayerState>();
        }

        public int CoinsCount => _playerState.AsNoTrackable().Coins;

        public void ChangeCoins(int coins) {
            _playerState.AsTrackable().ChangeCoins(coins);
        }
    }
}