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
		public string RefundReasonMessage;

		/// <summary>Type of refund reason.</summary>
        public string RefundReasonType;
    }
}
