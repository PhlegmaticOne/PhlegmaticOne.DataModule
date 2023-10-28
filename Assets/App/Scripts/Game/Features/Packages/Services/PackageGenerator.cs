using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Difficulty.Services;
using App.Scripts.Game.Features.Packages.Components;
using App.Scripts.Game.Features.Packages.Models;
using App.Scripts.Game.Features.Spawning.Configs.Blocks;
using App.Scripts.Game.Features.Spawning.Configs.Blocks.Data;
using App.Scripts.Game.Infrastructure.Random;
using UnityEngine;

namespace App.Scripts.Game.Features.Packages.Services {
    public class PackageGenerator : IPackageGenerator {
        private readonly SpawnSystemConfiguration _spawnSystemConfiguration;

        public PackageGenerator(SpawnSystemConfiguration spawnSystemConfiguration) {
            _spawnSystemConfiguration = spawnSystemConfiguration;
        }
        
        public ComponentPackage GeneratePackage(DifficultyData difficultyData) {
            var result = new List<PackageEntry>();

            TryAddExtraBlocks(result, difficultyData, difficultyData.TotalDebufsSpawnPercentage, _spawnSystemConfiguration.ExtraBlockSpawnData);

            var blocksInPackage = difficultyData.BlocksInPackageCount;
            
            while (result.Count <  blocksInPackage) {
                result.Add(new PackageEntry {
                    BlockType = GetRandomFruit(),
                    TimeToNextBlock = GetRandomTimeToNextBlock(difficultyData)
                });
            }
            
            return new ComponentPackage {
                PackageEntries = result,
                CurrentItemIndex = -1,
                WaitBeforePackage = difficultyData.TimeToNextBlockPackage,
                CurrentWaitTime = 0
            };
        }
        
        private BlockType GetRandomFruit() => 
            _spawnSystemConfiguration.FruitSpawnData.GetRandomItemBasedOnProbabilities().Key;

        private void TryAddExtraBlocks(List<PackageEntry> blocksPackage, 
            DifficultyData difficultyInfo,
            float totalSpawnPercentage,
            IDictionary<BlockType, ExtraBlockSpawnData> blockConfigurations)
        {
            var blocksInPackage = difficultyInfo.BlocksInPackageCount;
            
            foreach (var extraBlockInfo in blockConfigurations)
            {
                var blockInfo = extraBlockInfo.Key;

                if (ProbabilityMatches(totalSpawnPercentage) == false) {
                    continue;
                }
                
                if (ProbabilityMatches(extraBlockInfo.Value.SpawnInPackageProbability) == false) {
                    continue;
                }
                
                var randomBlocksCount =
                    GetRandomBlocksCountFromPercentage(extraBlockInfo.Value.SpawnCountInPackagePercentage, blocksInPackage);

                while (randomBlocksCount > 0 && blocksPackage.Count <=  blocksInPackage)
                {
                    blocksPackage.Add(new PackageEntry
                    {
                        BlockType = blockInfo,
                        TimeToNextBlock = GetRandomTimeToNextBlock(difficultyInfo)
                    });
                    randomBlocksCount--;
                }
            }
        }

        private int GetRandomBlocksCountFromPercentage(float percentage, int blocksCount) {
            var maxCount = (int)Mathf.Ceil(blocksCount * percentage);
            return Random.Range(0, maxCount + 1);
        }

        private float GetRandomTimeToNextBlock(DifficultyData difficultyInfo) {
            var packageSpawnData = _spawnSystemConfiguration.PackageSpawnData;
            return Random.Range(
                packageSpawnData.SpawnBlockInPackageIntervals.Min,
                packageSpawnData.SpawnBlockInPackageIntervals.Max) / difficultyInfo.DecreaseBlocksInPackageIntervalsBy;
        }

        private bool ProbabilityMatches(float probability) => Random.value <= probability;
    }
}