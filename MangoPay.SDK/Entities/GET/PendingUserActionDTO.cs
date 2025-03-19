namespace MangoPay.SDK.Entities.GET
{
    public sealed class PendingUserActionDTO
    {
        /// <summary>
        /// The URL to which to redirect the user to perform strong customer authentication
        /// (SCA) via a Mangopay-hosted webpage
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}