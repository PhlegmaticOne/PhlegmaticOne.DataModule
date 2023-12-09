using System;
using System.Threading.Tasks;
using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.Infrastructure.Session {
    public interface INetworkSession : IDisposable {
        event Action<ArraySegment<byte>> DataReceived;
        event Action<PlayerEndGameMessage> EndGameMessageReceived;
        Task StartAsync();
        Task<GameDataBase> ReceiveGameDataAsync();
        Task<PlayersSyncMessage> ReceiveSyncMessageAsync();
        void Tick();
        void SendMessage(ArraySegment<byte> message);
    }
}