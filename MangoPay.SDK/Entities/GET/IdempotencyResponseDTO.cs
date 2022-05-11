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
		public string StatusCode { get; set; }

		public string ContentLength { get; set; }

		public string ContentType { get; set; }

        public string Date { get; set; }

		public string RequestURL { get; set; }

		public object Resource { get; set; }
	}
}
