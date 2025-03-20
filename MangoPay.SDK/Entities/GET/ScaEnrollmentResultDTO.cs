namespace MangoPay.SDK.Entities.GET
{
    public sealed class ScaEnrollmentResultDTO: EntityBase
    {
        /// <summary>
        /// Object containing the link needed for SCA redirection if triggered by the API call (otherwise returned null).
        /// </summary>
        public PendingUserActionDTO PendingUserAction { get; set; }
    }
}