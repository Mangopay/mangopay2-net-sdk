namespace MangoPay.SDK.Entities.POST
{
    public class QuotedConversionPostDTO : EntityPostBase
    {
        public QuotedConversionPostDTO(
            string quoteId,
            string authorId,
            string debitedWalletId,
            string creditedWalletId,
            string tag
        )
        {
            QuoteId = quoteId;
            AuthorId = authorId;
            DebitedWalletId = debitedWalletId;
            CreditedWalletId = creditedWalletId;
            Tag = tag;
        }

        /// <summary>The unique identifier of the active quote which guaranteed
        /// the rate for the conversion.</summary>
        public string QuoteId { get; set; }

        /// <summary>The unique identifier of the user at the source of the
        /// transaction. In a conversion, both the debited and credited wallets are owned by the author.</summary>
        public string AuthorId { get; set; }

        /// <summary>The unique identifier of the debited wallet (in the sell currency).</summary>
        public string DebitedWalletId { get; set; }

        /// <summary>The unique identifier of the credited wallet (in the buy currency).</summary>
        public string CreditedWalletId { get; set; }
    }
}