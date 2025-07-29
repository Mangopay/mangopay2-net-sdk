using System;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    public class PayInIntentSplitPostDTO : EntityPostBase
    {
        /// <summary>
        /// The unique identifier of an item in Mangopay ecosystem
        /// </summary>
        public string LineItemId { get; set; }
        
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
    }
}