using App.Scripts.Common.AppEvents.Base;
using App.Scripts.Common.AppEvents.Contracts;

namespace App.Scripts.Common.AppEvents.Extensions {
    public static class AppEventsHandlerExtensions {
        public static IAppEventsHandler AddOnPause(this IAppEventsHandler handler,
            IAppEventHandler appEventHandler) =>
            Add(handler, appEventHandler, AppEventType.Pause);
        
        public static IAppEventsHandler AddOnUnpause(this IAppEventsHandler handler,
            IAppEventHandler appEventHandler) =>
            Add(handler, appEventHandler, AppEventType.Unpause);
        
        private static IAppEventsHandler Add(IAppEventsHandler handler,
            IAppEventHandler appEventHandler, AppEventType eventType) {
            handler.AddEventHandler(appEventHandler, eventType);
            return handler;
        }
    }
}