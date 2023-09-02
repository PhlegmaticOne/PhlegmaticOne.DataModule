using App.Scripts.Common.AppEvents.Implementations;
using Zenject;

namespace App.Scripts.Common.AppEvents.Installer {
    public class AppEventsHandlerInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallGlobalEventsHandler();
        }

        private void InstallGlobalEventsHandler() {
            #if !UNITY_EDITOR
                Container.BindInterfacesTo<AppEventsDeviceHandler>()
                     .FromNewComponentOnNewGameObject()
                     .UnderTransform(transform).AsSingle().NonLazy();
            #else
                Container.BindInterfacesTo<AppEventsEditorHandler>()
                    .FromNewComponentOnNewGameObject()
                    .UnderTransform(transform).AsSingle().NonLazy();
            #endif
        }
    }
}