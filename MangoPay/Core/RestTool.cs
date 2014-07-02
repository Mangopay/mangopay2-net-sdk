using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Reflection;
using MangoPay.Entities;
using Newtonsoft.Json.Linq;
using RestSharp;

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

            foreach (var item in httpHeader)
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
                Dictionary<int, String> responseCodes = new Dictionary<int, String> 
                {
                    { 206, "PartialContent" },
                    { 400, "Bad request" },
                    { 401, "Unauthorized" },
                    { 403, "Prohibition to use the method" },
                    { 404, "Not found" },
                    { 405, "Method not allowed" },
                    { 413, "Request entity too large" },
                    { 422, "Unprocessable entity" },
                    { 500, "Internal server error" },
                    { 501, "Not implemented" }
                };

                String errorMessage = "";
                if (responseCodes.ContainsKey(this._responseCode))
                {
                    errorMessage = responseCodes[this._responseCode];
                }
                else
                {
                    errorMessage = "Unknown response error";
                }

                if (textResponse != null)
                {
                    errorMessage += ". " + textResponse;
                }

                ResponseError error = JsonConvert.DeserializeObject<ResponseError>(textResponse);
                ResponseException rex = new ResponseException(errorMessage);
                rex.ResponseError = error;

                throw rex;
            }
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// <code>Dto</code> instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entity">Instance of Dto class that is going to be sent in case of PUTting or POSTing.</param>
        /// <returns>The Dto instance returned from API.</returns>
        public T Request<T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination, T entity)
            where T : Dto, new()
        {
            this._requestType = requestType;
            this._requestData = requestData;

            T responseResult = this.DoRequest<T>(urlMethod, pagination, entity);

            if (pagination != null)
            {
                pagination = this._pagination;
            }

            return responseResult;
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// <code>Dto</code> instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <returns>The Dto instance returned from API.</returns>
        public T Request<T>(String urlMethod, String requestType)
            where T : Dto, new()
        {
            return Request<T>(urlMethod, requestType, null, null, null);
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// <code>Dto</code> instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <returns>The Dto instance returned from API.</returns>
        public T Request<T>(String urlMethod, String requestType, Dictionary<String, String> requestData)
            where T : Dto, new()
        {
            return Request<T>(urlMethod, requestType, requestData, null, null);
        }

        /// <summary>Makes a call to the MangoPay API.
        /// This generic method handles calls targeting single 
        /// <code>Dto</code> instances. In order to process collections of objects, 
        /// use <code>RequestList</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term, one of the GET, PUT or POST.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>The Dto instance returned from API.</returns>
        public T Request<T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination)
            where T : Dto, new()
        {
            return Request<T>(urlMethod, requestType, requestData, pagination, null);
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// <code>Dto</code> instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="additionalUrlParams"></param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination, Dictionary<String, String> additionalUrlParams)
            where T : Dto, new()
        {
            this._requestType = requestType;
            this._requestData = requestData;

            List<T> responseResult = this.DoRequestList<T>(urlMethod, pagination, additionalUrlParams);

            if (pagination != null)
            {
                pagination = this._pagination;
            }

            return responseResult;
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// <code>Dto</code> instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType)
            where T : Dto, new()
        {
            return RequestList<T>(urlMethod, requestType, null, null, null);
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// <code>Dto</code> instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType, Dictionary<String, String> requestData)
            where T : Dto, new()
        {
            return RequestList<T>(urlMethod, requestType, requestData, null, null);
        }

        /// <summary>Makes a call to the MangoPay API. 
        /// This generic method handles calls targeting collections of 
        /// <code>Dto</code> instances. In order to process single objects, 
        /// use <code>Request</code> method instead.
        /// </summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="urlMethod">Relevant method key.</param>
        /// <param name="requestType">HTTP request term. For lists should be always GET.</param>
        /// <param name="requestData">Collection of key-value pairs of request parameters.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        public List<T> RequestList<T>(String urlMethod, String requestType, Dictionary<String, String> requestData, Pagination pagination)
            where T : Dto, new()
        {
            return RequestList<T>(urlMethod, requestType, requestData, pagination, null);
        }

        private T DoRequest<T>(String urlMethod, Pagination pagination)
            where T : Dto, new()
        {
            return DoRequest<T>(urlMethod, pagination, null);
        }

        private T DoRequest<T>(String urlMethod, Pagination pagination, T entity)
            where T : Dto, new()
        {
            T response = null;

            UrlTool urlTool = new UrlTool(_root);
            String restUrl = urlTool.GetRestUrl(urlMethod, this._authRequired, pagination, null);

            string fullUrl = urlTool.GetFullUrl(restUrl);
            var client = new RestClient(fullUrl);

            client.AddHandler("application/json", new MangoPayJsonDeserializer(_debugMode));

            if (this._debugMode)
            {
                Logs.Debug("FullUrl", urlTool.GetFullUrl(restUrl));
            }

            Method method = (Method)Enum.Parse(typeof(Method), this._requestType, false);
            var request = new RestRequest(method);
            request.RequestFormat = DataFormat.Json;


            foreach (var h in this.GetHttpHeaders(restUrl))
            {
                request.AddHeader(h.Key, h.Value);

                if (this._debugMode)
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
                    Dictionary<String, Object> requestData = BuildRequestData<T>(entity);
                    request.AddBody(requestData);
                }
                if (this._requestData != null)
                {
                    foreach (KeyValuePair<String, String> entry in this._requestData)
                    {
                        request.AddParameter(entry.Key, entry.Value);
                    }
                }

                if (this._debugMode)
                {
                    var body = request.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();

                    var ppp = request.Parameters.Where(p => p.Type == ParameterType.GetOrPost);
                    foreach (var p in ppp)
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

            IRestResponse<T> resp = client.Execute<T>(request);
            String responseString = resp.Content;

            response = resp.Data;

            this._responseCode = (int)resp.StatusCode;

            if (this._debugMode)
            {
                if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.NoContent)
                {
                    Logs.Debug("Response OK", responseString);
                }
                else
                {
                    Logs.Debug("Response ERROR", responseString);
                }
            }

            if (this._responseCode == 200)
            {
                this.ReadResponseHeaders(resp);

                if (this._debugMode) Logs.Debug("Response object", response.ToString());
            }

            this.CheckResponseCode(responseString);

            return response;
        }

        private List<T> DoRequestList<T>(string urlMethod, Pagination pagination, Dictionary<String, String> additionalUrlParams)
            where T : Dto, new()
        {
            List<T> response = null;

            UrlTool urlTool = new UrlTool(_root);
            String restUrl = urlTool.GetRestUrl(urlMethod, this._authRequired, pagination, null);

            string fullUrl = urlTool.GetFullUrl(restUrl);
            var client = new RestClient(fullUrl);

            client.AddHandler("application/json", new MangoPayJsonDeserializer(_debugMode));

            if (this._debugMode)
            {
                Logs.Debug("FullUrl", urlTool.GetFullUrl(restUrl));
            }

            Method method = (Method)Enum.Parse(typeof(Method), this._requestType, false);
            var request = new RestRequest(method);
            request.RequestFormat = DataFormat.Json;


            foreach (var h in this.GetHttpHeaders(restUrl))
            {
                request.AddHeader(h.Key, h.Value);

                if (this._debugMode)
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

            IRestResponse<List<T>> resp = client.Execute<List<T>>(request);
            String responseString = resp.Content;

            response = resp.Data;

            this._responseCode = (int)resp.StatusCode;

            if (this._debugMode)
            {
                if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.NoContent)
                {
                    Logs.Debug("Response OK", responseString);
                }
                else
                {
                    Logs.Debug("Response ERROR", responseString);
                }
            }

            if (this._responseCode == 200)
            {
                this.ReadResponseHeaders(resp);

                if (this._debugMode) Logs.Debug("Response object", response.ToString());
            }

            this.CheckResponseCode(responseString);

            return response;
        }

        /// <summary>Reads and parses response headers (pagination etc.)</summary>
        /// <param name="conn">Response object.</param>
        private void ReadResponseHeaders(IRestResponse restResponse)
        {
            foreach (var k in restResponse.Headers)
            {
                String v = (string)k.Value;
                if (this._debugMode) Logs.Debug("Response header", k.Name + ":" + v);

                if (k.Name == null) continue;

                if (k.Name.Equals("X-Number-Of-Pages"))
                {
                    this._pagination.TotalPages = Int32.Parse(v);
                }
                if (k.Name.Equals("X-Number-Of-Items"))
                {
                    this._pagination.TotalItems = Int32.Parse(v);
                }
                if (k.Name.Equals("Link"))
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

        private bool IFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }

        private Dictionary<String, Object> BuildRequestData<T>(T entity)
        {
            Dictionary<String, Object> result = new Dictionary<String, Object>();

            List<String> readOnlyProperties = entity is Dto ? (entity as Dto).GetReadOnlyProperties() : new List<String>();

            String fieldName = "";

            TypeFilter myFilter = new TypeFilter(IFilter);
            String[] myInterfaceList = new String[1] { "System.Collections.IEnumerable" };
            foreach (FieldInfo f in typeof(T).GetFields())
            {
                bool isList = false;
                if (f.GetType().FindInterfaces(myFilter, myInterfaceList).Count() > 0)
                    isList = true;

                fieldName = f.Name;

                bool isReadOnly = false;
                foreach (String s in readOnlyProperties)
                {
                    if (s.Equals(fieldName))
                    {
                        isReadOnly = true;
                        break;
                    }
                }
                if (isReadOnly) continue;


                if (CanReadSubRequestData<T>(fieldName))
                {
                    Dictionary<String, Object> subRequestData = new Dictionary<String, Object>();

                    MethodInfo m = this.GetType().GetMethod("BuildRequestData", BindingFlags.NonPublic | BindingFlags.Instance)
                        .MakeGenericMethod(f.GetValue(entity).GetType());
                    subRequestData = (Dictionary<String, Object>)m.Invoke(this, new object[] { f.GetValue(entity) });

                    foreach (KeyValuePair<String, Object> e in subRequestData)
                    {
                        if (e.Value != null)
                        {
                            if (!result.Keys.Contains(e.Key))
                                result.Add(e.Key, e.Value);
                            else
                                result[e.Key] = e.Value;
                        }
                    }
                }
                else
                {
                    try
                    {
                        if (!isList)
                        {
                            if (f.GetValue(entity) != null)
                                result.Add(fieldName, f.GetValue(entity));
                        }
                        else
                        {
                            if (f.GetValue(entity) != null)
                                result.Add(fieldName, ((List<T>)f.GetValue(entity)).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

            }

            return result;
        }

        /// <summary>Checks whether can read subrequest data.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="fieldName">Field name.</param>
        /// <returns>Returns true if can read subrequest data, otherwise false.</returns>
        private bool CanReadSubRequestData<T>(String fieldName)
        {
            if ((typeof(T).Name == typeof(PayIn).Name) && (fieldName.Equals("PaymentDetails") || fieldName.Equals("ExecutionDetails")))
            {
                return true;
            }

            if ((typeof(T).Name == typeof(PayOut).Name) && fieldName.Equals("MeanOfPaymentDetails"))
            {
                return true;
            }

            if ((typeof(T).Name == typeof(BankAccount).Name) && fieldName.Equals("Details"))
            {
                return true;
            }

            return false;
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
            httpHeaders.Add("Content-Type", "application/x-www-form-urlencoded");

            // AuthenticationHelper http header
            if (this._authRequired)
            {
                AuthenticationHelper authHlp = new AuthenticationHelper(_root);
                foreach (var item in authHlp.GetHttpHeaderKey())
                {
                    httpHeaders.Add(item.Key, item.Value);
                }
            }

            return httpHeaders;
        }
    }
}
