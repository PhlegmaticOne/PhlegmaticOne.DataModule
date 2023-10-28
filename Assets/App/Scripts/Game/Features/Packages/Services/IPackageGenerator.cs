using App.Scripts.Game.Features.Difficulty.Services;
using App.Scripts.Game.Features.Packages.Components;

namespace App.Scripts.Game.Features.Packages.Services {
    public interface IPackageGenerator {
        ComponentPackage GeneratePackage(DifficultyData difficultyData);
    }
}