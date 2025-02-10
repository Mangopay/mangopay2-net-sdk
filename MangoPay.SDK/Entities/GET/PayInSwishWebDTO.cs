namespace MangoPay.SDK.Entities.GET
{
    public class PayInSwishWebDTO: PayInDTO
    {
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not </summary>
        public string ReturnURL { get; set; }

        /// <summary> The URL to which the user is redirected to complete the payment </summary>
        public string RedirectURL { get; set; }
        
        /// <summary> The mobile URL to which to redirect the user to complete the payment in an app-to-app flow. </summary>
        public string DeepLinkURL { get; set; }
        
        /// <summary> The PNG file of the Swish QR code as a Base64-encoded string. </summary>
        public string QRCodeURL { get; set; }
        
        /// <summary>
        /// <p>Allowed values: WEB, APP</p>
        /// <p>Default value: WEB</p>
        /// <p>The platform environment of the post-payment flow. The PaymentFlow value combines with the ReturnURL to manage the redirection behavior after payment:</p>
        /// <p>Set the value to APP to send the user to your platform’s mobile app</p>
        /// <p>Set the value to WEB to send the user to a web browser</p>
        /// <p>In both cases you need to provide the relevant ReturnURL, whether to your app or website.</p>
        /// </summary>
        public string PaymentFlow { get; set; }
    }
}