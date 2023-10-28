using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.ScoreLabels.Components;
using App.Scripts.Game.Features.ScoreLabels.Factory;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.ScoreLabels.Systems {
    public class SystemScoreLabelShow : NetworkSystemBase<ComponentScoreLabel> {
        private readonly IScoreLabelFactory _scoreLabelFactory;

        protected SystemScoreLabelShow(IScoreLabelFactory scoreLabelFactory, INetworkService networkService) : 
            base(networkService) {
            _scoreLabelFactory = scoreLabelFactory;
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder.With<ComponentScoreLabel>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var component = entity.GetComponent<ComponentScoreLabel>();
            _scoreLabelFactory.CreateLabel(component);
            AddRemoteComponent(ToRemote(component));
            entity.RemoveEndOfFrame();
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentScoreLabel componentRemote, float deltaTime) {
            var component = entity.GetComponent<ComponentScoreLabel>();
            _scoreLabelFactory.CreateLabel(component);
        }
        
        private static ComponentScoreLabel ToRemote(ComponentScoreLabel local) {
            var direction = local.Direction.InvertX();
            var position = local.PositionWorld.InvertX();
            return new ComponentScoreLabel {
                Score = local.Score,
                Direction = direction,
                PositionWorld = position
            };
        }
    }
}