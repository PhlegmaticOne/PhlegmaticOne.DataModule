using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using App.Scripts.Shared.Sounds.Services;

namespace App.Scripts.Game.Features.Sound.Components
{
    public class ComponentPlaySoundOnCut : IComponent
    {
        public SoundType SoundType;
    }
}