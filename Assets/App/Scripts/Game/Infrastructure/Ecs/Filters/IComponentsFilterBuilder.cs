namespace App.Scripts.Game.Infrastructure.Ecs.Filters {
    public interface IComponentsFilterBuilder {
        IComponentsFilterBuilder With<T>();
        IComponentsFilterBuilder Without<T>();
        IComponentsFilter Build();
    }
}