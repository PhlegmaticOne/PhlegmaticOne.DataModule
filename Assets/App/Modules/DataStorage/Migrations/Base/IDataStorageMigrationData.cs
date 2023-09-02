using PhlegmaticOne.DataStorage.Configuration.Storage;

namespace PhlegmaticOne.DataStorage.Migrations.Base {
    public interface IDataStorageMigrationData {
        int MigrationVersion { get; }
        DataStorageConfiguration PreviousStorage { get; }
        DataStorageConfiguration CurrentStorage { get; }
    }
}