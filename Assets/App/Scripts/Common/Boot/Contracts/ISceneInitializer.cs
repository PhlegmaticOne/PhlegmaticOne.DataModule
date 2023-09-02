using System.Threading.Tasks;

namespace App.Scripts.Common.Boot.Contracts {
    public interface ISceneInitializer {
        Task InitializeAsync();
    }
}