namespace MangoPay.SDK.Entities.POST
{
    public class IdentityVerificationPostDto : EntityPostBase
    {
        /// <summary>The URL to which the user is returned after the hosted identity verification session, regardless of the outcome.</summary>
        public string ReturnUrl { get; set; }
    }
}