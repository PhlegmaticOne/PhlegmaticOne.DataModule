using App.Scripts.Game.Features.Freezing.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;

namespace App.Scripts.Game.Features.Freezing.Systems {
    public class SystemFreezeRemoteCheck : NetworkSystemBase<ComponentFreezeMarker> {
        protected SystemFreezeRemoteCheck(INetworkService networkService) : base(networkService) { }

        protected override void OnRemoteUpdate(Entity entity, ComponentFreezeMarker componentRemote, float deltaTime) {
            World.AppendEntity().WithComponent(new ComponentFreezeActive {
                Force = componentRemote.Force,
                Time = componentRemote.Time,
                IsRemote = true
            });
        }
    }
}