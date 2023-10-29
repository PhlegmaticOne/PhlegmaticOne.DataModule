using App.Scripts.Game.Features.FruitBasket.Services;
using Zenject;

namespace App.Scripts.Game.Features.FruitBasket.Installer {
    public class FruitBasketInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IFruitBasketGenerator>().To<FruitBasketGenerator>().AsSingle();
        }
    }
}