using PhlegmaticOne.DataStorage.Configuration.Storage;

namespace PhlegmaticOne.DataStorageMigrations.Base {
    public interface IDataStorageMigrationData {
        int MigrationVersion { get; }
        DataStorageConfiguration PreviousStorage { get; }
        DataStorageConfiguration CurrentStorage { get; }
    }
}