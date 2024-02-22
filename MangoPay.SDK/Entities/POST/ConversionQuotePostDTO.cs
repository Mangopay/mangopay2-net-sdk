namespace MangoPay.SDK.Entities.POST
{
    public class ConversionQuotePostDTO : EntityPostBase
    {
        public ConversionQuotePostDTO(
            Money debitedFunds,
            Money creditedFunds,
            int duration,
            string tag
        )
        {
            DebitedFunds = debitedFunds;
            CreditedFunds = creditedFunds;
            Duration = duration;
            Tag = tag;
        }

        /// <summary>The sell funds</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>The buy funds</summary>
        public Money CreditedFunds { get; set; }

        /// <summary>The time in seconds during which the quote is active and can be used for conversions.</summary>
        public int Duration { get; set; }
    }
}