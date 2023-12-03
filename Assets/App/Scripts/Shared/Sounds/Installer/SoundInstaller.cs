using App.Scripts.Shared.Sounds.Services;
using UnityEngine;
using Zenject;

namespace App.Scripts.Shared.Sounds.Installer
{
    public class SoundInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        
        public override void InstallBindings()
        {
            Container.Bind<AudioSource>().FromInstance(_audioSource).AsSingle();
            Container.Bind<ISoundPlayService>().To<SoundPlayService>().AsSingle();
        }
    }
}