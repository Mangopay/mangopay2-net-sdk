namespace MangoPay.SDK.Entities.GET
{
    public class PayInBizumWebDTO : PayInDTO
    {
        /// <summary>
        /// The phone number of the end user to which the Bizum push notification is sent to authenticate the transaction.
        /// On Bizum, if the Phone parameter is sent, then RedirectURL is not returned and ReturnURL not required.
        /// </summary>
        public string Phone { get; set; }

        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not </summary>
        public string ReturnURL { get; set; }

        /// <summary> The URL to which the user is redirected to complete the payment </summary>
        public string RedirectURL { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
    }
}