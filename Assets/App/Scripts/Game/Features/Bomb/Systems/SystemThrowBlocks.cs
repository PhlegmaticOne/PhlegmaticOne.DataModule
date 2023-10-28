using App.Scripts.Game.Features.Bomb.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.Bomb.Systems {
    public class SystemThrowBlocks : NetworkSystemBase<ComponentThrowBlocks> {
        protected SystemThrowBlocks(INetworkService networkService) : base(networkService) {
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder;
        }
    }
}