using System.Threading.Tasks;

namespace PhlegmaticOne.Auth.Assets.App.Modules.Auth
{
    public interface IAuthSource
    {
        Task<AuthData> GetAuthDataAsync();
    }
}
