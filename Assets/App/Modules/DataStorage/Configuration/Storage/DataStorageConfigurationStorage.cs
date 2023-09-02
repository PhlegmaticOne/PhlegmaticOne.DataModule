using System;
using PhlegmaticOne.DataStorage.Configuration.DataSources.FileSource;
using PhlegmaticOne.DataStorage.Configuration.DataSources.FirebaseSource;
using PhlegmaticOne.DataStorage.Configuration.DataSources.InMemorySource;
using PhlegmaticOne.DataStorage.Configuration.DataSources.PlayerPrefsSource;
using PhlegmaticOne.DataStorage.DataSources.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PhlegmaticOne.DataStorage.Configuration.Storage {
    [Serializable]
    public class DataStorageConfigurationStorage {
        [Header("Data storage")]
        [SerializeField] private DataStorageType _storageType;

        [ShowIf(nameof(_storageType), DataStorageType.InMemory)] 
        [SerializeField] private DataStorageInMemoryConfiguration _inMemoryConfiguration;
        
        [ShowIf(nameof(_storageType), DataStorageType.File)]
        [SerializeField] private DataStorageFileConfiguration _fileConfiguration;

        [ShowIf(nameof(_storageType), DataStorageType.PlayerPrefs)] 
        [SerializeField] private DataStoragePlayerPrefsConfiguration _playerPrefsConfiguration;

        [ShowIf(nameof(_storageType), DataStorageType.FirebaseDatabase)]
        [SerializeField] private DataStorageFirebaseConfiguration _firebaseConfiguration;

        public IDataSourceFactory CreateSourceFactory() {
            return _storageType switch {
                DataStorageType.InMemory => _inMemoryConfiguration.CreateSourceFactory(),
                DataStorageType.PlayerPrefs => _playerPrefsConfiguration.CreateSourceFactory(),
                DataStorageType.File => _fileConfiguration.CreateSourceFactory(),
                DataStorageType.FirebaseDatabase => _firebaseConfiguration.CreateSourceFactory(),
                _ => throw new ArgumentException($"Unknown data storage type: {_storageType}", nameof(_storageType))
            };
        }

        public DataStorageConfigurationStorage Clone() {
            return new DataStorageConfigurationStorage {
                _storageType = _storageType,
                _inMemoryConfiguration = new DataStorageInMemoryConfiguration(),
                _fileConfiguration = new DataStorageFileConfiguration(_fileConfiguration),
                _firebaseConfiguration = new DataStorageFirebaseConfiguration(_firebaseConfiguration),
                _playerPrefsConfiguration = new DataStoragePlayerPrefsConfiguration(_playerPrefsConfiguration)
            };
        }
    }
}