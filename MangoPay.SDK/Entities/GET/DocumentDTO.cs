﻿using System;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
	public class DocumentDTO : EntityBase
	{
		/// <summary>Refused reason type.</summary>
		public string RefusedReasonType { get; set; }

		/// <summary>Refused reason message.</summary>
		public string RefusedReasonMessage { get; set; }

	    /// <summary>Date when the document was processed.</summary>
	    [JsonConverter(typeof(UnixDateTimeConverter))]
	    public DateTime? ProcessedDate { get; set; }
    }
}
