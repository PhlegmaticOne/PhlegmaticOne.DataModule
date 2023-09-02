using System.Threading.Tasks;

namespace PhlegmaticOne.Auth {
    public interface IAuthProvider {
        Task SignInAsync();
        void SignOut();
    }
}