using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Cutting.Factories;
using App.Scripts.Game.Features.Cutting.Views;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Input;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingView : NetworkSystemBase<ComponentCuttingPoint> {
        private readonly IBladeFactory _bladeFactory;
        private readonly CameraProvider _cameraProvider;

        private IComponentsFilter _filter;
        
        private BladeView _local;
        private BladeView _remote;

        public SystemCuttingView(IBladeFactory bladeFactory, CameraProvider cameraProvider,
            INetworkService networkService) : base(networkService) {
            _bladeFactory = bladeFactory;
            _cameraProvider = cameraProvider;
        }

        public override void OnAwake() {
            _local = _bladeFactory.Create(false);
            _remote = _bladeFactory.Create(true);
            base.OnAwake();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentRemote = entity.GetComponent<ComponentCuttingPoint>();
            ProcessCutEvents(_local, componentRemote);
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentCuttingPoint componentRemote, float deltaTime) {
            ProcessCutEvents(_remote, componentRemote);
            
            if (componentRemote.InputData.IsValid == false) {
                return;
            }

            var slicePoint = _cameraProvider.ScreenToWorld(componentRemote.InputData.Position);
            slicePoint.x = Mathf.Clamp(slicePoint.x, float.MinValue, 0);
            _remote.SliceTo(slicePoint);
        }

        protected override void OnLocalFixedUpdate(Entity entity, float deltaTime) {
            var componentRemote = entity.GetComponent<ComponentCuttingPoint>();
            var inputData = componentRemote.InputData;
                
            if (inputData.IsValid == false) {
                return;
            }
            
            var slicePoint = _cameraProvider.ScreenToWorld(inputData.Position);
            slicePoint.x = Mathf.Clamp(slicePoint.x, 0, float.MaxValue);
            var cuttingVector = _local.SliceTo(slicePoint);
            
            if (cuttingVector.magnitude == 0) {
                return;
            }
                
            entity.AddComponent(new ComponentCuttingVector {
                CuttingVector = cuttingVector,
                CuttingPoint = slicePoint
            });
        }

        private void ProcessCutEvents(BladeView blade, ComponentCuttingPoint componentCuttingPoint) {
            var inputData = componentCuttingPoint.InputData;
            var slicePoint = _cameraProvider.ScreenToWorld(inputData.Position);
                
            switch (inputData) {
                case { InputState: InputState.Started }:
                    blade.StartSlicing(slicePoint);
                    break;
                case { InputState: InputState.Ended }:
                    blade.EndSlicing();
                    break;
            }
        }
    }
}