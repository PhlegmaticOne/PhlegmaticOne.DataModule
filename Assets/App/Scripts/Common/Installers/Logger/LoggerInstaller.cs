using PhlegmaticOne.Logger;
using PhlegmaticOne.Logger.MessageFormater;
using Zenject;

namespace App.Scripts.Common.Installers.Logger {
    public class LoggerInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindLogger();
        }

        private void BindLogger() {
            Container.BindInterfacesTo<UnityDebugLogger>().AsSingle();
            #if UNITY_EDITOR
                Container.BindInterfacesTo<LogMessageEditorFormatter>().AsSingle();
            #else
                Container.BindInterfacesTo<LogMessageDeviceFormatter>().AsSingle();
            #endif
        }
    }
}