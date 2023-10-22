using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Cutting.Factories;
using App.Scripts.Game.Features.Cutting.Views;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Infrastructure.Input;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingView : SystemBase {
        private readonly IBladeFactory _bladeFactory;
        private readonly CameraProvider _cameraProvider;

        private IComponentsFilter _filter;
        
        private BladeView _local;
        private BladeView _remote;

        public SystemCuttingView(IBladeFactory bladeFactory, CameraProvider cameraProvider) {
            _bladeFactory = bladeFactory;
            _cameraProvider = cameraProvider;
        }

        public override void OnAwake() {
            _local = _bladeFactory.Create(false);
            _remote = _bladeFactory.Create(true);
            _filter = ComponentsFilter.Builder
                .With<ComponentCuttingPoint>()
                .Without<ComponentNetwork>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var cuttingPoint = entity.GetComponent<ComponentCuttingPoint>();
                var blade = cuttingPoint.IsRemote ? _remote : _local;
                var inputData = cuttingPoint.InputData;
                var slicePoint = GetSlicePoint(inputData.Position);
                
                switch (inputData.InputState)
                {
                    case InputState.Started:
                        blade.StartSlicing(slicePoint);
                        break;
                    case InputState.Ended:
                        blade.EndSlicing();
                        break;
                }
            }
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var cuttingPoint = entity.GetComponent<ComponentCuttingPoint>();
                var inputData = cuttingPoint.InputData;
                
                if (inputData.IsValid == false) {
                    continue;
                }
                
                var blade = cuttingPoint.IsRemote ? _remote : _local;
                var slicePoint = GetSlicePoint(inputData.Position);
                blade.SliceTo(slicePoint);

                if (cuttingPoint.IsRemote) {
                    entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
                }
            }
        }

        private Vector3 GetSlicePoint(in Vector3 inputPosition) {
            var camera = _cameraProvider.Camera;
            var position = camera.ScreenToWorldPoint(inputPosition);
            position.z = camera.nearClipPlane;
            return position;
        }
    }
}