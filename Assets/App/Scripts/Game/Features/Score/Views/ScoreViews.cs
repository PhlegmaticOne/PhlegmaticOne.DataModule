namespace App.Scripts.Game.Features.Score.Views {
    public class ScoreViews {
        public IScoreView Local { get; }
        public IScoreView Remote { get; }

        public ScoreViews(IScoreView local, IScoreView remote) {
            Local = local;
            Remote = remote;
        }
    }
}