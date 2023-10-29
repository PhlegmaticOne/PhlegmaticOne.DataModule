using App.Scripts.Game.Features.Bomb.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Bomb.Systems {
    public class SystemThrowBlocksCheck : SystemBase {
        private IComponentsFilter _componentsFilter;
        
        public override void OnAwake() {
            _componentsFilter = ComponentsFilter.Builder
                .With<ComponentThrowBlocksOnCut>()
                .With<ComponentBlockCut>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _componentsFilter.Apply(World)) {
                var componentThrowBlocksOnCut = entity.GetComponent<ComponentThrowBlocksOnCut>();
                var position = entity.GetComponent<ComponentBlock>().Block.transform.position;
            
                entity.AddComponent(new ComponentThrowBlocks {
                    Force = componentThrowBlocksOnCut.Force,
                    Radius = componentThrowBlocksOnCut.Radius,
                    PositionWorld = position,
                    IsRemote = false
                });
            }
        }
    }
}