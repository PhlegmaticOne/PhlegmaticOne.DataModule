using System;
using App.Scripts.Game.Features.Win.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Win.Configs {
    [Serializable]
    public class FinalScreenConfig {
        [SerializeField] private FinalScreenView _finalScreenView;

        public FinalScreenView FinalScreenView => _finalScreenView;
    }
}