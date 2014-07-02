using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Response error class, used as part of ResponseException object. 
    /// You don't need to instantiate it by yourself - SDK will take care of this for you.</summary>
    public sealed class ResponseError
    {
        internal ResponseError () { }

        /// <summary>General error text message.</summary>
        public String Message;

        /// <summary>Type of error.</summary>
        public String Type;
        
        /// <summary>Error identifier.</summary>
        public String Id;

        /// <summary>Date (UNIX timestamp).</summary>
        public long Date;

        /// <summary>Collection of field name / error decription pairs.</summary>
        public Dictionary<String, String> errors;
    }
}
