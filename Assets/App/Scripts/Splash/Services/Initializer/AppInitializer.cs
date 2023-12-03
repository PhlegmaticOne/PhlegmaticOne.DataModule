using System.Threading;
using System.Threading.Tasks;
using App.Scripts.Common.Localization.Base;
using App.Scripts.Menu.Features.Statistics.Services;
using App.Scripts.Shared.Progress.Services;
using App.Scripts.Splash.Services.Firebase;
using PhlegmaticOne.Auth;

namespace App.Scripts.Splash.Services.Initializer {
    public class AppInitializer : IAppInitializer {
        private readonly IFirebaseInitializer _firebaseInitializer;
        private readonly IAuthProvider _authProvider;
        private readonly IPlayerService _playerScoreService;
        private readonly IStatisticsService _statisticsService;
        private readonly ILocalizationProvider _localizationProvider;

        public AppInitializer(
            IFirebaseInitializer firebaseInitializer, 
            ILocalizationProvider localizationProvider,
            IAuthProvider authProvider,
            IPlayerService playerScoreService,
            IStatisticsService statisticsService) {
            _firebaseInitializer = firebaseInitializer;
            _authProvider = authProvider;
            _playerScoreService = playerScoreService;
            _statisticsService=statisticsService;
            _localizationProvider = localizationProvider;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken) {
            await _localizationProvider.InitializeAsync();
            await _firebaseInitializer.InitializeAsync();
            await _authProvider.SignInAsync();
            await _playerScoreService.InitializeAsync();
            await _statisticsService.InitializeAsync();
        }
    }
}