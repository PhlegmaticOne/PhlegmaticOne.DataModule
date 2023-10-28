using App.Scripts.Game.Features.Combo.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Combo.Configs {
    [CreateAssetMenu(fileName = "ComboConfig", menuName = "Game/Combo/Config")]
    public class ComboConfig : ScriptableObject {
        [SerializeField] private float _comboMaxTime;
        [SerializeField] private float _showTextTime;
        [SerializeField] private ComboView _prefab;

        public float ComboMaxTime => _comboMaxTime;
        public float ShowTextTime => _showTextTime;
        public ComboView Prefab => _prefab;
    }
}