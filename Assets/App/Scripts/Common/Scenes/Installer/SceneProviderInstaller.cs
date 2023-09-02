using App.Scripts.Common.Boot;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Scenes.Installer {
    public class SceneProviderInstaller : MonoInstaller {
        [SerializeField] private SceneBootstrap _sceneBootstrap;
        
        public override void InstallBindings() {
            BindSceneBootstrap();
            BindSceneProvider();
        }
        
        private void BindSceneBootstrap() {
            Container.BindInterfacesAndSelfTo<SceneBootstrap>().FromInstance(_sceneBootstrap).AsSingle();
        }

        private void BindSceneProvider() {
            Container.BindInterfacesTo<SceneProvider>().AsSingle();
        }
    }
}