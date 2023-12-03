using System.Threading.Tasks;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Shared.Sounds.Services;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Scripts.Common.Scenes {
    public class SceneProvider : ISceneProvider {
        private readonly ISoundPlayService _soundPlayService;

        public SceneProvider(ISoundPlayService soundPlayService)
        {
            _soundPlayService=soundPlayService;
        }

        public async Task LoadSceneAsync(SceneType sceneType) {
            await SceneManager.LoadSceneAsync((int)sceneType);
            _soundPlayService.UpdateSounds();
        }
    }
}