using System.Collections.Generic;
using App.Scripts.Game.Features.Packages.Models;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Packages.Components {
    public class ComponentPackage : IComponent {
        public List<PackageEntry> PackageEntries;
        public int CurrentItemIndex = -1;
        public float WaitBeforePackage;
        public float CurrentWaitTime;

        public PackageEntry Current => PackageEntries[CurrentItemIndex];
    }
}