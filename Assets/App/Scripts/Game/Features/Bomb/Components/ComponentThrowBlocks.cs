using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Bomb.Components {
    public class ComponentThrowBlocks : ComponentRemoteBase {
        public float Force;
        public float Radius;
        public Vector3Tiny PositionWorld;
    }
}