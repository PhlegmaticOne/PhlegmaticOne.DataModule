using App.Scripts.Game.Features.Network.Components;

namespace App.Scripts.Game.Features.Score.Components {
    public class ComponentChangeScore : ComponentRemoteBase {
        public int CurrentScore;
        public int ChangeDelta;
    }
}