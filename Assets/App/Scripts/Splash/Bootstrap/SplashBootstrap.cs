using System.Threading.Tasks;
using App.Scripts.Common.Boot.Contracts;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Splash.Features.Progress.Models;
using App.Scripts.Splash.Services.Initializer;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace App.Scripts.Splash.Bootstrap {
    public class SplashBootstrap : MonoBehaviour, ISceneInitializer {
        private IAppInitializer _appInitializer;
        private ISceneProvider _sceneProvider;
        private IProgressReporter _progressReporter;

        [Inject]
        private void Construct(IProgressReporter progressReporter, IAppInitializer appInitializer, ISceneProvider sceneProvider) {
            _progressReporter = progressReporter;
            _appInitializer = appInitializer;
            _sceneProvider = sceneProvider;
        }

        public async Task InitializeAsync() {
            Application.targetFrameRate = 60;
            await AppInitializedAndScreenLoaded();
            await _sceneProvider.LoadSceneAsync(SceneType.Menu);
        }

        private Task AppInitializedAndScreenLoaded() {
            var cancellationToken = this.GetCancellationTokenOnDestroy();
            var initializeAppTask = _appInitializer.InitializeAsync(cancellationToken);
            var loadingScreenTask = _progressReporter.ProgressAsync(cancellationToken);
            return Task.WhenAll(initializeAppTask, loadingScreenTask);
        }
    }
}