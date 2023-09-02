#if UNITY_EDITOR
using System;
using PhlegmaticOne.Logger.Base;
using UnityEditor;
using Zenject;

namespace App.Scripts.Common.AppEvents.Implementations {
    public class AppEventsEditorHandler : AppEventsMonoHandler {
        private ILogger _logger;

        [Inject]
        private void Construct(ILogger logger) {
            _logger = logger;
        }
        
        private void Awake() {
            EditorApplication.pauseStateChanged += EditorApplicationOnpauseStateChanged;
        }

        private void OnDestroy() {
            EditorApplication.pauseStateChanged -= EditorApplicationOnpauseStateChanged;
        }

        private async void EditorApplicationOnpauseStateChanged(PauseState pauseState) {
            if (pauseState == PauseState.Paused) {
                _logger.LogMessage("Pause game in Editor");
                await ExecuteOnPauseActions();
            }
            else {
                _logger.LogMessage("Unpause game in Editor");
                await ExecuteOnUnpauseActions();
            }
        }
    }
}
#endif