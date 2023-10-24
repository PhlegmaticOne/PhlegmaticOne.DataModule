using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Network.Systems {
    public class NetworkSystemBase<T> : SystemBase where T : ComponentRemoteBase {
        private readonly INetworkService _networkService;

        private IComponentsFilter _localFilter;
        private IComponentsFilter _remoteFilter;

        protected NetworkSystemBase(INetworkService networkService) {
            _networkService = networkService;
        }

        public override void OnAwake() {
            _localFilter = SetupLocalFilter(ComponentsFilter.Builder.Without<ComponentNetwork>()).Build();
            _remoteFilter = SetupRemoteFilter(ComponentsFilter.Builder.With<T>().Without<ComponentNetwork>()).Build();
        }

        public sealed override void OnUpdate(float deltaTime) {
            foreach (var entity in _remoteFilter.Apply(World)) {
                var remoteComponent = entity.GetComponent<T>();
                
                if (remoteComponent.IsRemote) {
                    OnRemoteUpdate(entity, remoteComponent, deltaTime);
                }
                else if(_localFilter.FitEntity(entity)) {
                    OnLocalUpdate(entity, deltaTime);
                }
            }
        }

        public sealed override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _remoteFilter.Apply(World)) {
                var remoteComponent = entity.GetComponent<T>();
                
                if (remoteComponent.IsRemote) {
                    OnRemoteFixedUpdate(entity, remoteComponent, deltaTime);
                }
                else if(_localFilter.FitEntity(entity)) {
                    OnLocalFixedUpdate(entity, deltaTime);
                }
            }
        }

        protected virtual IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder;
        }

        protected virtual IComponentsFilterBuilder SetupRemoteFilter(IComponentsFilterBuilder builder) {
            return builder;
        }

        protected virtual void OnLocalUpdate(Entity entity, float deltaTime) { }
        protected virtual void OnLocalFixedUpdate(Entity entity, float deltaTime) { }
        protected virtual void OnRemoteUpdate(Entity entity, T componentRemote, float deltaTime) { }
        protected virtual void OnRemoteFixedUpdate(Entity entity, T componentRemote, float deltaTime) { }

        protected void AddRemoteComponent(T remoteComponent) {
            remoteComponent.IsRemote = true;
            _networkService.NetworkEntity.AddComponent(remoteComponent);
        }
    }
}