using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Components {
    public class ComponentCuttingVector : IComponent {
        public Vector3 CuttingVector;
        public Vector3 CuttingPoint;
    }
}