using System;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Common.Animations {
    [Serializable]
    public class TweenAnimationInfo {
        [SerializeField] private float _time;
        [SerializeField] private Ease _ease;

        public static TweenAnimationInfo Default(float time) => new TweenAnimationInfo(time, Ease.Linear);
        public TweenAnimationInfo(float time, Ease ease) {
            _time = time;
            _ease = ease;
        }
        
        public float Time => _time;
        public Ease Ease => _ease;
    }
}