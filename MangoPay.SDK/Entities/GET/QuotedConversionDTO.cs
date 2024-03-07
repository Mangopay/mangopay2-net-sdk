namespace MangoPay.SDK.Entities.GET
{
    public class QuotedConversionDTO : TransactionDTO
    {
        /// <summary>The unique identifier of the active quote which guaranteed the rate for the conversion.</summary>
        public string QuoteId { get; set; }

        /// <summary>Information about the conversion rate used during the transaction.</summary>
        public ConversionRateDTO ConversionRateResponse { get; set; }
    }
}