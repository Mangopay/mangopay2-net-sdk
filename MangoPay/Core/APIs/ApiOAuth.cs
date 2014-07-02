using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for OAuth.</summary>
    public class ApiOAuth : ApiBase
    {
        /// <summary>Instantiates new ApiOAuth object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiOAuth(MangoPayApi root) : base(root) { }

        /// <summary>Gets the new token used for requests authentication.</summary>
        /// <returns>OAuth object with token information.</returns>
        public OAuthToken CreateToken()
        {
            String urlMethod = this.GetRequestUrl("authentication_oauth");
            String requestType = this.GetRequestType("authentication_oauth");
            Dictionary<String, String> requestData = new Dictionary<String, String>
            {
                { "grant_type", "client_credentials" }
            };

            RestTool rest = new RestTool(this._root, false);
            AuthenticationHelper authHlp = new AuthenticationHelper(_root);

            try
            {
                rest.AddRequestHttpHeader("Host", (new Uri(_root.Config.BaseUrl)).Host);
            }
            catch (Exception ex)
            {
                //Logger.getLogger(ApiOAuth.class.getName()).log(Level.SEVERE, null, ex);
            }
            try
            {
                rest.AddRequestHttpHeader("Authorization", "Basic " + authHlp.GetHttpHeaderBasicKey());
            }
            catch (Exception ex)
            {
                //Logger.getLogger(ApiOAuth.class.getName()).log(Level.SEVERE, null, ex);
            }
            rest.AddRequestHttpHeader("Content-Type", "application/x-www-form-urlencoded");
            OAuthToken response = rest.Request<OAuthToken>(urlMethod, requestType, requestData);

            return response;
        }
    }
}
