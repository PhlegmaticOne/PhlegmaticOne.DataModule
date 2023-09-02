using System;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Statistics.Models;
using PhlegmaticOne.DataStorage.Contracts;

namespace App.Scripts.Menu.Features.Statistics.Services {
    public class StatisticsService : ServiceBase<StatisticsModel>, IStatisticsService {
        public event Action<StatisticsBlockInfo> Changed;

        public async Task<StatisticsModel> LoadStatistics() {
            await EnsureStatisticsLoaded();
            return Model;
        }

        public void AddSlice(StatisticsBlockType blockType) {
            var blockInfo = Model.AddSlice(blockType);
            OnStatisticChanged(blockInfo);
        }

        public Task SaveAsync() => DataStorage.SaveAsync(Model);

        private async Task EnsureStatisticsLoaded() {
            if (Model is not null){
                return;
            }
            
            Model = await DataStorage.ReadAsync<StatisticsModel>() ?? StatisticsModel.Initial;
        }

        private void OnStatisticChanged(StatisticsBlockInfo blockInfo) => Changed?.Invoke(blockInfo);
    }
}