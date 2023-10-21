using App.Scripts.Game.Infrastructure.Ecs;
using UnityEngine;

namespace App.Scripts.Game.Physics {
    public struct GravityComponent : IComponent {
        public const float BaseAcceleration = 8f;
        public Vector3 Speed;
        public Vector3 Acceleration;
    }
}