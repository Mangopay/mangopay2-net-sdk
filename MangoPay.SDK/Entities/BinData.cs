namespace MangoPay.SDK.Entities
{
    public class BinData
    {
        /// <summary>The subtype of the card product. Examples include: CLASSIC, GOLD, PLATINUM, PREPAID, etc.</summary>
        public string SubType { get; set; }
        
        /// <summary>The card brand. Examples include: AMERICAN EXPRESS, DISCOVER, JCB, MASTERCARD, VISA, etc.</summary>
        public string Brand { get; set; }
    }
}