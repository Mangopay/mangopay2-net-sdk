using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Bank Account IBAN entity.</summary>
    public class BankAccountIbanDTO : BankAccountDTO
    {
        /// <summary>IBAN number.</summary>
        public string IBAN { get; set; }

        /// <summary>BIC.</summary>
        public string BIC { get; set; }
    }
}
