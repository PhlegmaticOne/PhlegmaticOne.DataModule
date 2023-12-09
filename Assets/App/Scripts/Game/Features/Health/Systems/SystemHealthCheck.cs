using App.Scripts.Game.Features.Health.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Health.Systems
{
    public class SystemHealthCheck : SystemBase
    {
        private IComponentsFilter _componentsFilter;
        public override void OnAwake()
        {
            _componentsFilter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .With<ComponentHealthable>()
                .Without<ComponentHealthLost>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _componentsFilter.Apply(World))
            {
                var block = entity.GetComponent<ComponentBlock>().Block;

                if (block.transform.position.x < 0 && !block.IsRemote)
                {
                    entity.AddComponent(new ComponentHealthLost());
                    
                    World.AppendEntity()
                        .WithComponent(new ComponentLoseHealth())
                        .RemoveEndOfFrame();
                }
            }
        }
    }
}