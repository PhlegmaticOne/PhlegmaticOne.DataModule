using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Physics {
    public class ComponentGravity : IComponent {
        public Vector3 Speed;
        public Vector3 Acceleration;
    }
}