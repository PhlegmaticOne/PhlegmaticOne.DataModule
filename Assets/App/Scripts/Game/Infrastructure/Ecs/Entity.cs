using System;
using System.Collections.Generic;

namespace App.Scripts.Game.Infrastructure.Ecs {
    public class Entity {
        private readonly Dictionary<Type, IComponent> _components;
        public int Id { get; }
        
        public Entity(int id) {
            Id = id;
            _components = new Dictionary<Type, IComponent>();
        }

        public void AddComponent<T>(T component) where T : struct, IComponent {
            _components.TryAdd(typeof(T), component);
        }

        public bool HasComponent<T>() where T : struct, IComponent {
            return _components.ContainsKey(typeof(T));
        }

        public T GetComponent<T>() where T : struct, IComponent {
            return (T)_components[typeof(T)];
        }

        public bool TryGetComponent<T>(out T component) where T : struct, IComponent {
            if (_components.TryGetValue(typeof(T), out var c)) {
                component = (T)c;
                return true;
            }

            component = default;
            return false;
        }

        public void RemoveComponent<T>() where T : struct, IComponent {
            _components.Remove(typeof(T));
        }
    }
}