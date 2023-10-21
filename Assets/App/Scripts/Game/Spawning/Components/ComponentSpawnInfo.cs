using App.Scripts.Game.Blocks;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Spawning.Components {
    public class ComponentSpawnInfo : ComponentRemote<ComponentSpawnInfo> {
        public Vector3Tiny Acceleration;
        public Vector3Tiny Speed;
        public Vector3Tiny Position;
        public BlockType BlockType;
        
        public override ComponentSpawnInfo Clone() {
            return new ComponentSpawnInfo {
                Acceleration = Acceleration,
                Position = Position,
                Speed = Speed,
                BlockType = BlockType,
                IsRemote = IsRemote
            };
        }
    }
}