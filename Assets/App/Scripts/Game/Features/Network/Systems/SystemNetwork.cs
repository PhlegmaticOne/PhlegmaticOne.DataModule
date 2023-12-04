using System;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Infrastructure.Session;

namespace App.Scripts.Game.Features.Network.Systems {
    public class SystemNetwork : SystemBase {
        private readonly INetworkSession _networkSession;
        private readonly INetworkService _networkService;

        public SystemNetwork(INetworkSession networkSession, 
            INetworkService networkService) {
            _networkSession = networkSession;
            _networkService = networkService;
            _networkSession.DataReceived += OnData;
        }

        public override void OnUpdate(float deltaTime) {
            _networkSession.Tick();

            if (_networkService.NetworkEntity.ComponentsCount <= 1) {
                return;
            }
            
            var message = _networkService.CreateMessage();
            _networkSession.SendMessage(message);
        }

        public override void OnDispose() {
            //_networkSession.Dispose();
        }

        private void OnData(ArraySegment<byte> message) {
            var entity = _networkService.CreateEntityFromRemoteMessage(message);
            World.AppendEntity(entity).WithComponent(new ComponentRemoveEntityEndOfFrame());
        }
    }
}