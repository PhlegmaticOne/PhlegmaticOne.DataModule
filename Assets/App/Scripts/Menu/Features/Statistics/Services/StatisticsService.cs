using App.Scripts.Menu.Features.Statistics.Models;
using App.Scripts.Menu.Features.Statistics.Services;
using PhlegmaticOne.DataStorage.Storage;
using PhlegmaticOne.DataStorage.Storage.Base;
using System.Threading.Tasks;

namespace Assets.App.Scripts.Menu.Features.Statistics.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IDataStorage _dataStorage;

        private IValueSource<StatisticsModel> _statisticsSource;

        public StatisticsService(IDataStorage dataStorage)
        {
            _dataStorage=dataStorage;
        }

        public void AddSlice(StatisticsBlockType blockType)
        {
            _statisticsSource.AsTrackable().AddSlice(blockType);
        }

        public async Task InitializeAsync()
        {
            _statisticsSource = await _dataStorage.ReadAsync<StatisticsModel>();

            if (_statisticsSource.NoValue())
            {
                _statisticsSource.SetRaw(StatisticsModel.Initial);
            }
        }

        public StatisticsModel LoadStatistics()
        {
            return _statisticsSource.AsNoTrackable();
        }
    }
}
