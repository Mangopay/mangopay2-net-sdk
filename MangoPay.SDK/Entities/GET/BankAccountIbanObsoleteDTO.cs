using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Bank Account IBAN entity.</summary>
	public class BankAccountIbanObsoleteDTO : BankAccountObsoleteDTO
    {
        /// <summary>IBAN number.</summary>
        public string IBAN { get; set; }

        /// <summary>BIC.</summary>
        public string BIC { get; set; }
    }
}
