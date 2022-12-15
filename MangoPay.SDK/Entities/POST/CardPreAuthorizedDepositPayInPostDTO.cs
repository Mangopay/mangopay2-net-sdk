namespace MangoPay.SDK.Entities.POST
{
    public class CardPreAuthorizedDepositPayInPostDTO : EntityPostBase
    {
        public CardPreAuthorizedDepositPayInPostDTO(string creditedWalletId, Money debitedFunds, Money fees, string depositId)
        {
            CreditedWalletId = creditedWalletId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            DepositId = depositId;
        }

        public CardPreAuthorizedDepositPayInPostDTO()
        {
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Credited Wallet identifier.</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary>Debited Funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }
        
        /// <summary>Deposit identifier.</summary>
        public string DepositId { get; set; }
    }
}