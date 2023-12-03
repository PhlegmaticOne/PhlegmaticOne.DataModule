using Firebase.Auth;
using PhlegmaticOne.DataStorage.KeyResolvers.Base;

namespace App.Scripts.Common.FirebaseStorage.KeyResolvers
{
    public class FirebaseKeyResolver : IKeyResolver
    {
        private readonly IKeyResolver _keyResolver;

        public FirebaseKeyResolver(IKeyResolver keyResolver)
        {
            _keyResolver = keyResolver;
        }
        
        public string ResolveKey<T>() {
            var key = _keyResolver.ResolveKey<T>();
            var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
            return string.Concat("/users/", userId, "/", key);
        }
    }
}