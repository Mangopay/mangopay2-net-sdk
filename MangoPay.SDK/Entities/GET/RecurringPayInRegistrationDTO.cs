using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class RecurringPayInRegistrationDTO : EntityBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RecurringPaymentStatus Status { get; set; }

        public string RecurringType { get; set; }

        public Money TotalAmount { get; set; }

        public int? CycleNumber { get; set; }

        public string AuthorId { get; set; }

        public string CardId { get; set; }

        public string CreditedUserId { get; set; }

        public string CreditedWalletId { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }

        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? EndDate { get; set; }

        public string Frequency { get; set; }

        public bool FixedNextAmount { get; set; }

        public bool FractionedPayment { get; set; }

        public int FreeCycles { get; set; }

        public Money FirstTransactionDebitedFunds { get; set; }

        public Money FirstTransactionFees { get; set; }

        public Money NextTransactionDebitedFunds { get; set; }

        public Money NextTransactionFees { get; set; }
    }
}