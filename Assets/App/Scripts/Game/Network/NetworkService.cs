using System;
using System.Text;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using Newtonsoft.Json;

namespace App.Scripts.Game.Network {
    public class NetworkService {
        public Entity NetworkEntity { get; private set; }

        public void Setup(Entity networkEntity) {
            NetworkEntity = networkEntity.WithComponent(new ComponentNetwork());
        }

        public ArraySegment<byte> CreateMessage() {
            var component = NetworkEntity.RemoveComponent<ComponentNetwork>();
            var message = CreateMessageFromEntity();
            NetworkEntity.CleanUp();
            NetworkEntity.AddComponent(component);
            return message;
        }

        public Entity FromMessage(in ArraySegment<byte> message) {
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