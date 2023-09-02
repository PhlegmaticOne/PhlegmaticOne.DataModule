using PhlegmaticOne.DataStorage.Configuration.Storage;
using PhlegmaticOne.DataStorage.Migrations.Base;
using PhlegmaticOne.DataStorage.Migrations.Version;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PhlegmaticOne.DataStorage.Configuration {
    [CreateAssetMenu(menuName = "Data Storage/Data Storage Migration Configuration", fileName = "DataStorageMigrationConfiguration")]
    public class DataStorageMigrationConfiguration : ScriptableObject, IDataStorageMigrationData {
        [Header("Configuration")]
        [SerializeField] private DataStorageConfiguration _previousStorage;
        [SerializeField] private DataStorageConfiguration _currentStorage;
        [SerializeField] private int _migrationVersion;

        public DataStorageConfiguration PreviousStorage => _previousStorage;
        public DataStorageConfiguration CurrentStorage => _currentStorage;
        public int MigrationVersion => _migrationVersion;


        [Button]
        private void CloneCurrentStorageToPrevious() => _previousStorage.CopyFrom(_currentStorage);
        
        [Button]
        private void IncreaseMigrationVersion() => ++_migrationVersion;

        [Button]
        private void ResetVersionPlayerPrefs() => new MigrationVersionProviderPlayerPrefs().ResetVersion();
    }
}