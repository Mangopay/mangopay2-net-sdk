using System;

namespace MangoPay.SDK.Entities
{
    public class LineItem
    {
        /// <summary>Item name</summary>
        public string Name { get; set; }

        /// <summary>Quantity of item bought</summary>
        public Int64 Quantity { get; set; }

        /// <summary>The item cost</summary>
        public Int64 UnitAmount { get; set; }

        /// <summary>The item tax</summary>
        public Int64 TaxAmount { get; set; }

        /// <summary>
        /// A consistent and unique reference for the seller. It can be:
        ///		- The user ID created on MANGOPAY for the seller
        ///		- Or the firstname and lastname of the seller
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The category of the item, allowing line items of different types to be distinguished
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// The unique identifier of the line item.
        /// </summary>
        public string Sku { get; set; }
    }
}