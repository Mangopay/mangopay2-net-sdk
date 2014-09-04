using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>IBAN bank account POST entity.</summary>
    public class BankAccountIbanPostDTO : BankAccountPostDTO
    {
        public BankAccountIbanPostDTO(String ownerName, String ownerAddress, String iban)
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
