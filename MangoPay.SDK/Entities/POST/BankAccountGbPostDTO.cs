using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>GB bank account POST entity.</summary>
    public class BankAccountGbPostDTO : BankAccountPostDTO
    {
		public BankAccountGbPostDTO(string ownerName, Address ownerAddress, string accountNumber)
        {
            Type = BankAccountType.GB;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            AccountNumber = accountNumber;
        }

        /// <summary>Account number.</summary>
        public string AccountNumber { get; set; }

        /// <summary>Sort code.</summary>
        public string SortCode { get; set; }
    }
}
