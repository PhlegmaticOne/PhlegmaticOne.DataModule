using System;
using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features.Animations.Models;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.BlocksSplit.Configs;
using App.Scripts.Game.Features.BlocksSplit.Factories.Data;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Factories;
using UnityEngine;

namespace App.Scripts.Game.Features.BlocksSplit.Factories {
    public class BlockSplitter : IBlockSplitter {
        private readonly IBlockFactory _blockFactory;
        private readonly BlockSplitConfig _config;

        public BlockSplitter(IBlockFactory blockFactory, BlockSplitConfig config) {
            _blockFactory = blockFactory;
            _config = config;
        }
        
        public Block[] SplitBlock(SplitBlockFactoryData factoryData) {
            var block = factoryData.Original;
            var blockSprite = factoryData.ComponentSplitBlockOnCut.Sprite;
            var componentRemote = factoryData.ComponentSplitBlock;
            var splitSprites = blockSprite.Split();
            return new[] {
                SpawnBlock(splitSprites[0], block, componentRemote, 0),
                SpawnBlock(splitSprites[1], block, componentRemote, 180)
            };
        }
        
        private Block SpawnBlock(Sprite newSprite, Block original, ComponentSplitBlock componentSplitBlock, float addAngle) {
            var spawnBlockData = CreateSpawnBlockData(original, componentSplitBlock, addAngle);
            var config = BlockConfigModel.WithNewSpriteAndPrefab(newSprite, _config.Prefab);
            var block = _blockFactory.CreateBlock(spawnBlockData, config);
            return block.TakeTransformValues(original.transform);
        }

        private ComponentBlockSpawnData CreateSpawnBlockData(Block original, ComponentSplitBlock splitBlock, float addAngle) {
            var componentGravity = original.Entity.GetComponent<ComponentGravity>();
            var newSpeed = GetSplitBlockSpeed(componentGravity.Speed, splitBlock);
            var newPosition = original.transform.GetSplitOffsetFromCenter(original.Config.Radius, addAngle);
            
            return new ComponentBlockSpawnData {
                BlockId = Guid.Empty,
                Speed = (Vector3)newSpeed,
                Position = (Vector3)newPosition,
                BlockType = original.BlockData.Type,
                Acceleration = componentGravity.Acceleration,
                AnimationType = BlockAnimationType.Rotation,
                DeltaTimeDivider = componentGravity.DeltaTimeDivider,
                IsRemote = original.IsRemote
            };
        }

        private Vector2 GetSplitBlockSpeed(Vector3 currentSpeed, ComponentSplitBlock componentSplitBlock) {
            var direction = componentSplitBlock.CuttingVector.ToUnityVector().normalized;
            return currentSpeed + direction * _config.SliceDirectionForce;
        }
    }
}