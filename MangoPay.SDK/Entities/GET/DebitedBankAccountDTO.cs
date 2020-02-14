using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.GET
{
	public class DebitedBankAccountDTO
	{
        public DebitedBankAccountDTO()
        {

        }

        public DebitedBankAccountDTO(String OwnerName, String AccountNumber, String IBAN, String BIC, String Country, BankAccountType Type)
        {
            this.OwnerName = OwnerName;
            this.AccountNumber = AccountNumber;
            this.IBAN = IBAN;
            this.BIC = BIC;
            this.Country = Country;
            this.Type = Type;
        }

		/// <summary>
        /// Owner name.
        /// </summary>
		public String OwnerName { get; set; }

        /// <summary>
        /// The account number
        /// </summary>
        public String AccountNumber { get; set; }

        /// <summary>
        /// IBAN
        /// </summary>
        public String IBAN { get; set; }
        
        /// <summary>
        /// BIC
        /// </summary>
        public String BIC { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public String Country { get; set; }

        /// <summary>
        /// The type of bankAccount
        /// </summary>
        public BankAccountType Type { get; set; }
    }
}
