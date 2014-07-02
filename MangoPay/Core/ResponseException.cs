using MangoPay.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Response exception class.</summary>
    public class ResponseException : ApplicationException
    {
        /// <summary>Instantiates new ResponseException object.</summary>
        public ResponseException() { }

        /// <summary>Instantiates new ResponseException object.</summary>
        /// <param name="message">JSON data that came as a response from API.</param>
        public ResponseException(String message) : base(message) 
        {
            try
            {
                this.ResponseError = JsonConvert.DeserializeObject<ResponseError>(message);
            }
            catch (JsonException jex)
            {
                // Intentionally suppress optional deserialize exception. //
            }
        }

        /// <summary>Deserialized response error data.</summary>
        public ResponseError ResponseError = new ResponseError();
    }
}
