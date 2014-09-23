using MangoPay.SDK.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Core
{
    /// <summary>Authentication helper class.</summary>
    internal class AuthenticationHelper
    {
        // Root/parent instance that holds the OAuthToken and Configuration instance
        private MangoPayApi _root;

        /// <summary>Instantiates new AuthenticationHelper object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public AuthenticationHelper(MangoPayApi root)
        {
            this._root = root;
        }

        /// <summary>Gets HTTP header value with authorization string.</summary>
        /// <returns></returns>
        public Dictionary<String, String> GetHttpHeaderKey()
        {
            return GetHttpHeaderStrong();
        }

        /// <summary>Gets basic key for HTTP header.</summary>
        /// <returns>Authorization string.</returns>
        public String GetHttpHeaderBasicKey()
        {
            if (String.IsNullOrEmpty(_root.Config.ClientId))
                throw new Exception("MangoPay.Config.ClientId is not set.");

            if (String.IsNullOrEmpty(_root.Config.ClientPassword))
                throw new Exception("MangoPay.Config.ClientPassword is not set.");

            String signature = _root.Config.ClientId + ':' + _root.Config.ClientPassword;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(signature));
        }

        // gets HTTP header value with authorization string for basic authentication
        private Dictionary<String, String> GetHttpHeaderBasic()
        {
            return new Dictionary<String, String> 
            {
                { Constants.AUTHORIZATION, String.Format("{0} {1}", Constants.BASIC, GetHttpHeaderBasicKey()) }
            };
        }

        // gets HTTP header value with authorization string for strong authentication
        private Dictionary<String, String> GetHttpHeaderStrong()
        {
            OAuthTokenDTO token = _root.OAuthTokenManager.GetToken();

            if (token == null || String.IsNullOrEmpty(token.access_token) || String.IsNullOrEmpty(token.token_type))
                throw new Exception("OAuth token is not created (or is invalid) for strong authentication");

            return new Dictionary<String, String> 
            {
                { Constants.AUTHORIZATION, token.token_type + " " + token.access_token }
            };
        }
    }
}
