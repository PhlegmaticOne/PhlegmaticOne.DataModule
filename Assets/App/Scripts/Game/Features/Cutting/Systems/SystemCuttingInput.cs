using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Input;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingInput : NetworkSystemBase<ComponentCuttingPoint> {
        private readonly IInputSystem _inputSystem;

        public SystemCuttingInput(IInputSystemFactory inputSystem, INetworkService networkService) : base(networkService) {
            _inputSystem = inputSystem.GetInput();
        }

        public override void OnAwake() {
            base.OnAwake();
            World.CreateEntity().WithComponent(new ComponentCuttingPoint {
                IsRemote = false,
                InputData = InputData.Invalid
            });
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var inputData = _inputSystem.ReadInput();
            var componentCuttingPoint = entity.GetComponent<ComponentCuttingPoint>();
            componentCuttingPoint.InputData = inputData;
            
            if (inputData.IsValid) {
                AddRemoteComponent(ToRemote(componentCuttingPoint));
            }
        }

        private static ComponentCuttingPoint ToRemote(ComponentCuttingPoint local) {
            var inputData = local.InputData;
            var position = inputData.Position.SubtractedX(Screen.width);
            return new ComponentCuttingPoint {
                InputData = new InputData(position, inputData.InputState, inputData.IsValid)
            };
        }
    }
}