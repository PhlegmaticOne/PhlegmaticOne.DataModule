namespace App.Scripts.Shared.Sounds.Services
{
    public interface ISoundPlayService
    {
        bool IsMuted { get; }
        void PlaySound(SoundType soundType);
        void SetSoundMuted(bool mute);
        void UpdateSounds();
    }
}