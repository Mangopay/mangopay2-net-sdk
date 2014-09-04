using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>GB bank account POST entity.</summary>
    public class BankAccountGbPostDTO : BankAccountPostDTO
    {
        public BankAccountGbPostDTO(String ownerName, String ownerAddress, String accountNumber)
        {
            Type = BankAccountType.GB;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            AccountNumber = accountNumber;
        }

        /// <summary>Account number.</summary>
        public String AccountNumber { get; set; }

        /// <summary>Sort code.</summary>
        public String SortCode { get; set; }
    }
}
