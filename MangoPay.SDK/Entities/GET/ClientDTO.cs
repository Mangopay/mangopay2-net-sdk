using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Client entity.</summary>
    public class ClientDTO : EntityBase
    {
        /// <summary>Client identifier.</summary>
        public String ClientId { get; set; }

        /// <summary>Name of this client.</summary>
        public String Name { get; set; }

        /// <summary>Your branding colour to use for theme pages.</summary>
		public String PrimaryThemeColour;

		/// <summary>Your branding colour to use for call to action buttons.</summary>
		public String PrimaryButtonColour;

		/// <summary>The URL of your MANGOPAY hosted logo.</summary>
		public String Logo;

		/// <summary>
		/// A list of email addresses 
		/// to use when contacting you for technical issues/communications.
		/// </summary>
		public List<String> TechEmails { get; set; }

		/// <summary>
		/// A list of email addresses to use when contacting you 
		/// for admin/commercial issues/communications
		/// </summary>
		public List<String> AdminEmails { get; set; }

		/// <summary>
		/// A list of email addresses to use when contacting you 
		/// for fraud/compliance issues/communications
		/// </summary>
		public List<String> FraudEmails { get; set; }

		/// <summary>
		/// A list of email addresses to use when contacting you 
		/// for billing issues/communications
		/// </summary>
		public List<String> BillingEmails { get; set; }

		/// <summary>A description of what your platform does</summary>
		public String PlatformDescription { get; set; }

		/// <summary>The type of platform</summary>
		public PlatformType? PlatformType { get; set; }

		/// <summary>The URL for your website</summary>
		public String PlatformURL { get; set; }

		/// <summary>The address of the company’s headquarters</summary>
		public Address HeadquartersAddress { get; set; }

        ///<summary>The phone number of the company's headquarters</summary>
        public String HeadquartersPhoneNumber { get; set; }

        /// <summary>The tax (or VAT) number for your company</summary>
        public String TaxNumber { get; set; }
	}
}
