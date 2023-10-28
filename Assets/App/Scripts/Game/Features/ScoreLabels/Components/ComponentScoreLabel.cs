using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.ScoreLabels.Components {
    public class ComponentScoreLabel : ComponentRemoteBase {
        public Vector3Tiny PositionWorld;
        public Vector3Tiny Direction;
        public Vector3Tiny Color;
        public int Score;
    }
}