using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    /// <summary>Default token storage strategy implementation for tests.</summary>
    public class DefaultStorageStrategyForTests : IStorageStrategy
    {
        private static OAuthToken _oAuthToken = null;

        public OAuthToken Get()
        {
            return _oAuthToken;
        }

        public void Store(OAuthToken token)
        {
            _oAuthToken = token;
        }
    }
}
