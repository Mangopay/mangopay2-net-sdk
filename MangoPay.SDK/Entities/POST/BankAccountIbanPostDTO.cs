using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>IBAN bank account POST entity.</summary>
    public class BankAccountIbanPostDTO : BankAccountPostDTO
    {
		public BankAccountIbanPostDTO(String ownerName, Address ownerAddress, String iban)
        {
            Type = BankAccountType.IBAN;
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            IBAN = iban;
        }

        /// <summary>IBAN number.</summary>
        public String IBAN { get; set; }

        /// <summary>BIC.</summary>
        public String BIC { get; set; }
    }
}
