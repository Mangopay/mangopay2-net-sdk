using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>CA bank account POST entity.</summary>
    public class BankAccountCaPostDTO : BankAccountPostDTO
    {
		public BankAccountCaPostDTO(string ownerName, Address ownerAddress, string bankName, string institutionNumber, string branchCode, string accountNumber)
        {
            Type = BankAccountType.CA;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            BankName = bankName;
            InstitutionNumber = institutionNumber;
            BranchCode = branchCode;
            AccountNumber = accountNumber;
        }

        /// <summary>Bank name.</summary>
        public string BankName { get; set; }

        /// <summary>Institution number.</summary>
        public string InstitutionNumber { get; set; }

        /// <summary>Branch code.</summary>
        public string BranchCode { get; set; }

        /// <summary>Account number.</summary>
        public string AccountNumber { get; set; }
    }
}
