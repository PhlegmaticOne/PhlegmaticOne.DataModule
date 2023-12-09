using App.Scripts.Game.Features.Health.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Health.Configs
{
    public class HealthViewsConfig : MonoBehaviour
    {
        [SerializeField] private HealthBarView _enemyHealthView;
        [SerializeField] private HealthBarView _playerHealthView;

        public void Initialize(int health)
        {
            EnableViews();
            _enemyHealthView.Initialize(health);
            _playerHealthView.Initialize(health);
        }

        public void RemoveHeart(bool isRemote)
        {
            var healthBar = isRemote ? _enemyHealthView : _playerHealthView;
            healthBar.RemoveHeart();
        }
        
        private void EnableViews()
        {
            _enemyHealthView.gameObject.SetActive(true);
            _playerHealthView.gameObject.SetActive(true);
        }
    }
}