namespace MangoPay.SDK.Entities
{
    public class PayInIntentSeller
    {
        /// <summary>
        /// The unique identifier of the seller providing the item.
        /// One valid value must be sent between AuthorId and WalletId.
        /// </summary>
        public string AuthorId { get; set; }
        
        /// <summary>
        /// The unique identifier of the wallet to credit the seller funds.
        /// One valid value must be sent between AuthorId and WalletId.
        /// </summary>
        public string WalletId { get; set; }
        
        /// <summary>
        /// Information about the fees
        /// </summary>
        public int FeesAmount { get; set; }
        
        /// <summary>
        /// Information about the date when the funds are to be transferred to the seller’s wallet.
        /// Must be a date in the future.
        /// </summary>
        public string TransferDate { get; set; }
    }
}