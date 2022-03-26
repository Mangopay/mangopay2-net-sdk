using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Class represents US type of bank account.</summary>
    public class BankAccountUsObsoleteDTO : BankAccountObsoleteDTO
    {
        /// <summary>Account number.</summary>
        public string AccountNumber { get; set; }

        /// <summary>ABA.</summary>
        public string ABA { get; set; }

		/// <summary>Deposit account type.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DepositAccountType DepositAccountType { get; set; }
    }
}
