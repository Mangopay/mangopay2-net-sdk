namespace MangoPay.SDK.Entities.POST
{
    public class PayInSatispayWebPostDTO: EntityPostBase
    {
        public PayInSatispayWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl,
            string country, string statementDescriptor = null, string tag = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            Country = country;
            StatementDescriptor = statementDescriptor;
            Tag = tag;
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
        
        /// <summary> The end-user country of residence
        public string Country { get; set; }
        
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
    }
}