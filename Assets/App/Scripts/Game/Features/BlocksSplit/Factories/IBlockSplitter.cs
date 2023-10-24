using App.Scripts.Game.Features.Blocks;

namespace App.Scripts.Game.Features.BlocksSplit.Factories {
    public interface IBlockSplitter {
        Block[] SplitBlock(SplitBlockFactoryData factoryData);
    }
}