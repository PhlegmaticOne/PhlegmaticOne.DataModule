using App.Scripts.Game.Features.Combo.Services;
using Zenject;

namespace App.Scripts.Game.Features.Combo.Installer {
    public class ComboInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IComboCounter>().To<ComboCounter>().AsSingle();
        }
    }
}