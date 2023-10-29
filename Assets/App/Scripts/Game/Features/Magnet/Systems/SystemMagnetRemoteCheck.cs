using App.Scripts.Game.Features.Magnet.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;

namespace App.Scripts.Game.Features.Magnet.Systems {
    public class SystemMagnetRemoteCheck : NetworkSystemBase<ComponentMagnetMarker> {
        
        protected SystemMagnetRemoteCheck(INetworkService networkService) : base(networkService) { }

        protected override void OnRemoteUpdate(Entity entity, ComponentMagnetMarker componentRemote, float deltaTime) {
            World.AppendEntity().WithComponent(new ComponentMagnetActive {
                Force = componentRemote.Force,
                Time = componentRemote.Time,
                Radius = componentRemote.Radius,
                MagnetizedCenterRadius = componentRemote.MagnetizedCenterRadius,
                ThrowPower = componentRemote.ThrowPower,
                PositionWorld = componentRemote.PositionWorld,
                IsRemote = true
            });
        }
    }
}