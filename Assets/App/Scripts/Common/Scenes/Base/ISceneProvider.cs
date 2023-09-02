using System.Threading.Tasks;

namespace App.Scripts.Common.Scenes.Base {
    public interface ISceneProvider {
        Task LoadSceneAsync(SceneType sceneType);
    }
}