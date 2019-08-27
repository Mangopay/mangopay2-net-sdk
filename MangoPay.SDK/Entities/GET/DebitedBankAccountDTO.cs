using System;

namespace MangoPay.SDK.Entities.GET
{
	public class DebitedBankAccountDTO
	{
        /// <summary>The name of the owner of the bank account</summary>
		public string OwnerName { get; set; }

        /// <summary>
        /// The type of bank account
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The IBAN of the bank account
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// The BIC of the bank account
        /// </summary>
        public string BIC { get; set; }
	}
}
