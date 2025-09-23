﻿using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn card direct POST entity.</summary>
    public class PayInCardDirectPostDTO : EntityPostBase
    {
        public PayInCardDirectPostDTO(string authorId, string creditedUserId, Money debitedFunds, Money fees, 
            string creditedWalletId, string secureModeReturnURL, string cardId, string statementDescriptor = null,
            Billing billing = null, BrowserInfo bInfo = null, string preferredCardNetwork = null, string paymentCategory = null)
        {
            AuthorId = authorId;
            CreditedUserId = creditedUserId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            SecureModeReturnURL = secureModeReturnURL;
            CardId = cardId;
            StatementDescriptor = statementDescriptor;
            Billing = Billing;
            BrowserInfo = bInfo;
            PreferredCardNetwork = preferredCardNetwork;
            PaymentCategory = paymentCategory;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public string CreditedUserId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public string SecureModeReturnURL { get; set; }

        /// <summary>Card identifier.</summary>
        public string CardId { get; set; }

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode? SecureMode { get; set; }

        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType? CardType { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        public Billing Billing { get; set; }

        public SecurityInfo SecurityInfo { get; set; }
        
        public BrowserInfo BrowserInfo { get; set; }

        public Shipping Shipping { get; set; }

        /// <summary>
        /// → Is not Mandatory for 3DSv1 (flag “Use 3DSV2 Scenario” OFF)
        /// → Is mandatory when the flag “Use 3DSV2 Scenario” is active for (FORCE/DEFAULT/FRICTIONLESS both 3)
        /// </summary>
        public string IpAddress { get; set; }

        public string Requested3DSVersion { get; set; }
        
        ///  <summary> Allowed values: VISA, MASTERCARD, CB, MAESTRO
        /// 
        /// The card network to use, as chosen by the cardholder, in case of co-branded card products. </summary>
        public string PreferredCardNetwork { get; set; } 
        
        /// <summary>
        /// The channel through which the user provided their card details, used to indicate mail-order and telephone-order (MOTO) payments:
        /// ECommerce – Payment received online.
        /// TelephoneOrder – Payment received via mail order or telephone order (MOTO).
        /// </summary>
        public string PaymentCategory { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}
