using System;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;

namespace App.Scripts.Menu.Features.Statistics.Services {
    public interface IStatisticsService {
        event Action<StatisticsBlockInfo> Changed; 
        void AddSlice(StatisticsBlockType blockType);
        Task<StatisticsModel> LoadStatistics();
    }
}