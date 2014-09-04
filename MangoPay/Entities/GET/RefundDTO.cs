using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Refund entity.</summary>
    public class RefundDTO : TransactionDTO
    {
        /// <summary>Initial transaction identifier.</summary>
        public String InitialTransactionId { get; set; }

        /// <summary>Initial transaction type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public InitialTransactionType InitialTransactionType { get; set; }
    }
}
