namespace MangoPay.SDK.Entities
{
    public class PayInIntentLineItem
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Information about the seller involved in the transaction
        /// </summary>
        public PayInIntentSeller Seller { get; set; }
        
        /// <summary>
        /// The unique identifier of the item
        /// </summary>
        public string Sku { get; set; }
        
        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The quantity of the item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The cost of the item, excluding tax and discount
        /// </summary>
        public int UnitAmount { get; set; }

        /// <summary>
        /// The item total amount to be captured
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The tax amount applied to the item
        /// </summary>
        public int TaxAmount { get; set; }

        /// <summary>
        /// The discount amount applied to the item
        /// </summary>
        public int DiscountAmount { get; set; }

        /// <summary>
        /// The item category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Information about the end user’s shipping address
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// The item total amount including tax and discount
        /// </summary>
        public int TotalLineItemAmount { get; set; }

        /// <summary>
        /// The item total canceled amount
        /// </summary>
        public int CanceledAmount { get; set; }

        /// <summary>
        /// The item total captured amount
        /// </summary>
        public int CapturedAmount { get; set; }

        /// <summary>
        /// The item total refunded amount
        /// </summary>
        public int RefundedAmount { get; set; }

        /// <summary>
        /// The item total disputed amount
        /// </summary>
        public int DisputedAmount { get; set; }

        /// <summary>
        /// The item total split amount
        /// </summary>
        public int SplitAmount { get; set; }
    }
}