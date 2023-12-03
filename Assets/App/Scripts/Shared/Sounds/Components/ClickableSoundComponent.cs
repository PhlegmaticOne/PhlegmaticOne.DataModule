using App.Scripts.Shared.Sounds.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace App.Scripts.Shared.Sounds.Components
{
    public class ClickableSoundComponent : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoundType _soundType;
        
        private ISoundPlayService _soundPlayService;

        [Inject]
        private void Construct(ISoundPlayService soundPlayService)
        {
            _soundPlayService = soundPlayService;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _soundPlayService.PlaySound(_soundType);
        }
    }
}