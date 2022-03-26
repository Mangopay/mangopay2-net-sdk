using MangoPay.SDK.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core
{
    /// <summary>Authentication helper class.</summary>
    internal class AuthenticationHelper
    {
        // Root/parent instance that holds the OAuthToken and Configuration instance
        private readonly MangoPayApi _root;

        /// <summary>Instantiates new AuthenticationHelper object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public AuthenticationHelper(MangoPayApi root)
        {
            this._root = root;
        }

        /// <summary>Gets HTTP header value with authorization string.</summary>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetHttpHeaderKeyAsync()
        {
            return await GetHttpHeaderStrongAsync();
        }

        /// <summary>Gets basic key for HTTP header.</summary>
        /// <returns>Authorization string.</returns>
        public string GetHttpHeaderBasicKey()
        {
            if (string.IsNullOrEmpty(_root.Config.ClientId))
                throw new Exception("MangoPay.Config.ClientId is not set.");

            if (string.IsNullOrEmpty(_root.Config.ClientPassword))
                throw new Exception("MangoPay.Config.ClientPassword is not set.");

            var signature = $"{_root.Config.ClientId}:{_root.Config.ClientPassword}";

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(signature));
        }

        // gets HTTP header value with authorization string for strong authentication
        private async Task<Dictionary<string, string>> GetHttpHeaderStrongAsync()
        {
            var token = await _root.OAuthTokenManager.GetTokenAsync();

            if (token == null || string.IsNullOrEmpty(token.access_token) || string.IsNullOrEmpty(token.token_type))
                throw new Exception("OAuth token is not created (or is invalid) for strong authentication");

            return new Dictionary<string, string> 
            {
                { Constants.AUTHORIZATION, token.token_type + " " + token.access_token }
            };
        }
    }
}
