using App.Scripts.Shared.Sounds.Configs;
using UnityEngine;

namespace App.Scripts.Shared.Sounds.Services
{
    public class SoundPlayService : ISoundPlayService
    {
        private readonly AudioSource _audioSource;
        private readonly SoundSystemConfig _soundSystemConfig;

        public SoundPlayService(AudioSource audioSource, SoundSystemConfig soundSystemConfig)
        {
            _audioSource = audioSource;
            _soundSystemConfig = soundSystemConfig;
            IsMuted = false;
        }

        public bool IsMuted { get; private set; }

        public void PlaySound(SoundType soundType)
        {
            var audioClip = _soundSystemConfig.GetAudioClip(soundType);
            _audioSource.PlayOneShot(audioClip);
        }

        public void SetSoundMuted(bool mute)
        {
            IsMuted = mute;
            UpdateSounds();
        }

        public void UpdateSounds()
        {
            var sounds = Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

            foreach (var sound in sounds)
            {
                sound.mute = IsMuted;
            }
        }
    }
}