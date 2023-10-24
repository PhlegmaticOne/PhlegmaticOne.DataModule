using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.BlocksSplit.Systems {
    public class SystemCuttingCheckSplitBlocks : SystemBase {
        private IComponentsFilter _filter;
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentSplitBlockOnCut>()
                .With<ComponentBlockCut>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                entity.AddComponent(new ComponentSplitBlock {
                    CuttingVector = entity.GetComponent<ComponentBlockCut>().CuttingVector
                });
            }
        }
    }
}