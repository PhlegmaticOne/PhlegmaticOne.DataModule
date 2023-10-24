using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.BlocksSplit.Factories.Data;

namespace App.Scripts.Game.Features.BlocksSplit.Factories {
    public interface IBlockSplitter {
        Block[] SplitBlock(SplitBlockFactoryData factoryData);
    }
}