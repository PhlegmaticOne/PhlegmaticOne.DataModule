using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Combo.Components {
    public class ComponentShowComboText : ComponentRemoteBase {
        public Vector3Tiny PositionWorld;
        public int ComboValue;
    }
}