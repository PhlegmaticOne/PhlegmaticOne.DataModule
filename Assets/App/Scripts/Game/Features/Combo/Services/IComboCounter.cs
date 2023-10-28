namespace App.Scripts.Game.Features.Combo.Services {
    public interface IComboCounter {
        int ComboCount { get; }
        void OnUpdate(float deltaTime);
        int RecalculateScore(int score);
    }
}