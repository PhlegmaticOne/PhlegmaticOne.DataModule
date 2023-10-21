using System;
using System.Threading.Tasks;

namespace App.Scripts.Menu.Features.Progress.Services.Coins {
    public interface IPlayerCoinsService {
        event Action CoinsChanged;
        Task InitializeAsync();
        int CoinsCount { get; }
        void ChangeCoins(int coins);
    }
}