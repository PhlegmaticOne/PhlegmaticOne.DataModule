using System;
using System.Collections.Generic;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using Newtonsoft.Json;

namespace App.Scripts.Game.Infrastructure.Ecs.Entities {
    [Serializable]
    public class Entity {
        [JsonProperty]
        private readonly Dictionary<Type, IComponent> _components;
        
        public Entity() {
            _components = new Dictionary<Type, IComponent>();
        }

        [JsonConstructor]
        public Entity(Dictionary<Type, IComponent> components) {
            _components = components;
        }

        public bool HasAnyComponent() => _components.Count > 0;
        public int ComponentsCount => _components.Count;

        public Entity WithComponent<T>(T component) where T : IComponent {
            AddComponent(component);
            return this;
        }

        public void AddComponent<T>(T component) where T : IComponent {
            _components.TryAdd(typeof(T), component);
        }

        public bool HasComponent<T>() where T : IComponent {
            return _components.ContainsKey(typeof(T));
        }

        public T GetComponent<T>() where T : IComponent {
            return (T)_components[typeof(T)];
        }

        public bool TryGetComponent<T>(out T component) where T : IComponent {
            if (_components.TryGetValue(typeof(T), out var c)) {
                component = (T)c;
                return true;
            }

            component = default;
            return false;
        }

        public T RemoveComponent<T>() where T : IComponent {
            if (_components.TryGetValue(typeof(T), out var component)) {
                _components.Remove(typeof(T));
                return (T)component;
            }

            return default;
        }

        public void CleanUp() {
            _components.Clear();
        }
    }
}