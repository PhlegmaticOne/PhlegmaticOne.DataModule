using System.Threading.Tasks;

namespace App.Scripts.Common.AppEvents.Contracts {
    public interface IAppEventHandler {
        AppEventType DefaultEventType { get; }
        Task HandleAsync();
    }
}