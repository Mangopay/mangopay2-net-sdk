using MangoPay.SDK.Core.Enumerations;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
	public class DebitedBankAccountDTO
	{
        /// <summary>
        /// Owner name.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// The account number
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// IBAN
        /// </summary>
        public string IBAN { get; set; }
        
        /// <summary>
        /// BIC
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The type of bankAccount
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public BankAccountType Type { get; set; }
    }
}
