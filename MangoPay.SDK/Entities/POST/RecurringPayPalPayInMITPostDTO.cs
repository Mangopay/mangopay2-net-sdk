using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayPalPayInMITPostDTO : EntityPostBase
    {
        /// <summary>
        /// The unique identifier of the recurring pay-in registration.
        /// </summary>
        public string RecurringPayinRegistrationId { get; set; }

        /// <summary>
        /// Amount of the subsequent payment. If this field is empty we will take the amount entered in the NextTransactionDebitedFunds of the Recurring PayIn Registration. An amount must be transmitted during either registration or pay-in (if it’s different from the registration one).
        /// </summary>
        public Money DebitedFunds { get; set; }

        /// <summary>
        /// Amount of the subsequent fees. If this field is empty we will take the amount entered in the NextTransactionFees of the Recurring PayIn Registration. An amount must be transmitted during either registration or pay-in.
        /// </summary>
        public Money Fees { get; set; }

        /// <summary>
        /// The URL to which the user is returned after the payment, whether the transaction is successful or not.
        /// </summary>
        public string ReturnURL { get; set; }

        /// <summary>
        /// The URL to which the user is returned after canceling the payment.
        /// If not provided, the Cancel button returns the user to the RedirectURL.
        /// </summary>
        public string CancelURL { get; set; }

        /// <summary>
        /// Custom description to appear on the user’s bank statement along with the platform name
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Information about the end user’s shipping address, managed by ShippingPreference.
        /// Required if ShippingPreference is SET_PROVIDED_ADDRESS and the shipping information is not present in the
        /// recurring registration object.
        /// </summary>
        public Shipping Shipping { get; set; }

        /// <summary>
        /// Information about the items purchased in the transaction
        /// </summary>
        public List<LineItem> LineItems { get; set; }

        /// <summary>
        /// The language in which the PayPal payment page is to be displayed.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }

        /// <summary>
        /// Information about the shipping address behavior on the PayPal payment page:
        /// SET_PROVIDED_ADDRESS, GET_FROM_FILE, NO_SHIPPING
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingPreference? ShippingPreference { get; set; }

        /// <summary>
        /// The platform’s order reference for the transaction.
        /// </summary>
        public string Reference { get; set; }
    }
}