using System;
using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Views;

namespace App.Scripts.Game.Features.Blocks.Services {
    public interface IBlockService {
        IReadOnlyList<BlockView> BlockOnField();
        void AddBlock(BlockView blockView);
        void RemoveBlock(BlockView blockView);
        BlockView FindById(Guid id);
    }
}