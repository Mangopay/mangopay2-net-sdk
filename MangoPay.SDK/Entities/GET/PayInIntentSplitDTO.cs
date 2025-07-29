using System;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities
{
    public class PayInIntentSplitDTO : EntityBase
    {
        /// <summary>
        /// The unique identifier of an item in Mangopay ecosystem
        /// </summary>
        public string LineItemId { get; set; }
        
        /// <summary>
        /// The unique identifier of the seller providing the item (userId)
        /// </summary>
        public string SellerId { get; set; }
        
        /// <summary>
        /// The unique identifier of the wallet to credit the seller funds
        /// </summary>
        public string WalletId { get; set; }
        
        /// <summary>
        /// Information about the amount to be credited to the seller wallet
        /// </summary>
        public int SplitAmount { get; set; }
        
        /// <summary>
        /// Information about the fees
        /// </summary>
        public int FeesAmount { get; set; }
        
        /// <summary>
        /// Information about the date when the funds are to be transferred to the seller’s wallet.
        /// Must be a date in the future.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? TransferDate { get; set; }
        
        /// <summary>
        /// The description of the split object
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The status of the split
        /// </summary>
        public string Status { get; set; }
    }
}