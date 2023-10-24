using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Game.Features.Blocks.Services {
    public class BlockContainer : IBlockContainer {
        private readonly List<Block> _blockViews;
        public BlockContainer() => _blockViews = new List<Block>();
        public void AddBlock(Block block) => _blockViews.Add(block);
        public void RemoveBlock(Block block) => _blockViews.Remove(block);
        public Block FindById(Guid id) => _blockViews.FirstOrDefault(x => x.BlockData.Id == id);
    }
}