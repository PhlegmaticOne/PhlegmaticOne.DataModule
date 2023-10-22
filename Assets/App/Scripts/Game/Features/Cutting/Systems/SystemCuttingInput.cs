using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Input;
using App.Scripts.Game.Infrastructure.Serialization;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingInput : NetworkSystemBase<ComponentCuttingPoint> {
        private readonly IInputSystem _inputSystem;

        public SystemCuttingInput(IInputSystemFactory inputSystem, INetworkService networkService) : base(networkService) {
            _inputSystem = inputSystem.CreateInput();
        }

        public override void OnAwake() {
            base.OnAwake();
            World.CreateEntity().WithComponent(new ComponentCuttingPoint {
                IsRemote = false,
                InputData = InputData.Invalid
            });
        }

        protected override void OnLocalUpdate(Entity entity, ComponentCuttingPoint componentRemote, float deltaTime) {
            var inputData = _inputSystem.ReadInput();
            componentRemote.InputData = inputData;
            
            if (inputData.IsValid) {
                AddRemoteComponent(ToRemote(componentRemote));
            }
        }

        private static ComponentCuttingPoint ToRemote(ComponentCuttingPoint local) {
            var inputData = local.InputData;
            var p = inputData.Position;
            var position = new Vector3Tiny(Screen.width - p.x, p.y, p.z);
            
            return new ComponentCuttingPoint {
                IsRemote = true,
                InputData = new InputData(position, inputData.InputState, inputData.IsValid)
            };
        }
    }
}