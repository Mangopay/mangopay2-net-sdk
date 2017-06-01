using System;

namespace MangoPay.SDK.Entities
{
	public class ShippingAddress
	{
		public ShippingAddress(string recipientName, Address address)
		{
			RecipientName = recipientName;
			Address = address;
		}
		
		/// <summary>Recipient name for PayPal shipping address.</summary>
		public String RecipientName { get; set; }

		/// <summary>The address.</summary>
		public Address Address { get; set; }
	}
}
