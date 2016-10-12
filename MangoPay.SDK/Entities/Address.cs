using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities
{
	/// <summary>Class represents an address.</summary>
	public class Address
	{
		/// <summary>Address line 1.</summary>
		public String AddressLine1;

		/// <summary>Address line 2.</summary>
		public String AddressLine2;

		/// <summary>City.</summary>
		public String City;

		/// <summary>Region.</summary>
		public String Region;

		/// <summary>Postal code.</summary>
		public String PostalCode;

		/// <summary>Country.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CountryIso? Country;

		/// <summary>Helper method used internally.</summary>
		public bool IsValid()
		{
			return AddressLine1 != null ||
				AddressLine2 != null ||
				City != null ||
				Region != null ||
				PostalCode != null ||
				(Country != null && Country != CountryIso.NotSpecified);
		}
	}
}
