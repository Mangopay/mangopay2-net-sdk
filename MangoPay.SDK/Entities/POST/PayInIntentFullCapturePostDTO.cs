namespace MangoPay.SDK.Entities.POST
{
    public class PayInIntentFullCapturePostDTO : EntityPostBase
    {
        /// <summary>
        /// Information about the external processed transaction.
        /// If the authorization and capture occur simultaneously,
        /// it is assumed that the ExternalData remains unchanged from the intent authorization.
        /// If ExternalData is not explicitly provided at capture, the values from the created intent will be used.
        /// </summary>
        public PayInIntentExternalData ExternalData { get; set; }
    }
}