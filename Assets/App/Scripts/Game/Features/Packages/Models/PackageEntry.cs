using App.Scripts.Game.Features.Blocks.Models;

namespace App.Scripts.Game.Features.Packages.Models {
    public class PackageEntry {
        public BlockType BlockType;
        public float TimeToNextBlock;
        public float CurrentTime;
        public float Gravity;
    }
}