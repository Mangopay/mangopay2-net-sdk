using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for OAuth.</summary>
    public class ApiOAuth : ApiBase
    {
        /// <summary>Instantiates new ApiOAuth object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiOAuth(MangoPayApi root) : base(root) { }

        /// <summary>Gets the new token used for requests authentication.</summary>
        /// <returns>OAuth object with token information.</returns>
        public OAuthTokenDTO CreateToken()
        {
			var endPoint = GetApiEndPoint(MethodKey.AuthenticationOAuth);
            Dictionary<String, String> requestData = new Dictionary<String, String>
            {
                { Constants.GRANT_TYPE, Constants.CLIENT_CREDENTIALS }
            };

            RestTool restTool = new RestTool(this._root, false);
            AuthenticationHelper authHelper = new AuthenticationHelper(_root);

            restTool.AddRequestHttpHeader(Constants.HOST, (new Uri(_root.Config.BaseUrl)).Host);
            restTool.AddRequestHttpHeader(Constants.AUTHORIZATION, String.Format("{0} {1}", Constants.BASIC, authHelper.GetHttpHeaderBasicKey()));
            restTool.AddRequestHttpHeader(Constants.CONTENT_TYPE, Constants.APPLICATION_X_WWW_FORM_URLENCODED);

            OAuthTokenDTO response = restTool.Request<OAuthTokenDTO, OAuthTokenDTO>(endPoint, requestData);

            return response;
        }
    }
}
