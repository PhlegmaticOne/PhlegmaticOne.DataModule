using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.Features.Health.Views
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private HealthView _prefab;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        
        private int _maxHeartsCount;

        private readonly Stack<HealthView> _hearts = new();
        
        public void Initialize(int startHeartsCount)
        {
            _maxHeartsCount = startHeartsCount;
            CreateHearts();
        }

        private void CreateHearts()
        {
            for (var i = 0; i < _maxHeartsCount; i++)
            {
                CreateHeart();
            }
        }

        public void RemoveHeart()
        {
            if (_hearts.Count == 0)
            {
                return;
            }
            
            _hearts.Pop().Hide();
            Rebuild();
        }
        
        private HealthView CreateHeart()
        {
            var heart = Instantiate(_prefab, _gridLayoutGroup.transform);
            Rebuild();
            _hearts.Push(heart);
            heart.Show();
            return heart;
        }
        
        private void Rebuild() => LayoutRebuilder.ForceRebuildLayoutImmediate(_gridLayoutGroup.transform as RectTransform);
    }
}