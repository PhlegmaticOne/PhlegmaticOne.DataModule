using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Physics.Components {
    public class ComponentGravity : IComponent {
        public Vector3 Speed;
        public Vector3 StartSpeed;
        public Vector3 Acceleration;
    }
}