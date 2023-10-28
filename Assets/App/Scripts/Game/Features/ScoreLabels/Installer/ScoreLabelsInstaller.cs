using App.Scripts.Game.Features.ScoreLabels.Configs;
using App.Scripts.Game.Features.ScoreLabels.Factory;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.ScoreLabels.Installer {
    public class ScoreLabelsInstaller : MonoInstaller {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private ScoreLabelConfig _config;

        public override void InstallBindings() {
            Container.Bind<ScoreLabelFactoryConfig>()
                .FromInstance(new ScoreLabelFactoryConfig(_config, _spawnTransform))
                .AsSingle();
            Container.Bind<IScoreLabelFactory>().To<ScoreLabelFactory>().AsSingle();
        }
    }
}