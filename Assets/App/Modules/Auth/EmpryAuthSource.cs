using System.Threading.Tasks;

namespace PhlegmaticOne.Auth.Assets.App.Modules.Auth
{
    public class EmpryAuthSource : IAuthSource
    {
        public Task<AuthData> GetAuthDataAsync()
        {
            return Task.FromResult(new AuthData(string.Empty, string.Empty, true));
        }
    }
}
