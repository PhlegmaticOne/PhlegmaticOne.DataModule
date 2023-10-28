using App.Scripts.Game.Features.Animations.Factories;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs.Spawners;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Factories {
    public class BlockFactory : IBlockFactory {
        private readonly SpawnersConfiguration _spawnersConfiguration;
        private readonly IBlockAnimationFactory _blockAnimationFactory;
        private readonly World _world;

        public BlockFactory(
            SpawnersConfiguration spawnersConfiguration, 
            IBlockAnimationFactory blockAnimationFactory,
            World world) {
            _spawnersConfiguration = spawnersConfiguration;
            _blockAnimationFactory = blockAnimationFactory;
            _world = world;
        }
        
        public Block CreateBlock(ComponentBlockSpawnData blockSpawnData, IBlockConfig blockConfig) {
            var block = CreateBlockPrivate(blockSpawnData, blockConfig);
            var entity = CreateBlockEntity(block, blockSpawnData);
            var data = CreateBlockData(blockSpawnData, blockConfig);
            block.Initialize(entity, data, blockSpawnData);
            return block;
        }

        private Block CreateBlockPrivate(ComponentBlockSpawnData blockSpawnData, IBlockConfig blockConfig) {
            var block = Object.Instantiate(blockConfig.Prefab, _spawnersConfiguration.SpawnTransform);
            block.transform.position = blockSpawnData.Position;
            return block;
        }

        private Entity CreateBlockEntity(Block block, ComponentBlockSpawnData spawnData) {
            var entity = _world.AppendEntity().WithComponent(new ComponentBlock { Block = block });
            return SetupEntityAnimations(entity, spawnData);
        }

        private Entity SetupEntityAnimations(Entity entity, ComponentBlockSpawnData spawnData) {
            var direction = (int)Mathf.Sign(spawnData.Speed.x);
            
            foreach (var animationComponent in _blockAnimationFactory
                         .CreateAnimationComponents(spawnData.AnimationType, direction)) {
                entity.AddComponentRaw(animationComponent);
            }

            return entity;
        }

        private static BlockData CreateBlockData(ComponentBlockSpawnData blockSpawnData, IBlockConfig config) {
            return new BlockData(blockSpawnData.BlockId, blockSpawnData.BlockType, config);
        }
    }
}