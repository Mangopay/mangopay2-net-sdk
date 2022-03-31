using System;
using System.Collections.Generic;
using System.Text;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>
    /// 
    /// </summary>
    public class PayOutEligibilityPostDTO : EntityPostBase
    {
        public string AuthorId { get; set; }

        public Money DebitedFunds { get; set; }

        public Money Fees { get; set; }

        public string BankAccountId { get; set; }

        public string DebitedWalletId { get; set; }

        public string BankWireRef { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PayoutModeRequested PayoutModeRequested { get; set; }
    }
}
