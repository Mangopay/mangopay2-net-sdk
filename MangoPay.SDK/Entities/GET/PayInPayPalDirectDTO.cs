
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
	public class PayInPayPalDirectDTO : PayInDTO
    {
	    ///<summary>The URL where users are automatically redirected after the payment is validated</summary>
        public string ReturnURL { get; set; }
	    
	    ///<summary>The URL to which the user is redirected to complete the payment</summary>
	    public string RedirectURL { get; set; }
	    
	    ///<summary>Custom description of the payment shown to the consumer when making payments and on the bank statement</summary>
	    public string StatementDescriptor { get; set; }
	    
	    ///<summary>User’s shipping address When not provided, the default address is the one register one the buyer PayPal account</summary>
	    public Shipping Shipping { get; set; }
	    
	    ///<summary>Information about the items bought by the customer</summary>
	    public List<LineItem> LineItems { get; set; }
	}
}
