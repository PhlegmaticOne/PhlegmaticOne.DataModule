using System;
using System.Threading.Tasks;

namespace App.Scripts.Game.Infrastructure.Session {
    public interface INetworkSession : IDisposable {
        event Action Disconnected;
        
        event Action<ArraySegment<byte>> DataReceived;
        Task StartAsync();
        void Tick();
        void SendMessage(ArraySegment<byte> message);
    }
}