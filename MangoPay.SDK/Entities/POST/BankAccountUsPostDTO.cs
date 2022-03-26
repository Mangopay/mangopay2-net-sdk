using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>US bank account POST entity.</summary>
    public class BankAccountUsPostDTO : BankAccountPostDTO
    {
		public BankAccountUsPostDTO(string ownerName, Address ownerAddress, string accountNumber, string aba)
        {
            Type = BankAccountType.US;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            AccountNumber = accountNumber;
            ABA = aba;
			DepositAccountType = DepositAccountType.CHECKING;
        }

        /// <summary>Account number.</summary>
        public string AccountNumber { get; set; }

        /// <summary>ABA.</summary>
        public string ABA { get; set; }

		/// <summary>Deposit account type.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DepositAccountType DepositAccountType { get; set; }
    }
}
