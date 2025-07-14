using System.Collections.Generic;

namespace MangoPay.SDK.Entities.PUT
{
    public class PayInIntentPutDTO : EntityPutBase
    {
        /// <summary>
        /// An amount of money in the smallest sub-division of the currency
        /// </summary>
        public int? Amount { get; set; }
        
        /// <summary>
        /// Information about the fees
        /// </summary>
        public int? PlatformFeesAmount { get; set; }
        
        /// <summary>
        /// Information about the external processed transaction
        /// </summary>
        public PayInIntentExternalData ExternalData { get; set; }
        
        /// <summary>
        /// Information about the buyer
        /// </summary>
        public PayInIntentBuyer Buyer { get; set; }
        
        /// <summary>
        /// Information about the items purchased in the transaction.
        /// The total of all LineItems UnitAmount, TaxAmount, DiscountAmount, TotalLineItemAmount must equal the Amount.
        /// The total of all LineItems FeesAmount must equal the PlatformFees amount.
        /// </summary>
        public List<PayInIntentLineItem> LineItems { get; set; }
    }
}