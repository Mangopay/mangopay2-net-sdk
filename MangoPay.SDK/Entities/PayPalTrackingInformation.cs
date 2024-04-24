namespace MangoPay.SDK.Entities
{
    public class PayPalTrackingInformation
    {
        /// <summary>The shipment’s tracking number provided by the carrier.</summary>
        public string TrackingNumber { get; set; }

        /// <summary>The carrier for the shipment. Use the country-specific version of the carrier if it exists,
        /// otherwise use its global version.</summary>
        public string Carrier { get; set; }
        
        /// <summary>If true, sends an email notification to the PaypalBuyerAccountEmail containing the
        /// TrackingNumber and Carrier, which allows the end user to track their shipment with the carrier.</summary>
        public string NotifyBuyer { get; set; }
    }
}