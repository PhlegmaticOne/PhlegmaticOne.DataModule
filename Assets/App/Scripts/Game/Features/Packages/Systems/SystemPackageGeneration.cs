using App.Scripts.Game.Features.Difficulty.Services;
using App.Scripts.Game.Features.Packages.Components;
using App.Scripts.Game.Features.Packages.Services;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Packages.Systems {
    public class SystemPackageGeneration : SystemBase {
        private readonly ISpawningDifficulty _spawningDifficulty;
        private readonly IPackageGenerator _packageGenerator;

        private IComponentsFilter _filter;

        public SystemPackageGeneration(ISpawningDifficulty spawningDifficulty,
            IPackageGenerator packageGenerator) {
            _spawningDifficulty = spawningDifficulty;
            _packageGenerator = packageGenerator;
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentUpdatePackage>()
                .With<ComponentPackagesSpawned>()
                .With<ComponentPackage>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentPackagesSpawned = entity.GetComponent<ComponentPackagesSpawned>();
                var packagesSpawned = componentPackagesSpawned.PackagesSpawned;
                var newDifficulty = _spawningDifficulty.CalculateDifficulty(packagesSpawned);
                var package = _packageGenerator.GeneratePackage(newDifficulty);
                
                entity.RemoveComponent<ComponentPackage>();
                entity.RemoveComponent<ComponentUpdatePackage>();
                entity.AddComponent(package);
            }
        }
    }
}