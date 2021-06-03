using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayInRegistrationPostDTO : EntityPostBase
    {
        #region Required

        public string AuthorId { get; set; }

        public string CardId { get; set; }

        public string CreditedWalletId { get; set; }

        public Money FirstTransactionDebitedFunds { get; set; }

        public Money FirstTransactionFees { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }

        #endregion

        #region Optional

        public string CreditedUserId { get; set; }

        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? EndDate { get; set; }

        public List<String> Frequency { get; set; }

        public bool Migration { get; set; }

        public Money NextTransactionDebitedFunds { get; set; }

        public Money NextTransactionFees { get; set; }

        #endregion
    }
}
