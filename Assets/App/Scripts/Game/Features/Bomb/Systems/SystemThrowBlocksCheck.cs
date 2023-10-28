using App.Scripts.Game.Features.Bomb.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Bomb.Systems {
    public class SystemThrowBlocksCheck : SystemBase {
        private IComponentsFilter _filter;
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentThrowBlocksOnCut>()
                .With<ComponentBlockCut>()
                .Build();
        }
    }
}