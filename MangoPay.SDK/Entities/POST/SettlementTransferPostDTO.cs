using System;

namespace MangoPay.SDK.Entities.POST
{
	/// <summary>Settlement transfer POST entity.</summary>
	public class SettlementTransferPostDTO : EntityPostBase
	{
		public SettlementTransferPostDTO(string authorId, Money debitedFunds, Money fees)
		{
			AuthorId = authorId;
			DebitedFunds = debitedFunds;
			Fees = fees;
		}

		/// <summary>The Id of the author of the original PayIn that was repudiated.</summary>
		public string AuthorId { get; set; }

		/// <summary>The funds debited from the debited wallet.</summary>
		public Money DebitedFunds { get; set; }

		/// <summary>The amount you wish to charge for this settlement. This can be equal to 0, or more than 0 to charge for the settlement or less than 0 to refund some of the original Fees that were taken on the original settlement (eg DebitedFunds of 1000 and Fees of -200 will transfer 800 from the original wallet to the credit wallet, and transfer 200 from your Fees wallet to your Credit wallet.</summary>
		public Money Fees { get; set; }
	}
}
