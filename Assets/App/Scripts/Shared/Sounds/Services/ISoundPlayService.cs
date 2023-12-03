using App.Scripts.Game.Features.Sound.Components;

namespace App.Scripts.Shared.Sounds.Services
{
    public interface ISoundPlayService
    {
        void PlaySound(SoundType soundType);
    }
}