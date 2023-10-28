using App.Scripts.Game.Features.Packages.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Packages.Systems {
    public class SystemPackageProcessor : SystemBase {
        private IComponentsFilter _filter;

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentPackage>()
                .With<ComponentPackagesSpawned>()
                .Build();

            World.CreateEntity()
                .WithComponent(new ComponentUpdatePackage())
                .WithComponent(new ComponentPackagesSpawned {
                    PackagesSpawned = 0
                })
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
                        World.AppendEntity()
                            .WithComponent(new ComponentSpawnBlock {
                                BlockType = packageEntry.BlockType
                            });
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
    }
}