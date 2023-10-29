using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Freezing.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Freezing.Systems {
    public class SystemFreezeCheck : SystemBase {
        private readonly INetworkService _networkService;
        
        private IComponentsFilter _filter;

        public SystemFreezeCheck(INetworkService networkService) {
            _networkService = networkService;
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentBlockCut>()
                .With<ComponentFreezeOnCut>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentFreezeOnCut = entity.GetComponent<ComponentFreezeOnCut>();

                World.AppendEntity().WithComponent(new ComponentFreezeActive {
                    Force = componentFreezeOnCut.Force,
                    Time = componentFreezeOnCut.Time,
                    IsRemote = false
                });
                
                _networkService.NetworkEntity.AddComponent(new ComponentFreezeMarker {
                    Time = componentFreezeOnCut.Time,
                    Force = componentFreezeOnCut.Force,
                    IsRemote = true
                });
            }
        }
    }
}