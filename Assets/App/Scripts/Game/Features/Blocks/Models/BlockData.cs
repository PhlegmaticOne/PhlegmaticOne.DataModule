using System;
using App.Scripts.Game.Features.Blocks.Configs;

namespace App.Scripts.Game.Features.Blocks.Models {
    public class BlockData {
        public BlockData(Guid id, BlockType type, IBlockConfig blockConfig) {
            Id = id;
            Type = type;
            BlockConfig = blockConfig;
        }

        public Guid Id { get; }
        public BlockType Type { get; }
        public IBlockConfig BlockConfig { get; }
    }
}