namespace MangoPay.SDK.Entities.GET
{
    public class ConversionRateDTO: EntityBase
    {
        /// <summary>The sell currency – the currency of the wallet to be debited</summary>
        public string DebitedCurrency { get; set; }
        
        /// <summary>The buy currency – the currency of the wallet to be credited.</summary>
        public string CreditedCurrency { get; set; }
        
        /// <summary>The market rate plus Mangopay's commission,
        /// charged during the platform's billing cycle. This is an indicative rate.</summary>
        public string ClientRate { get; set; }
        
        /// <summary>The rate used for the conversion, excluding Mangopay's commission.</summary>
        public string MarketRate { get; set; }
    }
}