using System;
using App.Scripts.Game.Infrastructure.Ecs.Entities;

namespace App.Scripts.Game.Features.Network.Services {
    public interface INetworkService {
        Entity NetworkEntity { get; }
        ArraySegment<byte> CreateMessage();
        Entity CreateEntityFromRemoteMessage(in ArraySegment<byte> message);
    }
}