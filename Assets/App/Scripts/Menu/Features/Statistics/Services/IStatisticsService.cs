using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;

namespace App.Scripts.Menu.Features.Statistics.Services
{
    public interface IStatisticsService {
        Task InitializeAsync();
        void AddSlice(StatisticsBlockType blockType);
        StatisticsModel LoadStatistics();
    }
}