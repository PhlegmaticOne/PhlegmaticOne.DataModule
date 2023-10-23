using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs.Spawners;
using App.Scripts.Game.Infrastructure.Ecs.Components;
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
            var block = Object.Instantiate(_spawnersConfiguration.Prefab, _spawnersConfiguration.SpawnTransform);
            block.transform.position = spawnBlockData.Position;
            
            var entity = _world.AppendEntity();
            entity.AddComponent(new ComponentGravity {
                Acceleration = spawnBlockData.Acceleration,
                Speed = spawnBlockData.Speed
            });
            entity.AddComponent(new ComponentBlock {
                Block = block
            });

            var config = _blockConfigsProvider.GetConfig(spawnBlockData.BlockType);
            block.SetSprite(config.Sprite);
            block.Entity = entity;
            block.BlockData = new BlockData(spawnBlockData.BlockId, spawnBlockData.BlockType, config);

            return block;
        }
    }
}