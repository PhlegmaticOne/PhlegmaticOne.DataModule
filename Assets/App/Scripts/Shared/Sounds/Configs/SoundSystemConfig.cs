using System.Collections.Generic;
using App.Scripts.Shared.Sounds.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Shared.Sounds.Configs
{
    [CreateAssetMenu(fileName = "SoundSystemConfig", menuName = "Common/Sound/Config")]
    public class SoundSystemConfig : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<SoundType, AudioClip> _audioClips;

        public AudioClip GetAudioClip(SoundType soundType)
        {
            return _audioClips[soundType];
        }
    }
}