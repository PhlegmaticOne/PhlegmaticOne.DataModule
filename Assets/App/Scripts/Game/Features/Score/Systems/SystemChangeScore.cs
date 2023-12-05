using App.Scripts.Game.Features._Common.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Score.Views;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.Score.Systems {
    public class SystemChangeScore : NetworkSystemBase<ComponentChangeScore> {
        private readonly ISessionService _sessionService;
        private readonly ScoreViews _scoreViews;

        protected SystemChangeScore(
            INetworkService networkService,
            ISessionService sessionService,
            ScoreViews scoreViews) : base(networkService) {
            _sessionService = sessionService;
            _scoreViews = scoreViews;
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder.With<ComponentChangeScore>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentChangeScore = entity.GetComponent<ComponentChangeScore>();
            var delta = componentChangeScore.ChangeDelta;
            var newScore = _sessionService.AddScore(delta);
            
            _scoreViews.Local.SetScoreAnimated(newScore);
            
            AddRemoteComponent(new ComponentChangeScore {
                ChangeDelta = delta,
                CurrentScore = newScore
            });
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentChangeScore componentRemote, float deltaTime) {
            var componentChangeScore = entity.GetComponent<ComponentChangeScore>();
            _scoreViews.Remote.SetScoreAnimated(componentChangeScore.CurrentScore);
        }
    }
}