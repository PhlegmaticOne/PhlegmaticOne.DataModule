namespace App.Scripts.Game.Features.Score.Views {
    public interface IScoreView {
        void Initialize(int maxScore);
        void SetScoreInstant(int delta);
        void SetScoreAnimated(int delta);
    }
}