namespace MangoPay.SDK.Entities.POST
{
    public class ConversionPostDTO: EntityPostBase
    {

        public ConversionPostDTO(string authorId, string debitedWalletId, string creditedWalletId,
            Money debitedFunds, Money creditedFunds, Money fees,
            string tag = null)
        {
            AuthorId = authorId;
            DebitedWalletId = debitedWalletId;
            CreditedWalletId = creditedWalletId;
            DebitedFunds = debitedFunds;
            CreditedFunds = creditedFunds;
            Fees = fees;
            Tag = tag;
        }
            
         /// <summary>The unique identifier of the user at the source of the transaction.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>The unique identifier of the debited wallet.</summary>
        public string DebitedWalletId { get; set; }
        
        /// <summary>The unique identifier of the credited wallet</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary>The sell funds</summary>
        public Money DebitedFunds { get; set; }
        
        /// <summary>The buy funds</summary>
        public Money CreditedFunds { get; set; }
        
        /// <summary>Information about the fees taken by the platform for
        /// this transaction (and hence transferred to the Fees Wallet).</summary>
        public Money Fees { get; set; }
    }
}