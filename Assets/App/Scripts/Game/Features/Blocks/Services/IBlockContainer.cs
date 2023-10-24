using System;

namespace App.Scripts.Game.Features.Blocks.Services {
    public interface IBlockContainer {
        void AddBlock(Block block);
        void RemoveBlock(Block block);
        Block FindById(Guid id);
    }
}