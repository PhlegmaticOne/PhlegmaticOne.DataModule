using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;
using App.Scripts.Menu.Features.Statistics.Services;
using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using PhlegmaticOne.ViewModels.Commands;
using PhlegmaticOne.ViewModels.Contracts;

namespace App.Scripts.Menu.Features.Statistics.ViewModels {
    public class StatisticsViewModel : BaseViewModel {
        private readonly IStatisticsService _statisticsService;

        public StatisticsViewModel(IStatisticsService statisticsService) {
            _statisticsService = statisticsService;
            Statistics = new ReactiveCollection<StatisticsBlockInfo>();
            AddSliceCommand = RelayCommandFactory.CreateCommand<StatisticsBlockInfo>(AddSlice);
        }
        
        public ReactiveCollection<StatisticsBlockInfo> Statistics { get; }

        public IRelayCommand AddSliceCommand { get; }

        public override async Task InitializeAsync() {
            _statisticsService.Changed += UpdateItemInList;
            var statistics = await _statisticsService.LoadStatistics();
            Statistics.Initialize(statistics.Statistics);
        }

        protected override void OnDisposing() {
            _statisticsService.Changed -= UpdateItemInList;
        }

        private void UpdateItemInList(StatisticsBlockInfo blockInfo) {
            Statistics.OnItemChanged(blockInfo);
        }

        private void AddSlice(StatisticsBlockInfo blockInfo) {
            var blockType = blockInfo.BlockType;
            _statisticsService.AddSlice(blockType);
        }
    }
}