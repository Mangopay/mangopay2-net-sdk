using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities
{
    /// <summary>Class represents refund's reason.</summary>
    public class RefundReason
    {
		/// <summary>Message.</summary>
		public String RefundReasonMessage;

		/// <summary>Type of refund reason.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public RefundReasonType RefundReasonType;
    }
}
