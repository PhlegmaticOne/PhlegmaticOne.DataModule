using App.Scripts.Game.Features.Cutting.Views;

namespace App.Scripts.Game.Features.Cutting.Factories {
    public interface IBladeFactory {
        BladeView Create(bool isRemote);
    }
}