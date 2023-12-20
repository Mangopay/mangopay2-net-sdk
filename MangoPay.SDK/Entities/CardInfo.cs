namespace MangoPay.SDK.Entities
{
    /// <summary>Class represents informations about the cards</summary>
    public class CardInfo
    {
        /// <summary>The 6-digit bank identification number (BIN) of the card issuer.</summary>
        public string BIN;

        /// <summary>The name of the card issuer.</summary>
        public string IssuingBank;
        
        /// <summary>The country where the card was issued.</summary>
        public string IssuerCountryCode;

        /// <summary>The type of card product: DEBIT, CREDIT, CHARGE CARD.</summary>
        public string Type;
        
        /// <summary>The card brand. Examples include: AMERICAN EXPRESS, DISCOVER, JCB, MASTERCARD, VISA, etc.</summary>
        public string Brand;

        /// <summary>The subtype of the card product. Examples include: CLASSIC, GOLD, PLATINUM, PREPAID, etc.</summary>
        public string SubType;
    }
}