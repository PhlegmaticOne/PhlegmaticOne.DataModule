using App.Scripts.Game.Features.Animations.Factories;
using App.Scripts.Game.Features.Animations.Systems.Scale.Policies;
using Zenject;

namespace App.Scripts.Game.Features.Animations.Installer {
    public class BlockAnimationsInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindScaleResolvers();
            BindAnimationsFactory();
        }

        private void BindAnimationsFactory() {
            Container.Bind<IBlockAnimationFactory>().To<BlockAnimationFactory>().AsSingle();
        }

        private void BindScaleResolvers() {
            Container.Bind<IResolveScalePolicy>().To<ResolveScalePolicyBasedOnX>().AsSingle();
            Container.Bind<IResolveScalePolicy>().To<ResolveScalePolicyBasedOnY>().AsSingle();
            Container.Bind<IResolveScalePolicy>().To<ResolveScalePolicyBasedOnYSpeed>().AsSingle();
        }
    }
}