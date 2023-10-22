using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Components {
    public class ComponentSpawnInfo : ComponentRemote<ComponentSpawnInfo> {
        public Vector3Tiny Acceleration;
        public Vector3Tiny Speed;
        public Vector3Tiny Position;
        public BlockType BlockType;

        public override ComponentSpawnInfo ToRemote() {
            return new ComponentSpawnInfo {
                Acceleration = Acceleration,
                Position = new Vector3Tiny(-Position.x, Position.y, Position.z),
                Speed = new Vector3Tiny(-Speed.x, Speed.y, Speed.z),
                BlockType = BlockType,
                IsRemote = true
            };
        }
    }
}