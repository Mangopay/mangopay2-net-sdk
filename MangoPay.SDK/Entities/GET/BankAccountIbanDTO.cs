using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Bank Account IBAN entity.</summary>
    public class BankAccountIbanDTO : BankAccountDTO
    {
        /// <summary>IBAN number.</summary>
        public String IBAN { get; set; }

        /// <summary>BIC.</summary>
        public String BIC { get; set; }
    }
}
