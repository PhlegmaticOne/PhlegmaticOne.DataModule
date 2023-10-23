using System;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Serialization {
    [Serializable]
    public class MinMaxRange<T> {
        [SerializeField] private T _min;
        [SerializeField] private T _max;

        public T Min => _min;
        public T Max => _max;
    }
}