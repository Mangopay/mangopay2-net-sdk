using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>OTHER bank account POST entity.</summary>
    public class BankAccountOtherPostDTO : BankAccountPostDTO
    {
		public BankAccountOtherPostDTO(String ownerName, Address ownerAddress, String accountNumber, String bic)
        {
            Type = BankAccountType.OTHER;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            AccountNumber = accountNumber;
            BIC = bic;
        }

        /// <summary>The Country associate to the BankAccount. 
        /// ISO 3166-1 alpha-2 format is expected.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? Country { get; set; }

        /// <summary>Valid BIC format.</summary>
        public String BIC { get; set; }

        /// <summary>Account number.</summary>
        public String AccountNumber { get; set; }
    }
}
