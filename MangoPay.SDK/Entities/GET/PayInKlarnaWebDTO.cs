using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInKlarnaWebDTO: PayInDTO
    {
        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }
        
        /// <summary> The URL to which the user is redirected to complete the payment
        public string RedirectURL { get; set; }
        
        ///<summary>Information about the items bought by the customer</summary>
        public List<LineItem> LineItems { get; set; }
        
        /// <summary> The end-user country of residence
        public string Country { get; set; }
        
        /// <summary> The end-user mobile phone number
        public string Phone { get; set; }
        
        /// <summary> The end-user email address
        public string Email { get; set; }
        
        /// <summary> Klarna custom data that you can add to this item
        public string AdditionalData { get; set; }
        
        /// <summary> Information about the billing address
        public Billing Billing { get; set; }
        
        /// <summary> The merchant order reference
        public string MerchantOrderId { get; set; }
        
        public string Culture { get; set; }
        
        ///<summary> Information about the shipping address
        public Shipping Shipping { get; set; }
        
        /// <summary> The Klarna option that the end-user has chosen at checkout
        public string PaymentMethod { get; set; }
        
    }
}