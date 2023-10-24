using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Configs {
    [CreateAssetMenu(fileName = "CuttingConfig", menuName = "Game/Cutting/Config")]
    public class CuttingConfig : ScriptableObject {
        [SerializeField] private float _minCutSpeed;

        public float MinCutSpeed => _minCutSpeed;
    }
}