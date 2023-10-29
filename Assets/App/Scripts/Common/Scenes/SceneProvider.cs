using System.Threading.Tasks;
using App.Scripts.Common.Scenes.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Scripts.Common.Scenes {
    public class SceneProvider : ISceneProvider {
        public async Task LoadSceneAsync(SceneType sceneType) {
            await SceneManager.LoadSceneAsync((int)sceneType);
        }
    }
}