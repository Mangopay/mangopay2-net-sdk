using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayInRegistrationPostDTO : EntityPostBase
    {
        #region Required

        /// <summary>
        /// A user's ID
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// The ID of a card
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// The ID of the wallet where money will be credited
        /// </summary>
        public string CreditedWalletId { get; set; }

        /// <summary>
        /// Amount of the first payment.This amount may be different from the NextTransactionDebitedFunds.
        /// </summary>
        public Money FirstTransactionDebitedFunds { get; set; }

        /// <summary>
        /// Amount of the first payment fees. This amount may be different from the NextTransactionFees.
        /// </summary>
        public Money FirstTransactionFees { get; set; }

        /// <summary>
        /// Contains every useful information related to the user billing
        /// </summary>
        public Billing Billing { get; set; }

        /// <summary>
        /// Contains every useful information related to the user shipping
        /// </summary>
        public Shipping Shipping { get; set; }

        #endregion

        #region Optional

        /// <summary>
        /// The user ID who is credited (defaults to the owner of the wallet)
        /// </summary>
        public string CreditedUserId { get; set; }

        /// <summary>
        /// Date on which the recurring payments will end
        /// </summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Frequency at which the recurring payments will be made
        /// </summary>
        public string Frequency { get; set; }

        /// <summary>
        /// Indicates whether the payment amount is likely to change during the payment period
        /// </summary>
        public bool FixedNextAmount { get; set; }

        /// <summary>
        /// Indicates whether this recurring payment is a payment in installments in N times
        /// </summary>
        public bool FractionedPayment { get; set; }

        /// <summary>
        /// Indicates whether the object is being used to attempt registration of an existing recurring payment
        /// </summary>
        public bool Migration { get; set; }

        /// <summary>
        /// Amount of subsequent payments. If this field is empty and either FixedNextAmount or FractionedPayment are TRUE, we will take the amount of the FirstTransactionDebitedFunds as the subsequent payment amount.
        /// </summary>
        public Money NextTransactionDebitedFunds { get; set; }

        /// <summary>
        /// Amount of subsequent fees. If this field is empty and either FixedNextAmount or FractionedPayment are TRUE, we will take the amount of the FirstTransactionFees as the subsequent fees.
        /// </summary>
        public Money NextTransactionFees { get; set; }

        public int FreeCycles { get; set; }
        
        /// <summary>Type of payment</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RecurringPayInRegistrationPaymentType? PaymentType { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }

        #endregion
    }
}
