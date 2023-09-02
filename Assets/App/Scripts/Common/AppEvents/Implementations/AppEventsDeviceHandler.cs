using Zenject;
using ILogger = PhlegmaticOne.Logger.Base.ILogger;

namespace App.Scripts.Common.AppEvents.Implementations {
    public class AppEventsDeviceHandler : AppEventsMonoHandler {
        private ILogger _logger;

        [Inject]
        private void Construct(ILogger logger) {
            _logger = logger;
        }

        private void Start() {
            _logger.LogMessage("AppEventsHandler started");
        }

        private async void OnApplicationPause(bool pauseStatus) {
            if (pauseStatus) {
                _logger.LogMessage("Calling OnPause actions...");
                await ExecuteOnPauseActions();
            }
            else {
                _logger.LogMessage("Calling OnUnpause actions...");
                await ExecuteOnUnpauseActions();
            }
        }
    }
}