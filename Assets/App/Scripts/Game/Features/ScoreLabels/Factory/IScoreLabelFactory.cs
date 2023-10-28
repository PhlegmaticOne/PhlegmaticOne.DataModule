using App.Scripts.Game.Features.ScoreLabels.Components;

namespace App.Scripts.Game.Features.ScoreLabels.Factory {
    public interface IScoreLabelFactory {
        void CreateLabel(ComponentScoreLabel componentScoreLabel);
    }
}