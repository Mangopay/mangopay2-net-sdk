using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Helper class to manage URLs.</summary>
    internal class UrlTool
    {
        // root/parent instance that holds the OAuthToken and Configuration instance
        private MangoPayApi _root;

        /// <summary>Instantiates new UrlTool object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public UrlTool(MangoPayApi root)
        {
            this._root = root;
        }

        private String GetHost()
        {
            if (_root.Config.BaseUrl == null || _root.Config.BaseUrl.Length == 0)
                throw new Exception("MangoPayApi.Config.BaseUrl setting is not defined.");

            Uri baseUrl = new Uri(_root.Config.BaseUrl);

            return baseUrl.Host;
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <returns>Final REST url.</returns>
        public String GetRestUrl(String urlKey)
        {
            return GetRestUrl(urlKey, true, null, null);
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <param name="addClientId">Denotes whether client identifier should be composed into final url.</param>
        /// <returns>Final REST url.</returns>
        public String GetRestUrl(String urlKey, Boolean addClientId)
        {
            return GetRestUrl(urlKey, addClientId, null, null);
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <param name="addClientId">Denotes whether client identifier should be composed into final url.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Final REST url.</returns>
        public String GetRestUrl(String urlKey, Boolean addClientId, Pagination pagination)
        {
            return GetRestUrl(urlKey, addClientId, pagination, null);
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <param name="addClientId">Denotes whether client identifier should be composed into final url.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="additionalUrlParams">Additional parameters.</param>
        /// <returns>Final REST url.</returns>
        public String GetRestUrl(String urlKey, Boolean addClientId, Pagination pagination, Dictionary<String, String> additionalUrlParams)
        {
            String url;

            if (!addClientId)
            {
                url = "/v2" + urlKey;
            }
            else
            {
                url = "/v2/" + _root.Config.ClientId + urlKey;
            }

            bool paramsAdded = false;
            if (pagination != null)
            {
                url += "?page=" + pagination.Page + "&per_page=" + pagination.ItemsPerPage;
                paramsAdded = true;
            }

            if (additionalUrlParams != null)
            {
                foreach (var key in additionalUrlParams.Keys)
                {

                    url += paramsAdded ? "&" : "?";
                    url += key + "=" + Uri.EscapeDataString(additionalUrlParams[key]);
                    paramsAdded = true;
                }
            }

            return url;
        }

        /// <summary>Gets complete url.</summary>
        /// <param name="restUrl">Rest url.</param>
        /// <returns>Complete url.</returns>
        public String GetFullUrl(String restUrl)
        {
            String result = "";

            try
            {
                result = (new Uri(_root.Config.BaseUrl)).GetComponents(UriComponents.Scheme, UriFormat.Unescaped) + "://" + this.GetHost() + restUrl;
            }
            catch (Exception ex) { }

            return result;
        }
    }
}
