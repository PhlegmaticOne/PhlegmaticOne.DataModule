using System.Threading.Tasks;
using App.Scripts.Common.AppEvents.Contracts;
using PhlegmaticOne.DataStorage.Storage.Base;

namespace App.Scripts.Common.Storage {
    public class DataStorageStateSaveAction : IAppEventHandler {
        private readonly IDataStorage _dataStorage;
        
        public DataStorageStateSaveAction(IDataStorage dataStorage) => _dataStorage = dataStorage;
        public AppEventType DefaultEventType => AppEventType.Pause;
        public Task HandleAsync() => _dataStorage.SaveStateAsync();
    }
}