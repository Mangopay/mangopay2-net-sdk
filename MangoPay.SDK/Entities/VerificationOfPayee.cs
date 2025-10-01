namespace MangoPay.SDK.Entities
{
    public class VerificationOfPayee
    {
        /// <summary>
        /// A unique identifier of the VOP check performed by Mangopay.
        /// </summary>
        public string RecipientVerificationId { get; set; }

        /// <summary>
        /// The outcome of the VOP check performed by Mangopay
        /// </summary>
        public string RecipientVerificationCheck { get; set; }

        /// <summary>
        /// The explanation of the check outcome
        /// </summary>
        public string RecipientVerificationMessage { get; set; }
    }
}