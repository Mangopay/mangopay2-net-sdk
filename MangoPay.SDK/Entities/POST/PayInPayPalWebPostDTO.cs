using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn by PayPal Web POST entity.</summary>
    public class PayInPayPalWebPostDTO : EntityPostBase
    {
        public PayInPayPalWebPostDTO(
            string authorId,
            Money debitedFunds,
            Money fees,
            string creditedWalletId,
            string returnURL,
            List<LineItem> lineItems,
            Shipping shipping = null,
            string statementDescriptor = null,
            CultureCode? culture = null,
            ShippingPreference? shippingPreference = null,
            string reference = null,
            string cancelUrl = null
        )
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnURL;
            LineItems = lineItems;
            Shipping = shipping;
            StatementDescriptor = statementDescriptor;
            Culture = culture;
            ShippingPreference = shippingPreference;
            Reference = reference;
            CancelURL = cancelUrl;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }

        /// <summary>Return URL.</summary>
        public string ReturnURL { get; set; }

        /// <summary>Information about the items bought by the customer</summary>
        public List<LineItem> LineItems { get; set; }
        
        ///<summary> Shipping preference
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingPreference? ShippingPreference { get; set; }

        /// <summary>
        /// User’s shipping address
        /// When not provided, the default address is the one register one the buyer PayPal account
        /// </summary>
        public Shipping Shipping { get; set; }

        /// <summary>
        /// Custom description to appear on the user’s bank statement along with the platform name.
        /// Note that a particular bank may show more or less information.
        /// </summary>
        public string StatementDescriptor { get; set; }
        
        public string Reference { get; set; }
        
        public string CancelURL { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
        
        public string DataCollectionId { get; set; }
    }
}