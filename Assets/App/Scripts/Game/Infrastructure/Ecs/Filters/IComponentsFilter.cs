using System.Collections.Generic;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;

namespace App.Scripts.Game.Infrastructure.Ecs.Filters {
    public interface IComponentsFilter {
        IEnumerable<Entity> Apply(World world);
    }
}