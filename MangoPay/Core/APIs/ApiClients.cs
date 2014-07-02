using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for clients.</summary>
    public class ApiClients : ApiBase
    {
        /// <summary>Instantiates new ApiClients object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiClients(MangoPayApi root) : base(root) { }

        /// <summary>Gets client data for Basic Access Authentication.</summary>
        /// <param name="clientId">Client identifier.</param>
        /// <param name="clientName">Beautiful name for presentation.</param>
        /// <param name="clientEmail">Client's email.</param>
        /// <returns>Client instance returned from API.</returns>
        public Client Create(String clientId, String clientName, String clientEmail)
        {
            String urlMethod = this.GetRequestUrl("authentication_base");
            String requestType = this.GetRequestType("authentication_base");

            Dictionary<String, String> requestData = new Dictionary<String, String>
            {
                { "ClientId", clientId },
                { "Name", clientName },
                { "Email", clientEmail }
            };

            RestTool rest = new RestTool(this._root, false);
            rest.AddRequestHttpHeader("Content-Type", "application/x-www-form-urlencoded");
            return rest.Request<Client>(urlMethod, requestType, requestData);
        }
    }
}
