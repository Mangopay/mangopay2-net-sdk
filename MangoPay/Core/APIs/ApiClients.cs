using MangoPay.Entities;
using System;
using System.Collections.Generic;

namespace MangoPay.Core
{
    /// <summary>API for clients.</summary>
    public class ApiClients : ApiBase
    {
        /// <summary>Instantiates new ApiClients object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiClients(MangoPayApi root) : base(root) { }

        /// <summary>Gets client data for Basic Access Authentication.</summary>
        /// <param name="clientId">Client's identifier.</param>
        /// <param name="clientName">Client's name for presentation.</param>
        /// <param name="clientEmail">Client's email.</param>
        /// <returns>Client instance returned from API.</returns>
        public ClientDTO Create(String clientId, String clientName, String clientEmail)
        {
            String urlMethod = this.GetRequestUrl(MethodKey.AuthenticationBase);
            String requestType = this.GetRequestType(MethodKey.AuthenticationBase);

            Dictionary<String, String> requestData = new Dictionary<String, String>
            {
                { Constants.CLIENT_ID, clientId },
                { Constants.NAME, clientName },
                { Constants.EMAIL, clientEmail }
            };

            RestTool restTool = new RestTool(this._root, false);
            restTool.AddRequestHttpHeader(Constants.CONTENT_TYPE, Constants.APPLICATION_X_WWW_FORM_URLENCODED);
            return restTool.Request<ClientDTO, ClientDTO>(urlMethod, requestType, requestData);
        }
    }
}
