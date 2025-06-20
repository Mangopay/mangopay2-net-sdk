namespace MangoPay.SDK.Entities
{
    public class PayInIntentExternalData
    {
        /// <summary>
        /// The date at which the transaction was created
        /// </summary>
        public string ExternalProcessingDate { get; set; }

        /// <summary>
        /// The unique identifier of the transaction at the provider level
        /// </summary>
        public string ExternalProviderReference { get; set; }

        /// <summary>
        /// The unique identifier of the transaction at the merchant level
        /// </summary>
        public string ExternalMerchantReference { get; set; }

        /// <summary>
        /// The name of the external provider processing the transaction
        /// </summary>
        public string ExternalProviderName { get; set; }

        /// <summary>
        /// The name of the payment method used to process the transaction
        /// </summary>
        public string ExternalProviderPaymentMethod { get; set; }
    }
}