using System;
using System.Collections.Generic;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;

namespace App.Scripts.Game.Infrastructure.Ecs.Filters {
    public class ComponentsFilter : IComponentsFilter, IComponentsFilterBuilder {
        private readonly List<Type> _with;
        private readonly List<Type> _without;
        
        private ComponentsFilter() {
            _with = new List<Type>();
            _without = new List<Type>();
        }

        public static IComponentsFilterBuilder Builder => new ComponentsFilter();

        public IEnumerable<Entity> Apply(World world) {
            foreach (var entity in world.GetEntities()) {
                if (FitEntity(entity)) {
                    yield return entity;
                }
            }
        }

        public bool FitEntity(Entity entity) {
            var isMatch = true;

            for (var i = 0; i < _with.Count; i++) {
                var with = _with[i];
                if (entity.HasComponentOfType(with) == false) {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch == false) {
                return false;
            }

            for (var i = 0; i < _without.Count; i++) {
                var without = _without[i];
                if (entity.HasComponentOfType(without)) {
                    isMatch = false;
                    break;
                }
            }

            return isMatch;
        }

        public IComponentsFilterBuilder With<T>() {
            _with.Add(typeof(T));
            return this;
        }

        public IComponentsFilterBuilder Without<T>() {
            _without.Add(typeof(T));
            return this;
        }

        public IComponentsFilter Build() {
            return this;
        }
    }
}