namespace MangoPay.SDK.Entities.GET
{
	public class PayInBankWireExternalInstructionDTO : PayInDTO
    {
        /// <summary>The ID of bank alias.</summary>
        public string BankingAliasId { get; set; }

		/// <summary>Wire reference.</summary>
		public string WireReference { get; set; }

        /// <summary>Information about account that was debited.</summary>
        public DebitedBankAccountDTO DebitedBankAccount { get; set; }
    }
}
