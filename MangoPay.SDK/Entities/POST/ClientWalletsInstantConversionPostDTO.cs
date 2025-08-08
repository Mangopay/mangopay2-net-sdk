namespace MangoPay.SDK.Entities.POST
{
    public class ClientWalletsInstantConversionPostDTO : EntityPostBase
    {
        /// <summary>
        /// The type of the client wallet to be debited: FEES or CREDIT
        /// </summary>
        public string DebitedWalletType { get; set; }

        /// <summary>
        /// The type of the client wallet to be credited: FEES or CREDIT
        /// </summary>
        public string CreditedWalletType { get; set; }
        
        /// <summary>
        /// Information about the debited funds.
        /// </summary>
        public Money DebitedFunds { get; set; }
        
        /// <summary>
        /// Information about the credited funds.
        /// </summary>
        public Money CreditedFunds { get; set; }
    }
}