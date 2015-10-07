using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Dispute entity.</summary>
	public class DisputeDTO : EntityBase
    {
		/// <summary>Identifier of the transaction that was disputed.</summary>
		public String InitialTransactionId { get; set; }

		/// <summary>Most transaction type of the original trasaction.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public InitialTransactionType? InitialTransactionType { get; set; }

        /// <summary>Date.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DisputeType? DisputeType { get; set; }

		/// <summary>The date by which you must submit docs if they wish to contest the dispute.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? ContestDeadlineDate { get; set; }

		/// <summary>Dispute's reason.</summary>
		public DisputeReason DisputeReason { get; set; }

		/// <summary>Disputed funds.</summary>
		public Money DisputedFunds { get; set; }

		/// <summary>Contested funds.</summary>
		public Money ContestedFunds { get; set; }

		/// <summary>Contested funds.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DisputeStatus? Status { get; set; }

		/// <summary>Free text used when reopening the dispute.</summary>
		public String StatusMessage { get; set; }

		/// <summary>Result code.</summary>
		public String ResultCode { get; set; }

		/// <summary>Free text that might be completed when the dispute is closed.</summary>
		public String ResultMessage { get; set; }
    }
}
