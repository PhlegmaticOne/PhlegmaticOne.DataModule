using App.Scripts.Common.AppEvents.Contracts;

namespace App.Scripts.Common.AppEvents.Base {
    public interface IAppEventsHandler {
        void AddEventHandler(IAppEventHandler appEventHandler, AppEventType eventType);
    }
}