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
        private readonly BlockConfigsProvider _blockConfigsProvider;
        private readonly SpawnersConfiguration _spawnersConfiguration;
        private readonly World _world;

        public BlockFactory(
            BlockConfigsProvider blockConfigsProvider,
            SpawnersConfiguration spawnersConfiguration, 
            World world) {
            _blockConfigsProvider = blockConfigsProvider;
            _spawnersConfiguration = spawnersConfiguration;
            _world = world;
        }
        
        public Block CreateBlock(ComponentSpawnBlockData spawnBlockData) {
            var block = CreateBlockPrivate(spawnBlockData);
            var data = CreateBlockData(spawnBlockData);
            var entity = CreateBlockEntity(block);
            block.Initialize(entity, data, spawnBlockData);
            return block;
        }

        private Block CreateBlockPrivate(ComponentSpawnBlockData spawnBlockData) {
            var config = _blockConfigsProvider.GetConfig(spawnBlockData.BlockType);
            var block = Object.Instantiate(config.Prefab, _spawnersConfiguration.SpawnTransform);
            block.transform.position = spawnBlockData.Position;
            return block;
        }

        private Entity CreateBlockEntity(Block block) {
            return _world.AppendEntity().WithComponent(new ComponentBlock {
                Block = block
            });
        }

        private BlockData CreateBlockData(ComponentSpawnBlockData spawnBlockData) {
            var config = _blockConfigsProvider.GetConfig(spawnBlockData.BlockType);
            return new BlockData(spawnBlockData.BlockId, spawnBlockData.BlockType, config);
        }
    }
}