using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Views.Components.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Views {
    public class BlockView : SerializedMonoBehaviour {
        [SerializeField] private List<IBlockViewComponent> _blockViewComponents;
        
        public void SetupBlockView(IBlockConfig blockConfig) {
            foreach (var blockViewComponent in _blockViewComponents) {
                blockViewComponent.Setup(blockConfig);
            }
        }

        [Button]
        private void UpdateViewComponents() {
            _blockViewComponents = GetComponentsInChildren<IBlockViewComponent>().ToList();
        }
    }
}