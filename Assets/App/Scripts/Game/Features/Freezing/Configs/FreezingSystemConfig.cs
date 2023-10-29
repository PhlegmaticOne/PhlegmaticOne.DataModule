using System;
using App.Scripts.Game.Features.Freezing.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Freezing.Configs {
    [Serializable]
    public class FreezingSystemConfig {
        [SerializeField] private FreezingScreen _remote;
        [SerializeField] private FreezingScreen _local;

        public FreezingScreen Remote => _remote;
        public FreezingScreen Local => _local;
    }
}