using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>IBAN bank account POST entity.</summary>
    public class BankAccountIbanPostDTO : BankAccountPostDTO
    {
		public BankAccountIbanPostDTO(string ownerName, Address ownerAddress, string iban)
        {
            Type = BankAccountType.IBAN;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            IBAN = iban;
        }

        /// <summary>IBAN number.</summary>
        public string IBAN { get; set; }

        /// <summary>BIC.</summary>
        public string BIC { get; set; }
    }
}
