using App.Scripts.Game.Features.Blocks.Models;

namespace App.Scripts.Game.Features._Common.Services {
    public interface ISessionService {
        int CurrentScore { get; }
        int AddScore(int score);
        void AddSlice(BlockType blockType);
        int GetSlicesCount(BlockType blockType);
    }
}