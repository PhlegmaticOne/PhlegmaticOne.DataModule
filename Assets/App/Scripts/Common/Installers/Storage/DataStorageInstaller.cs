using System.Linq;
using App.Scripts.Common.Storage;
using PhlegmaticOne.DataStorage.Contracts;
using PhlegmaticOne.DataStorage.Storage;
using PhlegmaticOne.DataStorage.Storage.Base;
using PhlegmaticOne.DataStorageMigrations;
using PhlegmaticOne.DataStorageMigrations.Base;
using PhlegmaticOne.DataStorageMigrations.Version;
using UnityEngine;
using Zenject;
using Assembly = System.Reflection.Assembly;

namespace App.Scripts.Common.Installers.Storage {
    public class DataStorageInstaller : MonoInstaller {
        [SerializeField] private DataStorageMigrationConfiguration _dataStorageMigrationConfiguration;
        
        public override void InstallBindings() {
            BindSaveAction();
            BindDataStorage();
            BindMigrations();
            BindSourcesContainer();
            BindGameServices();
        }

        private void BindDataStorage() {
            Container.Bind<IDataStorage>().To<DataStorage>().AsSingle();
        }

        private void BindMigrations() {
            Container.Bind<IDataStorageMigrationData>()
                .To<DataStorageMigrationConfiguration>()
                .FromInstance(_dataStorageMigrationConfiguration)
                .AsSingle();
            Container.Bind<IDataStorageMigration>().To<DataStorageMigration>().AsSingle();
            Container.Bind<IMigrationVersionProvider>().To<MigrationVersionProviderPlayerPrefs>().AsSingle();
        }

        private void BindSourcesContainer() {
            var configuration = _dataStorageMigrationConfiguration.CurrentStorage;
            var infrastructure = configuration.GetSourceContainer();
            Container.BindInstance(infrastructure).AsSingle();
        }
        
        private void BindSaveAction() {
            Container.BindInterfacesTo<DataStorageStateSaveAction>().AsSingle();
        }

        private void BindGameServices() {
            var serviceType = typeof(IService);
            var types = Assembly.GetAssembly(typeof(DataStorageInstaller)).GetTypes()
                .Where(x => serviceType.IsAssignableFrom(x) && x.IsAbstract == false);
            
            foreach (var type in types) {
                Container.BindInterfacesTo(type).AsSingle();
            }
        }
    }
}