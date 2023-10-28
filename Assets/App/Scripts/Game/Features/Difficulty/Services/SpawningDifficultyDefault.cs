using App.Scripts.Game.Features.Spawning.Configs.Blocks;
using App.Scripts.Game.Features.Spawning.Configs.Blocks.Data;

namespace App.Scripts.Game.Features.Difficulty.Services {
    public class SpawningDifficultyDefault : ISpawningDifficulty {
        private readonly SpawnSystemConfiguration _config;

        public SpawningDifficultyDefault(SpawnSystemConfiguration config) {
            _config = config;
        }
        
        public DifficultyData CalculateDifficulty(int spawnIteration) {
            var config = _config.PackageSpawnData;
            var iteration = spawnIteration > config.MaxDifficulty ? config.MaxDifficulty : spawnIteration;
            return new DifficultyData {
                BlocksGravity = config.InitialBlockGravity,
                BlocksInPackageCount = CalculateBlocksInPackageCount(iteration, config),
                TimeToNextBlockPackage = CalculateTimeToNextPackage(iteration, config),
                DecreaseBlocksInPackageIntervalsBy = 1,
                TotalBonusesSpawnPercentage = 1,
                TotalDebufsSpawnPercentage = 1
            };
        }

        private static int CalculateBlocksInPackageCount(int spawnIteration, in PackageSpawnData spawnData) {
            var stagesCount = spawnData.BlocksInPackage.Max - spawnData.BlocksInPackage.Min;
            var stage = spawnIteration * stagesCount / spawnData.MaxDifficulty;
            return spawnData.BlocksInPackage.Min + stage;
        }

        private static float CalculateTimeToNextPackage(int spawnIteration, in PackageSpawnData spawnData) {
            var timeInterval = spawnData.SpawnPackageIntervals.Max - spawnData.SpawnPackageIntervals.Min;
            var stage = spawnIteration * timeInterval / spawnData.MaxDifficulty;
            return spawnData.SpawnPackageIntervals.Max - stage;
        }
    }
}