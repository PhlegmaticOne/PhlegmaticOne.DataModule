using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Sound.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Sound.Systems
{
    public class SystemPlaySoundCheck : SystemBase
    {
        private IComponentsFilter _componentsFilter;
        
        public override void OnAwake()
        {
            _componentsFilter = ComponentsFilter.Builder
                .With<ComponentPlaySoundOnCut>()
                .With<ComponentBlockCut>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _componentsFilter.Apply(World))
            {
                var component = entity.GetComponent<ComponentPlaySoundOnCut>();
                
                entity.AddComponent(new ComponentPlaySound
                {
                    SoundType = component.SoundType,
                    IsPlayOnRemote = true
                });
            }
        }
    }
}