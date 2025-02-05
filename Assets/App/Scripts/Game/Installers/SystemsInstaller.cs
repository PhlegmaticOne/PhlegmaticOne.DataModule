﻿using App.Scripts.Game.Features.Animations.Systems.Rotation;
using App.Scripts.Game.Features.Animations.Systems.Scale;
using App.Scripts.Game.Features.BlocksSplit.Systems;
using App.Scripts.Game.Features.BoardState.Systems;
using App.Scripts.Game.Features.Bomb.Systems;
using App.Scripts.Game.Features.Combo.Systems;
using App.Scripts.Game.Features.Cutting.Systems;
using App.Scripts.Game.Features.Freezing.Systems;
using App.Scripts.Game.Features.FruitBasket.Systems;
using App.Scripts.Game.Features.Health.Systems;
using App.Scripts.Game.Features.Magnet.Systems;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Packages.Systems;
using App.Scripts.Game.Features.Particles.Systems;
using App.Scripts.Game.Features.Physics.Systems;
using App.Scripts.Game.Features.RemoveBlocks.Systems;
using App.Scripts.Game.Features.Score.Systems;
using App.Scripts.Game.Features.ScoreLabels.Systems;
using App.Scripts.Game.Features.Sound.Systems;
using App.Scripts.Game.Features.Spawning.Systems;
using App.Scripts.Game.Features.Win.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using Zenject;

namespace App.Scripts.Game.Installers {
    public class SystemsInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindSystems();
        }

        private void BindSystems() {
            Container.Bind<ISystem>().To<SystemGravity>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemDoAnimationScale>().AsSingle();
            Container.Bind<ISystem>().To<SystemDoAnimationRotation>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemPackageGeneration>().AsSingle();
            Container.Bind<ISystem>().To<SystemPackageProcessor>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemSpawnByBlockData>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawning>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemTemporaryUncuttableUpdate>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingInput>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingView>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingAction>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingCutBlocks>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemCheckSpawnParticles>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawnParticles>().AsSingle();

            Container.Bind<ISystem>().To<SystemThrowBlocksCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemThrowBlocks>().AsSingle();

            Container.Bind<ISystem>().To<SystemSpawnFruitBasketCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawnFruitBasket>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemFreezeCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemFreezeRemoteCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemFreeze>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemMagnetCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemMagnetRemoteCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemMagnet>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemChangeScoreCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemComboCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemComboShowTextCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemShowComboText>().AsSingle();
            Container.Bind<ISystem>().To<SystemChangeScore>().AsSingle();

            Container.Bind<ISystem>().To<SystemScoreLabelCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemScoreLabelShow>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemCuttingCheckSplitBlocks>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingSplitBlock>().AsSingle();

            Container.Bind<ISystem>().To<SystemHealthCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemHealthAction>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemBoardStateCheck>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemWinCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemLoseCheck>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemPlaySoundCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemPlaySound>().AsSingle();

            Container.Bind<ISystem>().To<SystemRemoveBlocks>().AsSingle();

            Container.Bind<ISystem>().To<SystemWin>().AsSingle();
            Container.Bind<ISystem>().To<SystemLose>().AsSingle();
            
            Container.Bind<ISystem>().To<SystemNetwork>().AsSingle();
        }
    }
}