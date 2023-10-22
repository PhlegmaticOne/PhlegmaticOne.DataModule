using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Infrastructure.Input;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingInput : SystemBase {
        private readonly IInputSystem _inputSystem;
        private readonly INetworkService _networkService;

        private IComponentsFilter _filter;

        public SystemCuttingInput(IInputSystemFactory inputSystem, INetworkService networkService) {
            _inputSystem = inputSystem.CreateInput();
            _networkService = networkService;
        }

        public override void OnAwake() {
            World.CreateEntity().WithComponent(new ComponentCuttingPoint {
                IsRemote = false,
                InputData = InputData.Invalid
            });
            _filter = ComponentsFilter.Builder
                .With<ComponentCuttingPoint>()
                .Without<ComponentNetwork>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            var inputData = _inputSystem.ReadInput();

            foreach (var entity in _filter.Apply(World)) {
                var component = entity.GetComponent<ComponentCuttingPoint>();

                if (component.IsRemote) {
                    continue;
                }

                component.InputData = inputData;

                if (inputData.IsValid) {
                    _networkService.NetworkEntity.AddComponent(component.ToRemote());
                }
            }
        }
    }
}