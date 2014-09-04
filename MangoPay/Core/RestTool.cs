using MangoPay.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MangoPay.Core
{
    /// <summary>Class used to build HTTP request, call the request and handle response.</summary>
    internal class RestTool
    {
        // root/parent instance that holds the OAuthToken and Configuration instance
        private MangoPayApi _root;

        // enable/disable log debugging
        private bool _debugMode;

        // variable to flag that in request authentication data are required
        private Boolean _authRequired;

        // array with HTTP header to send with request
        private Dictionary<String, String> _requestHttpHeaders;

        // request type for current request
        private String _requestType;

        // key-value collection pass to the request
        private Dictionary<String, String> _requestData;

        // code get from response
        private int _responseCode;

        // pagination object
        private Pagination _pagination;

        /// <summary>Instantiates new RestTool object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        /// <param name="authRequired">Defines whether request authentication is required.</param>
        public RestTool(MangoPayApi root, bool authRequired)
        {
            this._root = root;
            this._authRequired = authRequired;
            this._debugMode = this._root.Config.DebugMode;
        }

        /// <summary>Adds HTTP headers as name/value pairs into the request.</summary>
        /// <param name="httpHeader">Collection of headers name/value pairs.</param>
        internal void AddRequestHttpHeader(Dictionary<String, String> httpHeader)
        {
            if (this._requestHttpHeaders == null)
                this._requestHttpHeaders = new Dictionary<String, String>();

            foreach (KeyValuePair<string, string> item in httpHeader)
            {
                this._requestHttpHeaders.Add(item.Key, item.Value);
            }
        }

        /// <summary>Adds HTTP header into the request.</summary>
        /// <param name="key">Header name.</param>
        /// <param name="value">Header value.</param>
        internal void AddRequestHttpHeader(String key, String value)
        {
            AddRequestHttpHeader(new Dictionary<String, String> { { key, value } });
        }

        /// <summary>Checks the HTTP response code and if it's neither 200 nor 204 throws a ResponseException.</summary>
        /// <param name="message">Text response.</param>
        private void CheckResponseCode(String textResponse)
        {
            if (this._responseCode != 200 && this._responseCode != 204)
            {
                if (this._responseCode == 401)
                {
                    throw new UnauthorizedAccessException(textResponse);
                }
                else
                {
                    ResponseError error = JsonConvert.DeserializeObject<ResponseError>(textResponse);
                    ResponseException rex = new ResponseException(textResponse);
                    rex.ResponseError = error;

                    throw rex;
                }
            }
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// DTO instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entity">Instance of DTO class that is going to be sent in case of PUTting or POSTing.</param>
        /// <returns>The DTO instance returned from API.</returns>
        public U Request<U, T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination, T entity)
            where U : new()
        {
            this._requestType = requestType;
            this._requestData = requestData;

            U responseResult = this.DoRequest<U, T>(urlMethod, pagination, entity);

            return responseResult;
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// DTO instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <returns>The DTO instance returned from API.</returns>
        public U Request<U, T>(String urlMethod, String requestType)
            where U : new()
        {
            return Request<U, T>(urlMethod, requestType, null, null, default(T));
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// DTO instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <returns>The DTO instance returned from API.</returns>
        public U Request<U, T>(String urlMethod, String requestType, Dictionary<String, String> requestData)
            where U : new()
        {
            return Request<U, T>(urlMethod, requestType, requestData, null, default(T));
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// DTO instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>The DTO instance returned from API.</returns>
        public U Request<U, T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination)
            where U : new()
        {
            return Request<U, T>(urlMethod, requestType, requestData, pagination, default(T));
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// DTO instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="additionalUrlParams"></param>
        /// <returns>Collection of DTO instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination, Dictionary<String, String> additionalUrlParams)
            where T : new()
        {
            this._requestType = requestType;
            this._requestData = requestData;

            List<T> responseResult = this.DoRequestList<T>(urlMethod, pagination, additionalUrlParams);

            return responseResult;
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// DTO instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <returns>Collection of DTO instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType)
            where T : new()
        {
            return RequestList<T>(urlMethod, requestType, null, null, null);
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// DTO instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <returns>Collection of DTO instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType, Dictionary<String, String> requestData)
            where T : new()
        {
            return RequestList<T>(urlMethod, requestType, requestData, null, null);
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// DTO instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Collection of DTO instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination)
            where T : new()
        {
            return RequestList<T>(urlMethod, requestType, requestData, pagination, null);
        }

        private U DoRequest<U, T>(String urlMethod, Pagination pagination)
            where T : new()
            where U : new()
        {
            return DoRequest<U, T>(urlMethod, pagination, default(T));
        }

        private U DoRequest<U, T>(String urlMethod, Pagination pagination, T entity)
            where U : new()
        {
            U responseObject = default(U);

            UrlTool urlTool = new UrlTool(_root);
            String restUrl = urlTool.GetRestUrl(urlMethod, this._authRequired, pagination, null);
            
            string fullUrl = urlTool.GetFullUrl(restUrl);
            RestClient client = new RestClient(fullUrl);

            client.AddHandler(Constants.APPLICATION_JSON, new MangoPayJsonDeserializer());

            if (this._debugMode)
            {
                Logs.Debug("FullUrl", urlTool.GetFullUrl(restUrl));
            }

            Method method = (Method)Enum.Parse(typeof(Method), this._requestType, false);
            RestRequest restRequest = new RestRequest(method);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new MangoPayJsonSerializer();
            restRequest.JsonSerializer.ContentType = Constants.APPLICATION_JSON;

            foreach (KeyValuePair<string, string> h in this.GetHttpHeaders(restUrl))
            {
                restRequest.AddHeader(h.Key, h.Value);

                if (this._debugMode && h.Key != Constants.AUTHORIZATION)
                    Logs.Debug("HTTP Header", h.Key + ": " + h.Value);
            }

            if (pagination != null)
            {
                this._pagination = pagination;
            }

            if (this._debugMode)
                Logs.Debug("RequestType", this._requestType);

            if (this._requestData != null || entity != null)
            {
                if (entity != null)
                {
                    restRequest.AddBody(entity);
                }
                if (this._requestData != null)
                {
                    foreach (KeyValuePair<String, String> entry in this._requestData)
                    {
                        restRequest.AddParameter(entry.Key, entry.Value);
                    }
                }

                if (this._debugMode)
                {
                    Parameter body = restRequest.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();

                    IEnumerable<Parameter> parameters = restRequest.Parameters.Where(p => p.Type == ParameterType.GetOrPost);
                    foreach (Parameter p in parameters)
                    {
                        Logs.Debug(p.Name, p.Value);
                    }

                    if (body != null)
                    {
                        Logs.Debug("CurrentBody", body.Value);
                    }
                    else
                    {
                        Logs.Debug("CurrentBody", "/body is null/");
                    }
                }
            }

            IRestResponse<U> restResponse = client.Execute<U>(restRequest);
            responseObject = restResponse.Data;

            this._responseCode = (int)restResponse.StatusCode;

            if (this._debugMode)
            {
                if (restResponse.StatusCode == HttpStatusCode.OK || restResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    Logs.Debug("Response OK", restResponse.Content);
                }
                else
                {
                    Logs.Debug("Response ERROR", restResponse.Content);
                }
            }

            if (this._responseCode == 200)
            {
                this.ReadResponseHeaders(restResponse);

                if (this._debugMode) Logs.Debug("Response object", responseObject.ToString());
            }

            this.CheckResponseCode(restResponse.Content);

            return responseObject;
        }

        private List<T> DoRequestList<T>(string urlMethod, Pagination pagination, Dictionary<String, String> additionalUrlParams)
        {
            List<T> responseObject = null;

            UrlTool urlTool = new UrlTool(_root);
            string restUrl = urlTool.GetRestUrl(urlMethod, this._authRequired, pagination, null);

            if (this._requestData != null)
            {
                string parameters = "";
                foreach (KeyValuePair<String, String> entry in this._requestData)
                {
                    parameters += String.Format("&{0}={1}", Uri.EscapeDataString(entry.Key), Uri.EscapeDataString(entry.Value));
                }
                if (pagination == null)
                    parameters = parameters.Remove(0, 1).Insert(0, Constants.URI_QUERY_SEPARATOR);

                restUrl += parameters;
            }

            string fullUrl = urlTool.GetFullUrl(restUrl);
            RestClient client = new RestClient(fullUrl);

            client.AddHandler(Constants.APPLICATION_JSON, new MangoPayJsonDeserializer());

            if (this._debugMode)
            {
                Logs.Debug("FullUrl", urlTool.GetFullUrl(restUrl));
            }

            Method method = (Method)Enum.Parse(typeof(Method), this._requestType, false);
            RestRequest restRequest = new RestRequest(method);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new MangoPayJsonSerializer();
            restRequest.JsonSerializer.ContentType = Constants.APPLICATION_JSON;

            foreach (KeyValuePair<string, string> h in this.GetHttpHeaders(restUrl))
            {
                restRequest.AddHeader(h.Key, h.Value);

                if (this._debugMode && h.Key != Constants.AUTHORIZATION)
                    Logs.Debug("HTTP Header", h.Key + ": " + h.Value);
            }

            if (pagination != null)
            {
                this._pagination = pagination;
            }

            if (this._debugMode)
            {
                Logs.Debug("RequestType", this._requestType);
            }

            IRestResponse<List<T>> restResponse = client.Execute<List<T>>(restRequest);
            responseObject = restResponse.Data;

            this._responseCode = (int)restResponse.StatusCode;

            if (this._debugMode)
            {
                if (restResponse.StatusCode == HttpStatusCode.OK || restResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    Logs.Debug("Response OK", restResponse.Content);
                }
                else
                {
                    Logs.Debug("Response ERROR", restResponse.Content);
                }
            }

            if (this._responseCode == 200)
            {
                this.ReadResponseHeaders(restResponse);

                if (this._debugMode) Logs.Debug("Response object", responseObject.ToString());
            }

            this.CheckResponseCode(restResponse.Content);

            return responseObject;
        }

        /// <summary>Reads and parses response headers (pagination etc.)</summary>
        /// <param name="conn">Response object.</param>
        private void ReadResponseHeaders(IRestResponse restResponse)
        {
            foreach (Parameter k in restResponse.Headers)
            {
                String v = (string)k.Value;
                if (this._debugMode) Logs.Debug("Response header", k.Name + ":" + v);

                if (k.Name == null) continue;

                if (k.Name.Equals(Constants.X_NUMBER_OF_PAGES))
                {
                    this._pagination.TotalPages = Int32.Parse(v);
                }
                if (k.Name.Equals(Constants.X_NUMBER_OF_ITEMS))
                {
                    this._pagination.TotalItems = Int32.Parse(v);
                }
                if (k.Name.Equals(Constants.LINK))
                {
                    String linkValue = v;
                    String[] links = linkValue.Split(',');

                    if (links != null && links.Length > 0)
                    {
                        foreach (String l in links)
                        {
                            String link = l;
                            link = link.Replace("<\"", "");
                            link = link.Replace("\">", "");
                            link = link.Replace(" rel=\"", "");
                            link = link.Replace("\"", "");

                            String[] oneLink = link.Split(';');

                            if (oneLink != null && oneLink.Length > 1)
                            {
                                if (oneLink[0] != null && oneLink[1] != null)
                                {
                                    this._pagination.Links = oneLink;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets HTTP header to use in request.</summary>
        /// <param name="restUrl">The REST API URL.</param>
        /// <returns>Collection of headers name-value pairs.</returns>
        private Dictionary<String, String> GetHttpHeaders(String restUrl)
        {
            // return if already created...
            if (this._requestHttpHeaders != null)
                return this._requestHttpHeaders;

            // ...or initialize with default headers
            Dictionary<String, String> httpHeaders = new Dictionary<String, String>();

            // content type
            httpHeaders.Add(Constants.CONTENT_TYPE, Constants.APPLICATION_X_WWW_FORM_URLENCODED);

            // AuthenticationHelper http header
            if (this._authRequired)
            {
                AuthenticationHelper authHlp = new AuthenticationHelper(_root);
                foreach (KeyValuePair<string, string> item in authHlp.GetHttpHeaderKey())
                {
                    httpHeaders.Add(item.Key, item.Value);
                }
            }

            return httpHeaders;
        }
    }
}
