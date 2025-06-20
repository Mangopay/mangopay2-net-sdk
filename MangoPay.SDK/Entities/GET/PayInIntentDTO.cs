using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInIntentDTO : EntityBase
    {
        /// <summary>
        /// An amount of money in the smallest sub-division of the currency
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The remaining amount on the intent available for transfers
        /// </summary>
        public int AvailableAmountToSplit { get; set; }

        /// <summary>
        /// The currency of the funds
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }

        /// <summary>
        /// Information about the fees
        /// </summary>
        public int PlatformFeesAmount { get; set; }

        /// <summary>
        /// The status of the intent
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The possible next statuses for the intent
        /// </summary>
        public string NextActions { get; set; }

        /// <summary>
        /// Information about the external processed transaction
        /// </summary>
        public PayInIntentExternalData ExternalData { get; set; }

        /// <summary>
        /// Information about the buyer
        /// </summary>
        public PayInIntentBuyer Buyer { get; set; }

        /// <summary>
        /// Information about the items purchased in the transaction.
        /// The total of all LineItems UnitAmount, TaxAmount, DiscountAmount, TotalLineItemAmount must equal the Amount.
        /// The total of all LineItems FeesAmount must equal the PlatformFees amount.
        /// </summary>
        public List<PayInIntentLineItem> LineItems { get; set; }

        /// <summary>
        /// Information about the amounts captured against the intent
        /// </summary>
        public List<PayInIntentCapture> Captures { get; set; }

        /// <summary>
        /// Information about the amounts refunded against the intent
        /// </summary>
        public List<PayInIntentRefund> Refunds { get; set; }

        /// <summary>
        /// Information about the amounts disputed against the intent
        /// </summary>
        public List<PayInIntentDispute> Disputes { get; set; }

        /// <summary>
        /// Information about the amounts split against the intent
        /// </summary>
        public List<PayInIntentSplit> Splits { get; set; }

        /// <summary>
        /// The unique identifier of the settlement linked to this intent in Mangopay ecosystem
        /// </summary>
        public string SettlementId { get; set; }
    }
}