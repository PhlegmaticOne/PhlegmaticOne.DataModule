using App.Scripts.Game.Features.Network.Components;

namespace App.Scripts.Game.Features.Freezing.Components {
    public class ComponentFreezeActive : ComponentRemoteBase {
        public float Time;
        public float CurrentTime;
        public float Force;
        public bool IsApplied;
    }
}