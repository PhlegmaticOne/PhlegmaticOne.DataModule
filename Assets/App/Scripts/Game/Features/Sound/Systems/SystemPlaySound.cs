using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Sound.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Shared.Sounds.Services;

namespace App.Scripts.Game.Features.Sound.Systems
{
    public class SystemPlaySound : NetworkSystemBase<ComponentPlaySound>
    {
        private readonly ISoundPlayService _soundPlayService;
        
        protected SystemPlaySound(INetworkService networkService, ISoundPlayService soundPlayService) : base(networkService)
        {
            _soundPlayService = soundPlayService;
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder)
        {
            return builder.With<ComponentPlaySound>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime)
        {
            var componentSoundType = entity.GetComponent<ComponentPlaySound>();
            PlaySound(componentSoundType);
            AddRemoteComponent(componentSoundType);
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentPlaySound componentPlayRemote, float deltaTime)
        {
            PlaySound(componentPlayRemote);
        }

        private void PlaySound(ComponentPlaySound componentPlaySound)
        {
            var soundType = componentPlaySound.SoundType;
            _soundPlayService.PlaySound(soundType);
        }
    }
}