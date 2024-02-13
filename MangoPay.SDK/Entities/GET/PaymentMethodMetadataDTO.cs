using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    public class PaymentMethodMetadataDTO : EntityBase
    {
        /// <summary>The type of metadata. Allowed values: BIN, GOOGLE_PAY</summary>
        public string Type { get; set; }
        
        /// <summary>The bank identification number (BIN). (Format: 6 or 8 digits)</summary>
        public string Bin { get; set; }
        
        /// <summary>The tokenized payment data provided by the third-party payment method.</summary>
        public string Token { get; set; }

        /// <summary>In the case of Google Pay, the format of the Token.
        /// PAN_ONLY – The card is registered in the Google account and requires 3DS authentication.
        /// CRYPTOGRAM_3DS – The card is enrolled in the customer’s Google Wallet and authentication is handled by the Android device.</summary>
        public string TokenFormat { get; set; }
        
        /// <summary>The type of the card. Allowed / Returned / Default values: CREDIT, DEBIT, CHARGE CARD</summary>
        public string CardType { get; set; }
        
        /// <summary>The country where the card was issued. Format: ISO-3166 alpha-2 two-letter country code</summary>
        public string IssuerCountryCode { get; set; }

        /// <summary>The name of the card issuer</summary>
        public string IssuingBank { get; set; }
        
        /// <summary>Whether the card is held in a personal or commercial capacity.</summary>
        public string CommercialIndicator { get; set; }
        
        /// <summary>Additional data about the card based on the BIN. In the case of co-branded card products, two objects are returned.</summary>
        public List<BinData> BinData { get; set; }
    }
}