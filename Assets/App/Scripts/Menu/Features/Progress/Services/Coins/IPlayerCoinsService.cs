using System;
using System.Threading.Tasks;

namespace App.Scripts.Menu.Features.Progress.Services.Coins {
    public interface IPlayerCoinsService {
        event Action CoinsChanged;
        int CoinsCount { get; }
        Task ChangeCoinsAsync(int coins);
    }
}