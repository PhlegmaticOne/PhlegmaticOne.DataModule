namespace App.Scripts.Game.Features.Health.Services
{
    public interface IHealthService
    {
        void Initialize(int health);
        int CurrentHealth { get; }
        void LoseHealth();
    }
}