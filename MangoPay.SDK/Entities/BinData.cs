namespace MangoPay.SDK.Entities
{
    public class BinData
    {
        /// <summary>The subtype of the card product. Examples include: CLASSIC, GOLD, PLATINUM, PREPAID, etc.</summary>
        public string Subtype { get; set; }
        
        /// <summary>The card brand. Examples include: AMERICAN EXPRESS, DISCOVER, JCB, MASTERCARD, VISA, etc.</summary>
        public string Brand { get; set; }
        
        /// <summary>Whether the card is held in a personal or commercial capacity.</summary>
        public string CommercialIndicator { get; set; }
        
        /// <summary>The type of the card. Allowed / Returned / Default values: CREDIT, DEBIT, CHARGE CARD</summary>
        public string CardType { get; set; }
    }
}