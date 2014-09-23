using MangoPay.SDK.Core.Interfaces;
using MangoPay.SDK.Entities;

namespace MangoPay.SDK.Tests
{
    /// <summary>Default token storage strategy implementation for tests.</summary>
    public class DefaultStorageStrategyForTests : IStorageStrategy
    {
        private static OAuthTokenDTO _oAuthToken = null;

        public OAuthTokenDTO Get()
        {
            return _oAuthToken;
        }

        public void Store(OAuthTokenDTO token)
        {
            _oAuthToken = token;
        }
    }
}
