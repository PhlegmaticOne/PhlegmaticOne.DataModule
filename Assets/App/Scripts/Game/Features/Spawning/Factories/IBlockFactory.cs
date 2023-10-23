using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Features.Spawning.Components;

namespace App.Scripts.Game.Features.Spawning.Factories {
    public interface IBlockFactory {
        Block CreateBlock(ComponentSpawnBlockData spawnBlockData);
    }
}