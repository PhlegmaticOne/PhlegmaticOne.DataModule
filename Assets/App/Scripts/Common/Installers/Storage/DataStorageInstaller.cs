using PhlegmaticOne.DataStorage.Provider;
using PhlegmaticOne.DataStorage.Storage;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Installers.Storage {
    public class DataStorageInstaller : MonoInstaller {
        [SerializeField] private DataStorageMonoProvider _dataStorageProvider;

        public override void InstallBindings() {
            _dataStorageProvider.Initialize();
            _dataStorageProvider.StartChangeTracker();
            BindDataStorage();
        }

        private void BindDataStorage() {
            Container.BindInterfacesAndSelfTo<DataStorage>()
                .FromInstance(_dataStorageProvider.DataStorage)
                .AsSingle();
        }
    }
}