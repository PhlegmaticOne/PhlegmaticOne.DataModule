using System.Threading.Tasks;
using App.Scripts.Common.Boot;
using App.Scripts.Common.Scenes.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Scripts.Common.Scenes {
    public class SceneProvider : ISceneProvider {
        private readonly SceneBootstrap _sceneBootstrap;

        public SceneProvider(SceneBootstrap sceneBootstrap) {
            _sceneBootstrap = sceneBootstrap;
        }

        public async Task LoadSceneAsync(SceneType sceneType) {
            _sceneBootstrap.DisposeScene();
            await SceneManager.LoadSceneAsync((int)sceneType);
        }
    }
}