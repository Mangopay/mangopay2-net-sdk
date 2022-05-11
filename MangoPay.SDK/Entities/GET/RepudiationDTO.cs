using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
	/// <summary>Repudiation entity.</summary>
	public class RepudiationDTO : EntityBase
	{
		/// <summary>The Id of the origin payin author.</summary>
		public string AuthorId { get; set; }

		/// <summary>The funds repudiated from the wallet.</summary>
		public Money DebitedFunds { get; set; }

		/// <summary>The fees taken on the repudiation – will always be 0 at this stage.</summary>
		public Money Fees { get; set; }

		/// <summary>The amount of credited funds – since there are currently no fees, this will be equal to the DebitedFunds.</summary>
		public Money CreditedFunds { get; set; }

		/// <summary>The wallet from where the repudiation was taken.</summary>
		public string DebitedWalletId { get; set; }

		/// <summary>The status of the transfer.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public TransactionStatus? Status { get; set; }

		/// <summary>The transaction result code.</summary>
		public string ResultCode { get; set; }

		/// <summary>The transaction result message.</summary>
		public string ResultMessage { get; set; }

		/// <summary>The execution date of the repudiation.</summary>
		[JsonConverter(typeof(Core.UnixDateTimeConverter))]
		public DateTime? ExecutionDate { get; set; }

		/// <summary>The Id of the dispute to which this repudation corresponds. Note that this value may be null (if it was created before the Dispute objects started to be used – October 2015).</summary>
		public string DisputeId { get; set; }

		/// <summary>The Id of the transaction that was repudiated.</summary>
		public string InitialTransactionId { get; set; }

		/// <summary>The initial transaction type.</summary>
		public string InitialTransactionType { get; set; }
	}
}
