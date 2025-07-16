using System;
using System.Collections.Generic;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities
{
    public class PayInIntentSplitInfo
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The date at which the object was created
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }
        
        /// <summary>
        /// The date at which the object was successfully moved to CREATED
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ExecutionDate { get; set; }
        
        /// <summary>
        /// The split amount
        /// </summary>
        public int Amount { get; set; }
        
        /// <summary>
        /// The status of the split
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Information about the items captured in the transaction.
        /// </summary>
        public List<PayInIntentLineItem> LineItems { get; set; }
    }
}