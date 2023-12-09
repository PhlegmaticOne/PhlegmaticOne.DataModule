using App.Scripts.Game.Features.Health.Components;
using App.Scripts.Game.Features.Health.Configs;
using App.Scripts.Game.Features.Health.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Modes.Base;
using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.Features.Health.Systems
{
    public class SystemHealthAction : NetworkSystemBase<ComponentLoseHealth>
    {
        private readonly IHealthService _healthService;
        private readonly HealthViewsConfig _viewsConfig;
        private readonly IGameModeProvider _gameModeProvider;

        protected SystemHealthAction(
            INetworkService networkService,
            IHealthService healthService,
            HealthViewsConfig viewsConfig,
            IGameModeProvider gameModeProvider) : base(networkService)
        {
            _healthService = healthService;
            _viewsConfig = viewsConfig;
            _gameModeProvider = gameModeProvider;
        }

        public override void OnAwake()
        {
            if (_gameModeProvider.GameModeType == GameModeType.ByLifes)
            {
                _viewsConfig.Initialize(_healthService.CurrentHealth);
            }
            
            base.OnAwake();
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder)
        {
            return builder.With<ComponentLoseHealth>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime)
        {
            _viewsConfig.RemoveHeart(false);
            _healthService.LoseHealth();
            AddRemoteComponent(new ComponentLoseHealth());
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentLoseHealth componentRemote, float deltaTime)
        {
            _viewsConfig.RemoveHeart(true);
        }
    }
}