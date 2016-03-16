using System;

namespace MangoPay.SDK.Entities.GET
{
	/// <summary>PayIn mandate direct entity.</summary>
	public class PayInMandateDirectDTO : PayInDTO
    {
        /// <summary>Mandate identifier.</summary>
        public String MandateId { get; set; }
    }
}
