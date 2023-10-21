namespace App.Scripts.Game.Infrastructure.Serialization {
    public interface ICloneable<out T> {
        T Clone();
    }
}