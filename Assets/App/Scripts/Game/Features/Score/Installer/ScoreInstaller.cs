using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Score.Views;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Score.Installer {
    public class ScoreInstaller : MonoInstaller {
        [SerializeField] private ScoreView _localScoreView;
        [SerializeField] private ScoreView _remoteScoreView;
        
        public override void InstallBindings() {
            Container.BindInterfacesTo<ScoreInstaller>().FromInstance(this).AsSingle();
            BindSessionScoreService();
            BindScoreViews();
        }

        private void BindSessionScoreService() {
            Container.Bind<ISessionScoreService>().To<SessionScoreService>().AsSingle();
        }

        private void BindScoreViews() {
            Container.Bind<ScoreViews>().FromInstance(new ScoreViews(_localScoreView, _remoteScoreView)).AsSingle();
        }
    }
}