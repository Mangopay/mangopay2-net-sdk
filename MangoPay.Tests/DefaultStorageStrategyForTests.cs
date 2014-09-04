using MangoPay.Core;
using MangoPay.Core.Interfaces;

namespace MangoPay.Tests
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
