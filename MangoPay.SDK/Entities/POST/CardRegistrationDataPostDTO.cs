namespace MangoPay.SDK.Entities.POST
{
    /// <summary>
    /// Card registration data POST entity.
    /// </summary>
    public class CardRegistrationDataPostDTO : EntityPostBase
    {
        public CardRegistrationDataPostDTO(string preregistrationData, string accessKey,
            string cardNumber, string cardExpirationDate, string cardCvx, string cardRegistrationURL)
        {
            this.PreregistrationData = preregistrationData;
            this.AccessKey = accessKey;
            this.CardCvx = cardCvx;
            this.CardNumber = cardNumber;
            this.CardExpirationDate = cardExpirationDate;
            this.CardRegistrationURL = cardRegistrationURL;
        }

        /// <summary>
        /// Card registration URL.
        /// </summary>
        public string CardRegistrationURL { get; set; }

        /// <summary>
        /// Registration data.
        /// </summary>
        public string PreregistrationData { get; set; }

        /// <summary>
        /// Access key.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Card expiration date.
        /// </summary>
        public string CardExpirationDate { get; set; }

        /// <summary>
        /// Card Cvx
        /// </summary>
        public string CardCvx { get; set; }
    }
}
