
namespace MangoPay.SDK.Entities.GET
{
	public class PayInPayPalDTO : PayInDTO
    {
		/// <summary>The shipping address for PayPal PayIn.</summary>
		public ShippingAddress ShippingAddress { get; set; }
	}
}
