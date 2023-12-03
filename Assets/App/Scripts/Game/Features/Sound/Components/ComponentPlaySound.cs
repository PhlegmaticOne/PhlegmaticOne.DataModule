using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Shared.Sounds.Services;

namespace App.Scripts.Game.Features.Sound.Components
{
    public class ComponentPlaySound : ComponentRemoteBase
    {
        public SoundType SoundType;
        public bool IsPlayOnRemote;
    }
}