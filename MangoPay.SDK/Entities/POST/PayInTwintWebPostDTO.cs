namespace MangoPay.SDK.Entities.GET
{
    public class PayInTwintWebPostDTO: EntityPostBase
    {
        public PayInTwintWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }
        
        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }
        
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
    }
}