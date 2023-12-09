using System.Collections.Generic;
using App.Scripts.Game.Features._Common.Services;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Menu.Features.Statistics.Services;
using Assets.App.Scripts.Game.Features.Blocks.Models;

namespace App.Scripts.Game.Features.Score.Services
{
    public class SessionService : ISessionService {
        private readonly IUserStatisticsService _userStatisticsService;
        private int _sessionScore;
        private readonly Dictionary<BlockType, int> _slices;

        public SessionService(IUserStatisticsService userStatisticsService)
        {
            _userStatisticsService = userStatisticsService;
            _slices = new Dictionary<BlockType, int>();
        }

        public int CurrentScore => _sessionScore;

        public int AddScore(int score) {
            _sessionScore += score;
            return _sessionScore;
        }

        public void AddSlice(BlockType blockType)
        {
            if (_slices.ContainsKey(blockType))
            {
                _slices[blockType]++;
            }
            else
            {
                _slices.Add(blockType, 1);
            }
            
            _userStatisticsService.AddSlice(BlockTypesMapper.MapFromBlockType(blockType));
        }

        public int GetSlicesCount(BlockType blockType)
        {
            return _slices.TryGetValue(blockType, out var slices) ? slices : 0;
        }
    }
}