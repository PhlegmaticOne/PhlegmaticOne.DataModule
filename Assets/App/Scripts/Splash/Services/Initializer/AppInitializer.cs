using System.Threading;
using System.Threading.Tasks;
using App.Scripts.Common.Localization.Base;
using App.Scripts.Splash.Services.Firebase;
using PhlegmaticOne.Auth;
using PhlegmaticOne.DataStorage.Migrations.Base;
using PhlegmaticOne.DataStorage.Storage.Base;

namespace App.Scripts.Splash.Services.Initializer {
    public class AppInitializer : IAppInitializer {
        private readonly IFirebaseInitializer _firebaseInitializer;
        private readonly IAuthProvider _authProvider;
        private readonly IDataStorageMigration _migration;
        private readonly IDataStorage _dataStorage;
        private readonly ILocalizationProvider _localizationProvider;

        public AppInitializer(
            IFirebaseInitializer firebaseInitializer, 
            ILocalizationProvider localizationProvider,
            IAuthProvider authProvider,
            IDataStorageMigration migration,
            IDataStorage dataStorage) {
            _firebaseInitializer = firebaseInitializer;
            _authProvider = authProvider;
            _migration = migration;
            _dataStorage = dataStorage;
            _localizationProvider = localizationProvider;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken) {
            await _localizationProvider.InitializeAsync();
            await _firebaseInitializer.InitializeAsync();
            await _authProvider.SignInAsync();
            await _migration.MigrateAsync(cancellationToken);
            await _dataStorage.InitializeAsync(cancellationToken);
        }
    }
}