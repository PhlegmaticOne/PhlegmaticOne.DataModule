using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Scripts.Common.AppEvents.Base;
using App.Scripts.Common.AppEvents.Contracts;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.AppEvents.Implementations {
    public class AppEventsMonoHandler : MonoBehaviour, IAppEventsHandler {
        private Dictionary<AppEventType, List<IAppEventHandler>> _globalEvents;

        [Inject]
        private void Construct(IEnumerable<IAppEventHandler> initialEventHandlers) {
            _globalEvents = initialEventHandlers
                .ToDictionary(x => x.DefaultEventType, x => new List<IAppEventHandler> { x });
        }

        public void AddEventHandler(IAppEventHandler appEventHandler) {
            AddEventHandler(appEventHandler, appEventHandler.DefaultEventType);
        }
        
        public void AddEventHandler(IAppEventHandler appEventHandler, AppEventType eventType) {
            if (_globalEvents.TryGetValue(eventType, out var applicationEvents)) {
                applicationEvents.Add(appEventHandler);
            }
            else {
                _globalEvents.Add(eventType, new List<IAppEventHandler> {
                    appEventHandler
                });
            }
        }

        protected Task ExecuteOnPauseActions() => ExecuteActions(AppEventType.Pause);
        protected Task ExecuteOnUnpauseActions() => ExecuteActions(AppEventType.Unpause);

        private async Task ExecuteActions(AppEventType eventType) {
            if (_globalEvents.TryGetValue(eventType, out var events) == false) {
                return;
            }

            foreach (var appEventHandler in events) {
                await appEventHandler.HandleAsync();
            }
        }
    }
}