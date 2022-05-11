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
		public string InitialTransactionId { get; set; }

		/// <summary>Most transaction type of the original trasaction.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public InitialTransactionType? InitialTransactionType { get; set; }

        /// <summary>Type of dispute.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DisputeType? DisputeType { get; set; }

		/// <summary>The date by which you must submit docs if they wish to contest the dispute.</summary>
		[JsonConverter(typeof(Core.UnixDateTimeConverter))]
		public DateTime? ContestDeadlineDate { get; set; }

		/// <summary>Dispute's reason.</summary>
		public DisputeReason DisputeReason { get; set; }

		/// <summary>Disputed funds.</summary>
		public Money DisputedFunds { get; set; }

		/// <summary>Contested funds.</summary>
		public Money ContestedFunds { get; set; }

		/// <summary>Status of dispute.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DisputeStatus? Status { get; set; }

		/// <summary>Free text used when reopening the dispute.</summary>
		public string StatusMessage { get; set; }

		/// <summary>Result code.</summary>
		public string ResultCode { get; set; }

		/// <summary>Free text that might be completed when the dispute is closed.</summary>
		public string ResultMessage { get; set; }
		
		/// <summary>The ID of the associated repudiation transaction.</summary>
		public string RepudiationId { get; set; }
    }
}
