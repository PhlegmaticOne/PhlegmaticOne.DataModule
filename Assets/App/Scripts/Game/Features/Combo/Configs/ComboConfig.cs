using UnityEngine;

namespace App.Scripts.Game.Features.Combo.Configs {
    [CreateAssetMenu(fileName = "ComboConfig", menuName = "Game/Combo/Config")]
    public class ComboConfig : ScriptableObject {
        [SerializeField] private float _comboMaxTime;

        public float ComboMaxTime => _comboMaxTime;
    }
}