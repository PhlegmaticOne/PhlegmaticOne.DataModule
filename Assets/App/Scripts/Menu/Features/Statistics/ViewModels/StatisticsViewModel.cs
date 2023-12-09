using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;
using App.Scripts.Menu.Features.Statistics.Services;
using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Features.Statistics.ViewModels
{
    public class StatisticsViewModel : BaseViewModel {
        private readonly IUserStatisticsService _userStatisticsService;
        private readonly IStatisticsService _statisticsService;

        public StatisticsViewModel(IUserStatisticsService userStatisticsService, IStatisticsService statisticsService) {
            _userStatisticsService = userStatisticsService;
            _statisticsService = statisticsService;
            Statistics = new ReactiveCollection<StatisticsBlockInfo>();
        }
        
        public ReactiveCollection<StatisticsBlockInfo> Statistics { get; }
        public string UserId { get; set; }

        public override async Task InitializeAsync()
        {
            var statistics = string.IsNullOrEmpty(UserId)
                ? await LoadCurrentUserStatistics()
                : await LoadUserStatistics();
            
            Statistics.Initialize(statistics);
        }

        private async Task<IReadOnlyList<StatisticsBlockInfo>> LoadCurrentUserStatistics()
        {
            await _userStatisticsService.InitializeAsync();
            return _userStatisticsService.LoadStatistics().Statistics;
        }
        
        private async Task<IReadOnlyList<StatisticsBlockInfo>> LoadUserStatistics()
        {
            var statisticsModel = await _statisticsService.LoadStatisticsAsync(UserId);
            return statisticsModel.Statistics;
        }
    }
}