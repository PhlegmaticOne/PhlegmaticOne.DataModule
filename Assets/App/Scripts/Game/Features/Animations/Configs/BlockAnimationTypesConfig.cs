using System.Collections.Generic;
using App.Scripts.Game.Features.Animations.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Configs {
    [CreateAssetMenu(fileName = "BlockAnimationTypesConfig", menuName = "Game/Animations/Animation Types Config")]
    public class BlockAnimationTypesConfig : SerializedScriptableObject {
        [SerializeField] private float _noneAnimationProbability;
        [SerializeField] private Dictionary<BlockAnimationType, float> _animationProbabilities;

        public float NoneAnimationProbability => _noneAnimationProbability;
        public IReadOnlyDictionary<BlockAnimationType, float> AnimationProbabilities => _animationProbabilities;
    }
}