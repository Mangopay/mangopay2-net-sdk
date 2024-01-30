namespace MangoPay.SDK.Entities.POST
{
    public class PaymentMethodMetadataPostDTO : EntityPostBase
    {
        /// <summary>The type of metadata. Allowed values: BIN, GOOGLE_PAY</summary>
        public string Type { get; set; }
        
        /// <summary>The bank identification number (BIN). (Format: 6 or 8 digits)</summary>
        public string Bin { get; set; }
        
        /// <summary>The tokenized payment data provided by the third-party payment method.</summary>
        public string Token { get; set; }
    }
}