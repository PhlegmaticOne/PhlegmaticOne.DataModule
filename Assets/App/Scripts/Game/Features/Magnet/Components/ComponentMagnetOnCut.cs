using System;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Magnet.Components {
    [Serializable]
    public class ComponentMagnetOnCut : IComponent {
        public float Radius;
        public float Time;
        public float Force;
        public float MagnetizedCenterRadius;
        public float ThrowPower;
    }
}