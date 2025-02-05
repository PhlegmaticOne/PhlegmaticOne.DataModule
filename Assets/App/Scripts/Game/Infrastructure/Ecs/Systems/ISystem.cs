﻿using App.Scripts.Game.Infrastructure.Ecs.Worlds;

namespace App.Scripts.Game.Infrastructure.Ecs.Systems {
    public interface ISystem {
        World World { get; set; }
        void OnAwake();
        void OnUpdate(float deltaTime);
        void OnFixedUpdate(float deltaTime);
        void OnDispose();
    }
}