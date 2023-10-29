using System.Collections.Generic;
using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Magnet.Components;
using App.Scripts.Game.Features.Magnet.Configs;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Magnet.Systems {
    public class SystemMagnet : SystemBase {
        private readonly MagnetSystemConfig _config;
        
        private IComponentsFilter _filter;
        private IComponentsFilter _magnetizeFilter;
        private IComponentsFilter _deMagnetizeFilter;

        public SystemMagnet(MagnetSystemConfig config) {
            _config = config;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentMagnetActive>()
                .Build();

            _magnetizeFilter = ComponentsFilter.Builder
                .With<ComponentGravity>()
                .With<ComponentMagnetized>()
                .With<ComponentBlock>()
                .Build();
            
            _deMagnetizeFilter = ComponentsFilter.Builder
                .With<ComponentGravity>()
                .With<ComponentCurrentMagnetized>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            ComponentMagnetActive local = default;
            ComponentMagnetActive remote = default;
            
            foreach (var entity in _filter.Apply(World)) {
                var componentMagnetActive = entity.GetComponent<ComponentMagnetActive>();

                if(CheckReCut(local, componentMagnetActive, entity) || CheckReCut(remote, componentMagnetActive, entity)) {
                    continue;
                }

                if (componentMagnetActive.IsApplied == false) {
                    ShowMagnetScreen(componentMagnetActive);
                    componentMagnetActive.IsApplied = true;
                }
                
                componentMagnetActive.CurrentTime += deltaTime;
                Magnetize(componentMagnetActive);
                
                if (componentMagnetActive.CurrentTime >= componentMagnetActive.Time) {
                    DeMagnetize(componentMagnetActive);
                    entity.RemoveEndOfFrame();
                }

                local = !componentMagnetActive.IsRemote ? componentMagnetActive : local;
                remote = componentMagnetActive.IsRemote ? componentMagnetActive : remote;
            }
        }

        private void DeMagnetize(ComponentMagnetActive componentMagnetActive) {
            foreach (var entity in _deMagnetizeFilter.Apply(World)) {
                var block = entity.GetComponent<ComponentBlock>().Block;

                if (block.IsRemote != componentMagnetActive.IsRemote) {
                    continue;
                }
                
                var gravityComponent = entity.GetComponent<ComponentGravity>();
                var angle = Random.Range(0, 360);
                var speed = Quaternion.Euler(0, 0, angle) * Vector3.right * componentMagnetActive.ThrowPower;
                gravityComponent.Speed = speed;
                gravityComponent.Acceleration = new Vector3(0, -8);
                entity.RemoveComponent<ComponentCurrentMagnetized>();
            }
            
            HideMagnetScreen(componentMagnetActive);
        }

        private void Magnetize(ComponentMagnetActive componentMagnetActive) {
            var positions = new List<Vector3>();
            var point = componentMagnetActive.PositionWorld;
            var power = componentMagnetActive.Force;
            var magnetizedCenterRadius = componentMagnetActive.MagnetizedCenterRadius;
            
            foreach (var entity in _magnetizeFilter.Apply(World)) {
                var block = entity.GetComponent<ComponentBlock>().Block;

                if (!IsBlockValid(block, point, componentMagnetActive)) {
                    continue;
                }
                
                var gravityComponent = entity.GetComponent<ComponentGravity>();
                var position = block.transform.position;
                positions.Add(position);
                var direction = point - position.WithZ(0);
                var speedVector = direction.normalized * power;
                gravityComponent.Acceleration = Vector3.zero;
                gravityComponent.Speed = direction.magnitude <= magnetizedCenterRadius ? Vector3.zero : speedVector;
                entity.AddComponent(new ComponentCurrentMagnetized());
            }
            
            DrawLines(componentMagnetActive, positions);
        }

        private void ShowMagnetScreen(ComponentMagnetActive componentMagnetActive) {
            var screen = componentMagnetActive.IsRemote ? _config.Remote : _config.Local;
            screen.Show(componentMagnetActive.PositionWorld, componentMagnetActive.Radius);
        }

        private void HideMagnetScreen(ComponentMagnetActive componentMagnetActive) {
            var screen = componentMagnetActive.IsRemote ? _config.Remote : _config.Local;
            screen.Hide();
        }

        private void DrawLines(ComponentMagnetActive componentMagnetActive, List<Vector3> lines) {
            var screen = componentMagnetActive.IsRemote ? _config.Remote : _config.Local;
            screen.DrawLines(componentMagnetActive.PositionWorld, lines);
        }

        private static bool IsBlockValid(Block block, Vector3 point, ComponentMagnetActive componentMagnetActive) {
            var pos = block.transform.position.WithZ(point.z);
            var distance = Vector3.Distance(pos, point);
            return distance <= componentMagnetActive.Radius && block.IsRemote == componentMagnetActive.IsRemote;
        }

        private static bool CheckReCut(ComponentMagnetActive current, ComponentMagnetActive newComponent, Entity newEntity) {
            if (current != null && newComponent.IsRemote == current.IsRemote) {
                current.CurrentTime = 0;
                newEntity.RemoveEndOfFrame();
                return true;
            }

            return false;
        }
    }
}