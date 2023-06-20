namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn mbway direct POST entity.</summary>
    public class PayInMbwayDirectPostDTO : EntityPostBase
    {
        public PayInMbwayDirectPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string phoneNumber, string statementDescriptor = null, string tag = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            StatementDescriptor = statementDescriptor;
            Tag = tag;
            PhoneNumber = phoneNumber;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary>The mobile phone number of the user initiating the pay-in Country code
        /// followed by hash symbol (#) followed by the rest of the number. Only digits and hash allowed</summary>
        public string PhoneNumber { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
    }
}
