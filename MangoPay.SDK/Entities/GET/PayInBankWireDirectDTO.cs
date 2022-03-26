using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
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
        public string WireReference { get; set; }

        /// <summary>Card identifier.</summary>
        public string CardId { get; set; }

        /// <summary>Secure mode.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode SecureMode { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public string SecureModeReturnURL { get; set; }
    }
}
