using System;
using System.Text;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.World;
using Newtonsoft.Json;

namespace App.Scripts.Game.Features.Network.Services {
    public class NetworkService : INetworkService {
        public Entity NetworkEntity { get; }

        public NetworkService(World world) {
            NetworkEntity = world.CreateEntity().WithComponent(new ComponentNetwork());
        }

        public ArraySegment<byte> CreateMessage() {
            var component = NetworkEntity.RemoveComponent<ComponentNetwork>();
            var message = CreateMessageFromEntity();
            NetworkEntity.CleanUp();
            NetworkEntity.AddComponent(component);
            return message;
        }

        public Entity CreateEntityFromRemoteMessage(in ArraySegment<byte> message) {
            var str = Encoding.UTF8.GetString(message);
            return JsonConvert.DeserializeObject<Entity>(str, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        private ArraySegment<byte> CreateMessageFromEntity() {
            var json = JsonConvert.SerializeObject(NetworkEntity, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var bytes = Encoding.UTF8.GetBytes(json);
            return new ArraySegment<byte>(bytes);
        }
    }
}