using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Infrastructure.Ecs.Components.Base {
    public static class ComponentRemoteExtensions {
        public static T AsRemote<T>(this T component) where T : ComponentRemote<T> {
            var newComponent = component.Clone();
            newComponent.IsRemote = true;
            return newComponent;
        }
        
        public static T AsLocal<T>(this T component) where T : ComponentRemote<T> {
            var newComponent = component.Clone();
            newComponent.IsRemote = false;
            return newComponent;
        }
    }
    
    public abstract class ComponentRemote<TSelf> : IComponent, ICloneable<TSelf> where TSelf : ComponentRemote<TSelf> {
        public bool IsRemote;
        public abstract TSelf Clone();
    }
}