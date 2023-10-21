using System;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Network {
    public class SystemNetwork : SystemBase {
        private readonly NetworkService _networkService;
        private readonly Telepathy.Client _client = new(16384);

        public SystemNetwork(NetworkService networkService) {
            _networkService = networkService;
        }
        
        public override void OnAwake() {
            Application.runInBackground = true;
            _client.OnConnected = () => Debug.Log("Client Connected");
            _client.OnDisconnected = () => Debug.Log("Client Disconnected");
            _client.OnData = OnData;
            _client.Connect("localhost", 8888);
            _networkService.Setup(World.CreateEntity());
        }

        public override void OnUpdate(float deltaTime) {
            _client.Tick(100);
            
            if (_networkService.NetworkEntity.ComponentsCount > 1) {
                var message = _networkService.CreateMessage();
                _client.Send(message);
            }
        }

        public override void OnDispose() {
            _client.Disconnect();
        }

        private void OnData(ArraySegment<byte> message) {
            var entity = _networkService.FromMessage(message);
            World.AppendEntity(entity.WithComponent(new ComponentRemoveEntityEndOfFrame()));
        }
    }
}