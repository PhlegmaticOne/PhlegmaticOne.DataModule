using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Infrastructure.Ecs {
    public class WorldInstaller : MonoInstaller {
        [SerializeField] private WorldRunner _worldRunner;
        
        public override void InstallBindings() {
            Container.Bind<World>().AsSingle();
            Container.Bind<WorldRunner>().FromInstance(_worldRunner).AsSingle();
        }
    }
}