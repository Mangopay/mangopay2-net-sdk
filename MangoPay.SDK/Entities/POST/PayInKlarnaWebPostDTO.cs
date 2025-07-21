using System.Collections.Generic;

namespace MangoPay.SDK.Entities.POST
{
    public class PayInKlarnaWebPostDTO: EntityPostBase
    {

        public PayInKlarnaWebPostDTO(
            string authorId,
            Money debitedFunds,
            Money fees,
            string creditedWalletId,
            string returnUrl,
            List<LineItem> lineItems,
            string country,
            string phone, 
            string email,
            string additionalData,
            Billing billing,
            string reference,
            string culture = null,
            Shipping shipping = null,
            string tag = null
        )
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            LineItems = lineItems;
            Country = country;
            Phone = phone;
            Email = email;
            AdditionalData = additionalData;
            Billing = billing;
            Reference = reference;
            Culture = culture;
            Shipping = shipping;
            Tag = tag;
        }
        
        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }
        
        /// <summary>Credited wallet identifier
        public string CreditedWalletId { get; set; }
        
        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }
        
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
        public string Reference { get; set; }
        
        public string Culture { get; set; }
        
        ///<summary> Information about the shipping address
        public Shipping Shipping { get; set; }
    }
}