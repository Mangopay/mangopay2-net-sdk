using MangoPay.SDK.Core;
using Newtonsoft.Json;
using System;

namespace MangoPay.SDK.Entities.GET
{
	/// <summary>PayIn mandate direct entity.</summary>
	public class PayInMandateDirectDTO : PayInDTO
    {
        /// <summary>Mandate identifier.</summary>
        public String MandateId { get; set; }

	/// <summary>An optional value to be specified on the user's bank statement.</summary>
        public String StatementDescriptor { get; set; }
		
		/// <summary>Charge date.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? ChargeDate { get; set; }
	}
}
