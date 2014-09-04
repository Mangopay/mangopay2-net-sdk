using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    public class PayInBankWireDirectDTO : PayInDTO
    {
        /// <summary>Declared debited funds.</summary>
        public Money DeclaredDebitedFunds { get; set; }

        /// <summary>Declared fees.</summary>
        public Money DeclaredFees { get; set; }

        /// <summary>Bank account details.</summary>
        public BankAccountIbanDTO BankAccount { get; set; }

        /// <summary>Wire reference.</summary>
        public String WireReference { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>Secure mode.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode SecureMode { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL { get; set; }
    }
}
