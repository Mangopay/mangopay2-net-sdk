using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    public class PayInIntentCancelPostDTO : EntityPostBase
    {
        /// <summary>
        /// An amount of money in the smallest sub-division of the currency
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// The currency of the funds
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso? Currency { get; set; }

        /// <summary>
        /// Information about the fees
        /// </summary>
        public int? PlatformFeesAmount { get; set; }

        /// <summary>
        /// Information about the external processed transaction
        /// </summary>
        public PayInIntentExternalData ExternalData { get; set; }

        /// <summary>
        /// Information about the items purchased in the transaction.
        /// The total of all LineItems UnitAmount, TaxAmount, DiscountAmount, TotalLineItemAmount must equal the Amount.
        /// The total of all LineItems FeesAmount must equal the PlatformFees amount.
        /// </summary>
        public List<PayInIntentLineItem> LineItems { get; set; }
    }
}