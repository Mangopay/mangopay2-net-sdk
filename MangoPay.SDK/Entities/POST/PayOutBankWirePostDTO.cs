﻿using MangoPay.SDK.Core;
using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayOut bank wire POST entity.</summary>
    public class PayOutBankWirePostDTO : EntityPostBase
    {
        public PayOutBankWirePostDTO(string authorId, string debitedWalletId, Money debitedFunds, Money fees, string bankAccountId, string bankWireRef, PayoutModeRequested payoutModeRequested)
        {
            AuthorId = authorId;
            DebitedWalletId = debitedWalletId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            BankAccountId = bankAccountId;
            BankWireRef = bankWireRef;
            PayoutModeRequested = payoutModeRequested;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited wallet identifier.</summary>
        public string DebitedWalletId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Bank account identifier.</summary>
        public string BankAccountId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public string CreditedUserId { get; set; }

        /// <summary>A custom reference you wish to appear on the user’s bank statement (your ClientId is already shown).</summary>
        public string BankWireRef { get; set; }

        /// <value>
        /// The payout mode requested.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayoutModeRequested PayoutModeRequested { get; set; }
    }
}
