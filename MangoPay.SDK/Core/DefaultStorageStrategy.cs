using MangoPay.SDK.Core.Interfaces;
using MangoPay.SDK.Entities;

namespace MangoPay.SDK.Core
{
    /// <summary>Default token storage strategy implementation.</summary>
    public class DefaultStorageStrategy : IStorageStrategy
    {
        private static OAuthTokenDTO _oAuthToken = null;

        /// <summary>Gets the currently stored token.</summary>
        /// <returns>Currently stored token instance or null.</returns>
        public OAuthTokenDTO Get()
        {
            return _oAuthToken;
        }

        /// <summary>Stores authorization token passed as an argument.</summary>
        /// <param name="token">Token instance to be stored.</param>
        public void Store(OAuthTokenDTO token)
        {
            _oAuthToken = token;
        }
    }
}
