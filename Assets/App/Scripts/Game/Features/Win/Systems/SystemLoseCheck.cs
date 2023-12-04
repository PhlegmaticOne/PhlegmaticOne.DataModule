using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Infrastructure.Session;
using App.Scripts.Game.Modes.Base;
using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.Features.Win.Systems
{
    public class SystemLoseCheck : SystemBase
    {
        private readonly INetworkSession _networkSession;

        public SystemLoseCheck(INetworkSession networkSession)
        {
            _networkSession = networkSession;
            _networkSession.EndGameMessageReceived += NetworkSessionOnEndGameMessageReceived;
        }

        private void NetworkSessionOnEndGameMessageReceived(PlayerEndGameMessage endGameMessage)
        {
            if (endGameMessage.IsBreakGame == false)
            {
                return;
            }


            World.AppendEntity().WithComponent(new ComponentInstantLose());
        }

        public override void OnDispose()
        {
            _networkSession.EndGameMessageReceived -= NetworkSessionOnEndGameMessageReceived;
        }
    }
}