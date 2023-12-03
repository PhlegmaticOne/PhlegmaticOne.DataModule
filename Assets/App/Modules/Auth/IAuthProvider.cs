using PhlegmaticOne.Auth.Assets.App.Modules.Auth;
using System.Threading.Tasks;

namespace PhlegmaticOne.Auth {
    public interface IAuthProvider {
        Task SignInAsync(IAuthSource authSource);
        void SignOut();
    }
}