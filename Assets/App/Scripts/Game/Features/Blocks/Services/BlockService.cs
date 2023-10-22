using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Infrastructure.Ecs.Components;

namespace App.Scripts.Game.Features.Blocks.Services {
    public class BlockService : IBlockService {
        private readonly List<BlockView> _blockViews;
        
        public BlockService() {
            _blockViews = new List<BlockView>();
        }
        
        public IReadOnlyList<BlockView> BlockOnField() {
            return _blockViews;
        }

        public void AddBlock(BlockView blockView) {
            _blockViews.Add(blockView);
        }

        public void RemoveBlock(BlockView blockView) {
            _blockViews.Remove(blockView);
        }

        public BlockView FindById(Guid id) {
            return _blockViews.FirstOrDefault(x => {
                var component = x.Entity.GetComponent<ComponentBlockView>();
                return component.BlockId == id;
            });
        }
    }
}