using System.Threading;
using System.Threading.Tasks;
using App.Scripts.Common.Localization.Base;
using App.Scripts.Menu.Features.Statistics.Services;
using App.Scripts.Shared.Progress.Services;
using App.Scripts.Splash.Services.Firebase;
using PhlegmaticOne.Auth;
using PhlegmaticOne.Auth.Assets.App.Modules.Auth;

namespace App.Scripts.Splash.Services.Initializer {
    public class AppInitializer : IAppInitializer {
        private readonly IFirebaseInitializer _firebaseInitializer;
        private readonly IAuthProvider _authProvider;
        private readonly IPlayerService _playerScoreService;
        private readonly IUserStatisticsService _userStatisticsService;
        private readonly IAuthSource _authSource;
        private readonly ILocalizationProvider _localizationProvider;

        public AppInitializer(
            IFirebaseInitializer firebaseInitializer, 
            ILocalizationProvider localizationProvider,
            IAuthProvider authProvider,
            IPlayerService playerScoreService,
            IUserStatisticsService userStatisticsService,
            IAuthSource authSource)
        {
            _firebaseInitializer = firebaseInitializer;
            _authProvider = authProvider;
            _playerScoreService = playerScoreService;
            _userStatisticsService=userStatisticsService;
            _authSource=authSource;
            _localizationProvider = localizationProvider;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken) {
            await _localizationProvider.InitializeAsync();
            await _firebaseInitializer.InitializeAsync();
            await _authProvider.SignInAsync(_authSource);
            await _playerScoreService.InitializeAsync();
            await _userStatisticsService.InitializeAsync();
        }
    }
}