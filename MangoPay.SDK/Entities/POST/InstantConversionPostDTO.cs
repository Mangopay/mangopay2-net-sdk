namespace MangoPay.SDK.Entities.POST
{
    public class InstantConversionPostDTO: EntityPostBase
    {

        public InstantConversionPostDTO(string authorId, string debitedWalletId, string creditedWalletId,
            Money debitedFunds, Money creditedFunds,
            string tag = null)
        {
            AuthorId = authorId;
            DebitedWalletId = debitedWalletId;
            CreditedWalletId = creditedWalletId;
            DebitedFunds = debitedFunds;
            CreditedFunds = creditedFunds;
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
    }
}