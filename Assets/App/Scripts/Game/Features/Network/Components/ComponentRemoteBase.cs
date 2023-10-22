using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Network.Components {
    public abstract class ComponentRemoteBase : IComponent{
        public bool IsRemote;
    }
}