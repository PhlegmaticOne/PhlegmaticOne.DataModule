using PhlegmaticOne.DataStorage.Configuration.Storage;
using PhlegmaticOne.DataStorageMigrations.Base;
using PhlegmaticOne.DataStorageMigrations.Version;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PhlegmaticOne.DataStorageMigrations {
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