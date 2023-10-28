using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Combo.Components {
    public class ComponentComboCounter : IComponent {
        public float CurrentTime;
        public float MaxComboTime;
        public int ComboCount;
        public bool IsComboActive;
    }
}