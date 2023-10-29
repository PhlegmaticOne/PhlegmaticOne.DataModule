using App.Scripts.Game.Features.Packages.Components;
using App.Scripts.Game.Features.Packages.Models;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs.Spawners;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Packages.Systems {
    public class SystemPackageProcessor : SystemBase {
        private readonly SpawnersConfiguration _spawnersConfiguration;
        
        private IComponentsFilter _filter;

        public SystemPackageProcessor(SpawnersConfiguration spawnersConfiguration) {
            _spawnersConfiguration = spawnersConfiguration;
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentPackage>()
                .With<ComponentPackagesSpawned>()
                .Build();

            World.CreateEntity()
                .WithComponent(new ComponentUpdatePackage())
                .WithComponent(new ComponentPackagesSpawned())
                .WithComponent(new ComponentPackage());
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentPackage = entity.GetComponent<ComponentPackage>();

                if (componentPackage.PackageEntries is null) {
                    continue;
                }

                if (componentPackage.CurrentItemIndex != -1) {
                    var packageEntry = componentPackage.Current;
                    packageEntry.CurrentTime += deltaTime;

                    if (packageEntry.CurrentTime >= packageEntry.TimeToNextBlock) {
                        CreateNewBlockSpawnComponent(packageEntry);
                        componentPackage.CurrentItemIndex++;
                    }

                    if (componentPackage.CurrentItemIndex >= componentPackage.PackageEntries.Count) {
                        var componentSpawnedPackages = entity.GetComponent<ComponentPackagesSpawned>();
                        componentSpawnedPackages.PackagesSpawned++;
                        entity.AddComponent(new ComponentUpdatePackage());
                    }
                }
                else {
                    componentPackage.CurrentWaitTime += deltaTime;

                    if (componentPackage.CurrentWaitTime >= componentPackage.WaitBeforePackage) {
                        componentPackage.CurrentItemIndex = 0;
                    }
                }
            }
        }

        private void CreateNewBlockSpawnComponent(PackageEntry packageEntry) {
            var spawnerData = _spawnersConfiguration.GetRandomSpawnerData();
            
            World.AppendEntity()
                .WithComponent(new ComponentSpawnBlock {
                    BlockType = packageEntry.BlockType,
                    Acceleration = packageEntry.Gravity * Vector3.down,
                    Position = spawnerData.GetSpawnPoint(),
                    Speed = spawnerData.GetInitialSpeed(),
                });
        }
    }
}