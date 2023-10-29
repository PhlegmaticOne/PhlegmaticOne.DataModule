using System;
using System.Collections.Generic;

namespace App.Scripts.Game.Features.Blocks.Services {
    public interface IBlockContainer : IEnumerable<Block> {
        void AddBlock(Block block);
        void RemoveBlock(Block block);
        Block FindById(Guid id);
    }
}