
namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Transfer entity.</summary>
    public class TransferDTO : TransactionDTO
    {
        public string ScaContext { get; set; }
        
        public PendingUserActionDTO PendingUserAction { get; set; }
    }
}
