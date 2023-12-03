namespace PhlegmaticOne.Auth.Assets.App.Modules.Auth
{
    public class AuthData
    {
        public AuthData(string email, string password, bool isSignIn)
        {
            Email=email;
            Password=password;
            IsSignIn=isSignIn;
        }

        public string Email { get; }
        public string Password { get; }
        public bool IsSignIn { get; }
    }
}
