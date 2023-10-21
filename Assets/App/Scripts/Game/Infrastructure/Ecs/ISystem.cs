namespace App.Scripts.Game.Infrastructure.Ecs {
    public interface ISystem {
        World World { get; set; }
        void OnAwake();
        void OnUpdate(float deltaTime);
        void OnFixedUpdate(float deltaTime);
        void OnDispose();
    }
}