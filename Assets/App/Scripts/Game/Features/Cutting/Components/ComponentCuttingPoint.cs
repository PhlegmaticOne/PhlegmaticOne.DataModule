using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Infrastructure.Input;
using App.Scripts.Game.Infrastructure.Serialization;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Components {
    public class ComponentCuttingPoint : ComponentRemote<ComponentCuttingPoint> {
        public InputData InputData;
        
        public override ComponentCuttingPoint ToRemote() {
            var p = InputData.Position;
            var position = new Vector3Tiny(p.x - Screen.width / 2f, p.y, p.z);
            
            return new ComponentCuttingPoint {
                IsRemote = true,
                InputData = new InputData(position, InputData.InputState, InputData.IsValid)
            };
        }
    }
}