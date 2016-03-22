using MangoPay.SDK.Core.Interfaces;
using MangoPay.SDK.Entities;
using System.Collections.Generic;

namespace MangoPay.SDK.Tests
{
    /// <summary>Default token storage strategy implementation for tests.</summary>
    public class DefaultStorageStrategyForTests : IStorageStrategy
    {
        private static Dictionary<string, OAuthTokenDTO> _oAuthToken = new Dictionary<string,OAuthTokenDTO>();

		/// <summary>Gets the currently stored token.</summary>
		/// <param name="envKey">Environment key for token.</param>
		/// <returns>Currently stored token instance or null.</returns>
        public OAuthTokenDTO Get(string envKey)
        {
			if (!_oAuthToken.ContainsKey(envKey)) return null;

            return _oAuthToken[envKey];
        }

		/// <summary>Stores authorization token passed as an argument.</summary>
		/// <param name="token">Token instance to be stored.</param>
		/// <param name="envKey">Environment key for token.</param>
		public void Store(OAuthTokenDTO token, string envKey)
        {
			if (_oAuthToken.ContainsKey(envKey)) _oAuthToken[envKey] = token;
			else _oAuthToken.Add(envKey, token);
        }
    }
}
