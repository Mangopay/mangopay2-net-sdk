using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
	/// <summary>IdempotencyResponse entity.</summary>
	public class IdempotencyResponseDTO : EntityBase
    {
		public String StatusCode { get; set; }

		public String ContentLength { get; set; }

		public String ContentType { get; set; }

        public String Date { get; set; }

		public String Resource { get; set; }
    }
}
