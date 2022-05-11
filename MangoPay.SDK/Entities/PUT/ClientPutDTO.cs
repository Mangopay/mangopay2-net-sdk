using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Client PUT entity.</summary>
	public class ClientPutDTO : EntityPutBase
    {
		/// <summary>Your branding colour to use for theme pages.</summary>
		public string PrimaryThemeColour;

		/// <summary>Your branding colour to use for call to action buttons.</summary>
		public string PrimaryButtonColour;

		/// <summary>
		/// A list of email addresses 
		/// to use when contacting you for technical issues/communications.
		/// </summary>
		public List<string> TechEmails { get; set; }

		/// <summary>
		/// A list of email addresses to use when contacting you 
		/// for admin/commercial issues/communications
		/// </summary>
		public List<string> AdminEmails { get; set; }

		/// <summary>
		/// A list of email addresses to use when contacting you 
		/// for fraud/compliance issues/communications
		/// </summary>
		public List<string> FraudEmails { get; set; }

		/// <summary>
		/// A list of email addresses to use when contacting you 
		/// for billing issues/communications
		/// </summary>
		public List<string> BillingEmails { get; set; }

		/// <summary>A description of what your platform does</summary>
		public string PlatformDescription { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
		/// <summary>The type of platform</summary>
		public PlatformType? PlatformType { get; set; }

		/// <summary>The URL for your website</summary>
		public string PlatformURL { get; set; }

		/// <summary>The address of the company’s headquarters</summary>
		public Address HeadquartersAddress { get; set; }

        ///<summary>The phone number of the company's headquarters</summary>
        public string HeadquartersPhoneNumber { get; set; }
        
        /// <summary>The tax (or VAT) number for your company</summary>
        public string TaxNumber { get; set; }

		public bool ShouldSerializeHeadquartersAddress()
		{
			return HeadquartersAddress != null && HeadquartersAddress.IsValid();
		}
	}
}
