using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Particles.Systems {
    public class SystemCheckSpawnParticles : SystemBase {
        private IComponentsFilter _filter;
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentBlockCut>()
                .With<ComponentSpawnParticleOnCut>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                entity.AddComponent(new ComponentSpawnParticle());
            }
        }
    }
}