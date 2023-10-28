using App.Scripts.Game.Features.Combo.Components;
using App.Scripts.Game.Features.Combo.Factory;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.Combo.Systems {
    public class SystemShowComboText : NetworkSystemBase<ComponentShowComboText> {
        private readonly IComboTextFactory _comboTextFactory;

        protected SystemShowComboText(INetworkService networkService, IComboTextFactory comboTextFactory) : base(networkService) {
            _comboTextFactory = comboTextFactory;
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder.With<ComponentShowComboText>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var component = entity.GetComponent<ComponentShowComboText>();
            _comboTextFactory.ShowComboText(component);
            AddRemoteComponent(ToRemote(component));
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentShowComboText componentRemote, float deltaTime) {
            _comboTextFactory.ShowComboText(componentRemote);
        }

        private static ComponentShowComboText ToRemote(ComponentShowComboText componentShowComboText) {
            var position = componentShowComboText.PositionWorld.InvertX();
            return new ComponentShowComboText {
                PositionWorld = position,
                ComboValue = componentShowComboText.ComboValue
            };
        }
    }
}