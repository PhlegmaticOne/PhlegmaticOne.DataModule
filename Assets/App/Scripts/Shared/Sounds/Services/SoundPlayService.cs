using App.Scripts.Game.Features.Sound.Components;
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
        }
        
        public void PlaySound(SoundType soundType)
        {
            var audioClip = _soundSystemConfig.GetAudioClip(soundType);
            _audioSource.PlayOneShot(audioClip);
        }
    }
}