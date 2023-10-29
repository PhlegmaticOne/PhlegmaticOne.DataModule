using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Magnet.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Magnet.Systems {
    public class SystemMagnetCheck : SystemBase {
        private readonly INetworkService _networkService;
        
        private IComponentsFilter _filter;

        public SystemMagnetCheck(INetworkService networkService) {
            _networkService = networkService;
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentBlockCut>()
                .With<ComponentMagnetOnCut>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentMagnetOnCut = entity.GetComponent<ComponentMagnetOnCut>();
                var position = entity.GetComponent<ComponentBlock>().Block.transform.position.WithZ(0);

                World.AppendEntity().WithComponent(new ComponentMagnetActive {
                    Force = componentMagnetOnCut.Force,
                    Time = componentMagnetOnCut.Time,
                    Radius = componentMagnetOnCut.Radius,
                    MagnetizedCenterRadius = componentMagnetOnCut.MagnetizedCenterRadius,
                    ThrowPower = componentMagnetOnCut.ThrowPower,
                    PositionWorld = position,
                    IsRemote = false
                });
                
                _networkService.NetworkEntity.AddComponent(new ComponentMagnetMarker {
                    Time = componentMagnetOnCut.Time,
                    Force = componentMagnetOnCut.Force,
                    Radius = componentMagnetOnCut.Radius,
                    MagnetizedCenterRadius = componentMagnetOnCut.MagnetizedCenterRadius,
                    ThrowPower = componentMagnetOnCut.ThrowPower,
                    PositionWorld = ((Vector3Tiny)position).InvertX(),
                    IsRemote = true
                });
            }
        }
    }
}