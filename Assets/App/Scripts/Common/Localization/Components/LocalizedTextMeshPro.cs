using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace App.Scripts.Common.Localization.Components {
    [RequireComponent(typeof(LocalizeStringEvent), typeof(TextMeshProUGUI))]
    public class LocalizedTextMeshPro : MonoBehaviour {
        [SerializeField] private LocalizeStringEvent _localizeStringEvent;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        private void OnValidate() {
            _localizeStringEvent = GetComponent<LocalizeStringEvent>();
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable() {
            _localizeStringEvent.OnUpdateString.AddListener(UpdateText);
            _localizeStringEvent.RefreshString();
        }

        private void OnDisable() {
            _localizeStringEvent.OnUpdateString.RemoveAllListeners();
        }

        private void UpdateText(string text) {
            _textMeshProUGUI.text = text;
        }
    }
}