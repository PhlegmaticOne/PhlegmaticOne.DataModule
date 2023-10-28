namespace App.Scripts.Game.Features.Difficulty.Services {
    public interface ISpawningDifficulty {
        DifficultyData CalculateDifficulty(int spawnIteration);
    }
}