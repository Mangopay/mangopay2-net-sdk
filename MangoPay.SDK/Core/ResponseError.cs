using System.Collections.Generic;
using Newtonsoft.Json;

namespace MangoPay.SDK.Core
{
    /// <summary>Response error class, used as part of ResponseException object. 
    /// You don't need to instantiate it by yourself - SDK will take care of this for you.</summary>
    public sealed class ResponseError
    {
        internal ResponseError () { }

        /// <summary>General error text message.</summary>
        public string Message;

        /// <summary>Type of error.</summary>
        public string Type;
        
        /// <summary>Error identifier.</summary>
        public string Id;

        /// <summary>Date (UNIX timestamp).</summary>
        public long Date;

        /// <summary>Collection of field name / error decription pairs.</summary>
        public Dictionary<string, string> errors;
        
        /// <summary>Additional data related to the error.</summary>
        public Dictionary<string, string> Data;

        /// <summary>Deserializes JSON ResponseError instance.</summary>
        /// <param name="serializedResponseError">JSON-serialized ResponseError instance.</param>
        /// <returns>Returns new instance of ResponseError class or null if deserialization failed.</returns>
        public static ResponseError FromJSON(string serializedResponseError)
        {
            if (string.IsNullOrEmpty(serializedResponseError))
            {
                return null;
            }
            
            try
            {
                return JsonConvert.DeserializeObject<ResponseError>(serializedResponseError);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
