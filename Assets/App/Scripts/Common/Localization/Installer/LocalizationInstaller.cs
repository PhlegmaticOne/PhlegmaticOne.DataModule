using Zenject;

namespace App.Scripts.Common.Localization.Installer {
    public class LocalizationInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindLocalization();
        }

        private void BindLocalization() {
            Container.BindInterfacesTo<UnityLocalizationProvider>().AsSingle();
        }
    }
}