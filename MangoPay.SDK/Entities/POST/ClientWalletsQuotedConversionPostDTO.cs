namespace MangoPay.SDK.Entities.POST
{
    public class ClientWalletsQuotedConversionPostDTO : EntityPostBase
    {
        /// <summary>
        /// The unique identifier of the active quote which guaranteed the rate for the conversion.
        /// </summary>
        public string QuoteId { get; set; }
        
        /// <summary>
        /// The type of the client wallet to be debited: FEES or CREDIT
        /// </summary>
        public string DebitedWalletType { get; set; }

        /// <summary>
        /// The type of the client wallet to be credited: FEES or CREDIT
        /// </summary>
        public string CreditedWalletType { get; set; }
    }
}