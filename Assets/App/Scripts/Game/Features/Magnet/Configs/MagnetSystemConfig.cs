using System;
using App.Scripts.Game.Features.Magnet.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Magnet.Configs {
    [Serializable]
    public class MagnetSystemConfig {
        [SerializeField] private MagnetWaves _remote;
        [SerializeField] private MagnetWaves _local;

        public MagnetWaves Remote => _remote;
        public MagnetWaves Local => _local;
    }
}