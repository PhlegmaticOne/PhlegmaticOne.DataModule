using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Score.Views;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.Score.Systems {
    public class SystemChangeScore : NetworkSystemBase<ComponentChangeScore> {
        private readonly ISessionScoreService _sessionScoreService;
        private readonly ScoreViews _scoreViews;

        protected SystemChangeScore(
            INetworkService networkService,
            ISessionScoreService sessionScoreService,
            ScoreViews scoreViews) : base(networkService) {
            _sessionScoreService = sessionScoreService;
            _scoreViews = scoreViews;
        }

        public override void OnAwake() {
            _scoreViews.Local.Initialize(_sessionScoreService.MaxScore);
            _scoreViews.Remote.Initialize(_sessionScoreService.MaxScore);
            base.OnAwake();
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder.With<ComponentChangeScore>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentChangeScore = entity.GetComponent<ComponentChangeScore>();
            var delta = componentChangeScore.ChangeDelta;
            var newScore = _sessionScoreService.AddScore(delta);
            
            _scoreViews.Local.SetScoreAnimated(newScore);
            
            AddRemoteComponent(new ComponentChangeScore {
                ChangeDelta = delta,
                CurrentScore = newScore
            });
            entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentChangeScore componentRemote, float deltaTime) {
            var componentChangeScore = entity.GetComponent<ComponentChangeScore>();
            _scoreViews.Remote.SetScoreAnimated(componentChangeScore.CurrentScore);
        }
    }
}