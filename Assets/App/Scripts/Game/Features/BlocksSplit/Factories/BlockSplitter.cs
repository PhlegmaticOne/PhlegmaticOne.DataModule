using System;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.Cutting.Configs;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Factories;
using UnityEngine;

namespace App.Scripts.Game.Features.BlocksSplit.Factories {
    public class BlockSplitter : IBlockSplitter {
        private readonly IBlockFactory _blockFactory;
        private readonly SplitBlocksConfig _config;

        public BlockSplitter(IBlockFactory blockFactory, SplitBlocksConfig config) {
            _blockFactory = blockFactory;
            _config = config;
        }
        
        public Block[] SplitBlock(SplitBlockFactoryData factoryData) {
            var block = factoryData.Original;
            var blockSprite = factoryData.ComponentSplitBlockOnCut.Sprite;
            var componentRemote = factoryData.ComponentSplitBlock;
            
            var texture = blockSprite.texture;
            var xPos = texture.width / 2.0f;
            var rightPivot = (texture.width - xPos) / texture.width;
            var leftPivot = 1.0f - rightPivot;
            var leftFruitPart = new Rect(0, 0, xPos, texture.height);
            var rightFruitPart = new Rect(xPos, 0, texture.width - xPos, texture.height);
            
            return new[] {
                SpawnBlock(blockSprite, rightFruitPart, rightPivot, block, componentRemote, 0),
                SpawnBlock(blockSprite, leftFruitPart, leftPivot, block, componentRemote, 180)
            };
        }
        
        private Block SpawnBlock(
            Sprite originalSprite, Rect fruitPart, float pivot, Block original,
            ComponentSplitBlock componentSplitBlock, float additionalNewBlockAngle) 
        {
            var spawnBlockData = CreateSpawnBlockData(original, componentSplitBlock, additionalNewBlockAngle);
            return _blockFactory.CreateBlock(spawnBlockData, new BlockConfigModel {
                Sprite = CreateSprite(originalSprite, fruitPart, pivot),
                Radius = 0,
                ParticleEffectColor = Color.clear,
                ScoreForSlicing = 0,
                Prefab = _config.Prefab
            });
        }

        private ComponentBlockSpawnData CreateSpawnBlockData(
            Block original, ComponentSplitBlock componentSplitBlock, float additionalNewBlockAngle) 
        {
            var componentGravity = original.Entity.GetComponent<ComponentGravity>();
            var speed = (Vector2)componentGravity.Speed + 
                        CalculateAdditionalSpeed(componentSplitBlock);
            var position = (Vector2)original.transform.position + 
                           GetBlockPartOffsetFromCenter(original, additionalNewBlockAngle);
            
            return new ComponentBlockSpawnData {
                BlockType = original.BlockData.Type,
                Acceleration = componentGravity.Acceleration,
                Speed = (Vector3)speed,
                BlockId = Guid.Empty,
                Position = (Vector3)position
            };
        }

        private static int GetDirectionBasedOnSlicingVectorAngleToXAxis(Vector2 slicingVector) {
            var angle = Vector3.Angle(slicingVector, Vector3.right);
            return angle >= 90 ? 1 : -1;
        }

        private static Vector2 GetBlockPartOffsetFromCenter(Block original, float additionalNewBlockAngle) {
            var originalTransform = original.transform;
            var halfRadius = originalTransform.localScale.x * 1.4f / 2;
            var zRotation = (originalTransform.rotation.eulerAngles.z + additionalNewBlockAngle) * Mathf.Deg2Rad;
            var dx = halfRadius * Mathf.Cos(zRotation);
            var dy = halfRadius * Mathf.Sin(zRotation);
            return new Vector2(dx, dy);
        }

        private static Vector2 CalculateAdditionalSpeed(ComponentSplitBlock componentSplitBlock) => 
            componentSplitBlock.CuttingVector.ToUnityVector().normalized;

        private static Sprite CreateSprite(Sprite originalSprite, Rect fruitPart, float pivot) => 
            Sprite.Create(originalSprite.texture, fruitPart, Vector2.one * pivot, originalSprite.pixelsPerUnit);
    }
}