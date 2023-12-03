using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;
using App.Scripts.Menu.Features.Statistics.Services;
using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Features.Statistics.ViewModels
{
    public class StatisticsViewModel : BaseViewModel {
        private readonly IStatisticsService _statisticsService;

        public StatisticsViewModel(IStatisticsService statisticsService) {
            _statisticsService = statisticsService;
            Statistics = new ReactiveCollection<StatisticsBlockInfo>();
        }
        
        public ReactiveCollection<StatisticsBlockInfo> Statistics { get; }

        public override Task InitializeAsync() {
            var statistics = _statisticsService.LoadStatistics();
            Statistics.Initialize(statistics.Statistics);
            return Task.CompletedTask;
        }
    }
}