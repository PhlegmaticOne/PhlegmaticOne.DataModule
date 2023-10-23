using System;
using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Views;

namespace App.Scripts.Game.Features.Blocks.Services {
    public interface IBlockService {
        IReadOnlyList<Block> BlockOnField();
        void AddBlock(Block block);
        void RemoveBlock(Block block);
        Block FindById(Guid id);
    }
}