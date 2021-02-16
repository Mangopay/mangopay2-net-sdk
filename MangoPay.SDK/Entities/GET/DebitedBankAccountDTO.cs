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
        public String OwnerName { get; set; }

        /// <summary>
        /// The account number
        /// </summary>
        public String AccountNumber { get; set; }

        /// <summary>
        /// IBAN
        /// </summary>
        public String IBAN { get; set; }
        
        /// <summary>
        /// BIC
        /// </summary>
        public String BIC { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public String Country { get; set; }

        /// <summary>
        /// The type of bankAccount
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public BankAccountType Type { get; set; }
    }
}
