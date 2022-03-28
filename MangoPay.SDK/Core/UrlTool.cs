using MangoPay.SDK.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Core
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

        private string GetHost()
        {
            if (_root.Config.BaseUrl == null || _root.Config.BaseUrl.Length == 0)
                throw new Exception("MangoPayApi.Config.BaseUrl setting is not defined.");

            Uri baseUrl = new Uri(_root.Config.BaseUrl);

            return baseUrl.Authority;
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <returns>Final REST url.</returns>
        public string GetRestUrl(string urlKey)
        {
			return GetRestUrl(urlKey, true, null, null, _root.Config.ApiVersion);
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <param name="addClientId">Denotes whether client identifier should be composed into final url.</param>
        /// <returns>Final REST url.</returns>
        public string GetRestUrl(string urlKey, Boolean addClientId)
        {
			return GetRestUrl(urlKey, addClientId, null, null, _root.Config.ApiVersion);
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <param name="addClientId">Denotes whether client identifier should be composed into final url.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Final REST url.</returns>
        public string GetRestUrl(string urlKey, Boolean addClientId, Pagination pagination)
        {
			return GetRestUrl(urlKey, addClientId, pagination, null, _root.Config.ApiVersion);
        }

        /// <summary>Gets REST url.</summary>
        /// <param name="urlKey">Url key.</param>
        /// <param name="addClientId">Denotes whether client identifier should be composed into final url.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="additionalUrlParams">Additional parameters.</param>
		/// <param name="apiVersion">API version (v2 or v2.01).</param>
        /// <returns>Final REST url.</returns>
        public string GetRestUrl(string urlKey, Boolean addClientId, Pagination pagination, Dictionary<string, string> additionalUrlParams, string apiVersion)
        {
			var url = new StringBuilder();

			url.Append(string.Format("/{0}", apiVersion));

			if (addClientId)
			{
				url.Append(string.Format("/{0}", _root.Config.ClientId));
			}

			url.Append(urlKey);

            bool paramsAdded = false;
            if (pagination != null)
            {
				url.Append(string.Format("{0}page={1}&per_page={2}", Constants.URI_QUERY_SEPARATOR, pagination.Page, pagination.ItemsPerPage));
                paramsAdded = true;
            }

            if (additionalUrlParams != null)
            {
                foreach (string key in additionalUrlParams.Keys)
                {
					url.Append(paramsAdded ? Constants.URI_QUERY_PARAMS_SEPARATOR : Constants.URI_QUERY_SEPARATOR);
					url.Append(string.Format("{0}={1}", key, Uri.EscapeDataString(additionalUrlParams[key])));
                    paramsAdded = true;
                }
            }

            return url.ToString();
        }

        /// <summary>Gets complete url.</summary>
        /// <param name="restUrl">Rest url.</param>
        /// <returns>Returns complete url.</returns>
        public string GetFullUrl(string restUrl)
        {
            var result = "";

            try
            {
                result = GetBaseUrl() + restUrl;
            }
            catch { /* Intentionally suppress exceptions here. */ }

            return result;
        }

        public string GetBaseUrl()
        {
            var result = "";

            try
            {
                result = (new Uri(_root.Config.BaseUrl)).GetComponents(UriComponents.Scheme, UriFormat.Unescaped) + "://" + this.GetHost();
            }
            catch { /* Intentionally suppress exceptions here. */ }

            return result;
        }
    }
}
