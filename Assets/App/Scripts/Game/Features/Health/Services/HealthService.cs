namespace App.Scripts.Game.Features.Health.Services
{
    public class HealthService : IHealthService
    {
        public void Initialize(int health) => CurrentHealth = health;
        public int CurrentHealth { get; private set; }
        
        public void LoseHealth() => CurrentHealth--;
    }
}