using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Common {
    public abstract class ComponentRemote<TSelf> : IComponent where TSelf : ComponentRemote<TSelf> {
        public bool IsRemote;
        public abstract TSelf ToRemote();
    }
}