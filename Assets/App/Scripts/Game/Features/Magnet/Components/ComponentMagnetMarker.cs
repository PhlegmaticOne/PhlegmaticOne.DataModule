using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Magnet.Components {
    public class ComponentMagnetMarker : ComponentRemoteBase {
        public float Radius;
        public float Time;
        public float Force;
        public float MagnetizedCenterRadius;
        public float ThrowPower;
        public Vector3Tiny PositionWorld;
    }
}