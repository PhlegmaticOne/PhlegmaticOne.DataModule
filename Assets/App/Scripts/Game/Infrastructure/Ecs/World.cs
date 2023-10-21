using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Game.Infrastructure.Ecs {
    public class World {
        private readonly List<Entity> _entities;
        private readonly List<ISystem> _systems;
        private int _id;
        
        public World(IEnumerable<ISystem> systems) {
            _entities = new List<Entity>();
            _systems = systems.ToList();
            _id = -1;
        }

        public void Construct() {
            foreach (var system in _systems) {
                system.World = this;
                system.OnAwake();
            }
        }

        public IList<Entity> GetEntities() {
            return _entities;
        }

        public IEnumerable<Entity> FilterHasComponent<T>() where T : struct, IComponent {
            return _entities.Where(x => x.HasComponent<T>());
        }

        public Entity CreateEntity() {
            _id++;
            var entity = new Entity(_id);
            _entities.Add(entity);
            return entity;
        }

        public void RemoveEntity(Entity entity) {
            _entities.Remove(entity);
        }

        public void Update(float deltaTime) {
            foreach (var system in _systems) {
                system.OnUpdate(deltaTime);
            }
        }
        
        public void FixedUpdate(float deltaTime) {
            foreach (var system in _systems) {
                system.OnFixedUpdate(deltaTime);
            }
        }
        
        public void Dispose() {
            foreach (var system in _systems) {
                system.OnDispose();
            }
        }
    }
}