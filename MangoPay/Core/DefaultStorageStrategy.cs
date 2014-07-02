using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Default token storage strategy implementation.</summary>
    public class DefaultStorageStrategy : IStorageStrategy
    {
        private static OAuthToken _oAuthToken = null;

        /// <summary>Gets the currently stored token.</summary>
        /// <returns>Currently stored token instance or null.</returns>
        public OAuthToken Get()
        {
            return _oAuthToken;
        }

        /// <summary>Stores authorization token passed as an argument.</summary>
        /// <param name="token">Token instance to be stored.</param>
        public void Store(OAuthToken token)
        {
            _oAuthToken = token;
        }
    }
}
