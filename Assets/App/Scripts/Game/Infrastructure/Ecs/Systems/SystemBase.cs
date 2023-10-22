using App.Scripts.Game.Infrastructure.Ecs.Worlds;

namespace App.Scripts.Game.Infrastructure.Ecs.Systems {
    public abstract class SystemBase : ISystem {
        public World World { get; set; }
        public virtual void OnAwake() { }
        public virtual void OnUpdate(float deltaTime) { }
        public virtual void OnFixedUpdate(float deltaTime) { }
        public virtual void OnDispose() { }
    }
}