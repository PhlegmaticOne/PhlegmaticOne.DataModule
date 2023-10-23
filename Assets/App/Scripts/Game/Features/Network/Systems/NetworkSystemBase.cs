using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Network.Systems {
    public class NetworkSystemBase<T> : SystemBase where T : ComponentRemoteBase {
        private readonly INetworkService _networkService;

        private IComponentsFilter _filter;

        protected NetworkSystemBase(INetworkService networkService) {
            _networkService = networkService;
        }

        public override void OnAwake() {
            var filter = ComponentsFilter.Builder.With<T>().Without<ComponentNetwork>();
            _filter = SetupFilter(filter).Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var remoteComponent = entity.GetComponent<T>();

                if (remoteComponent.IsRemote) {
                    OnRemoteUpdate(entity, remoteComponent, deltaTime);
                }
                else {
                    OnLocalUpdate(entity, remoteComponent, deltaTime);
                }
            }
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var remoteComponent = entity.GetComponent<T>();

                if (remoteComponent.IsRemote) {
                    OnRemoteFixedUpdate(entity, remoteComponent, deltaTime);
                }
                else {
                    OnLocalFixedUpdate(entity, remoteComponent, deltaTime);
                }
            }
        }

        protected virtual void OnLocalUpdate(Entity entity, T componentRemote, float deltaTime) { }
        protected virtual void OnLocalFixedUpdate(Entity entity, T componentRemote, float deltaTime) { }
        protected virtual void OnRemoteUpdate(Entity entity, T componentRemote, float deltaTime) { }
        protected virtual void OnRemoteFixedUpdate(Entity entity, T componentRemote, float deltaTime) { }

        protected void AddRemoteComponent(T remoteComponent) {
            remoteComponent.IsRemote = true;
            _networkService.NetworkEntity.AddComponent(remoteComponent);
        }

        protected virtual IComponentsFilterBuilder SetupFilter(IComponentsFilterBuilder filterBuilder) {
            return filterBuilder;
        }
    }
}