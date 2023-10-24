using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs.Spawners;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Factories {
    public class BlockFactory : IBlockFactory {
        private readonly SpawnersConfiguration _spawnersConfiguration;
        private readonly World _world;

        public BlockFactory(
            SpawnersConfiguration spawnersConfiguration, 
            World world) {
            _spawnersConfiguration = spawnersConfiguration;
            _world = world;
        }
        
        public Block CreateBlock(ComponentBlockSpawnData blockSpawnData, IBlockConfig blockConfig) {
            var block = CreateBlockPrivate(blockSpawnData, blockConfig);
            var entity = CreateBlockEntity(block);
            var data = CreateBlockData(blockSpawnData, blockConfig);
            block.Initialize(entity, data, blockSpawnData);
            return block;
        }

        private Block CreateBlockPrivate(ComponentBlockSpawnData blockSpawnData, IBlockConfig blockConfig) {
            var block = Object.Instantiate(blockConfig.Prefab, _spawnersConfiguration.SpawnTransform);
            block.transform.position = blockSpawnData.Position;
            return block;
        }

        private Entity CreateBlockEntity(Block block) {
            return _world.AppendEntity().WithComponent(new ComponentBlock {
                Block = block
            });
        }

        private static BlockData CreateBlockData(ComponentBlockSpawnData blockSpawnData, IBlockConfig config) {
            return new BlockData(blockSpawnData.BlockId, blockSpawnData.BlockType, config);
        }
    }
}