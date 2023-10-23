using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Features.Blocks.Views;

namespace App.Scripts.Game.Features.Blocks.Services {
    public class BlockService : IBlockService {
        private readonly List<Block> _blockViews;
        
        public BlockService() {
            _blockViews = new List<Block>();
        }
        
        public IReadOnlyList<Block> BlockOnField() {
            return _blockViews;
        }

        public void AddBlock(Block block) {
            _blockViews.Add(block);
        }

        public void RemoveBlock(Block block) {
            _blockViews.Remove(block);
        }

        public Block FindById(Guid id) {
            return _blockViews.FirstOrDefault(x => x.BlockData.Id == id);
        }
    }
}