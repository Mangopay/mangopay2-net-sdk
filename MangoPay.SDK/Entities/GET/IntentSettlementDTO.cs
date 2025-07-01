namespace MangoPay.SDK.Entities.GET
{
    public class IntentSettlementDTO : EntityBase
    {
        /// <summary>
        /// The unique identifier of the settlement object
        /// </summary>
        public string SettlementId { get; set; }
        
        /// <summary>
        /// The status of the settlement
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// The date at which the settlement was created by the external provider
        /// </summary>
        public string SettlementDate { get; set; }
        
        /// <summary>
        /// The name of the external provider
        /// </summary>
        public string ExternalProviderName { get; set; }
        
        /// <summary>
        /// The total amount declared through intent API calls with the following calculation:
        /// (Sum of captured intents) - (Sum of refunds amounts) + (Sum of refund reversed amounts) - (Sum of DISPUTED disputes) + (Sum of WON disputes)
        /// </summary>
        public int DeclaredIntentAmount { get; set; }
        
        /// <summary>
        /// The total fees charged by the external provider
        /// </summary>
        public int ExternalProcessorFeesAmount { get; set; }
        
        /// <summary>
        /// The total amount due to the platform (to be held in escrow wallet).
        /// This amount correspond to the TotalSettlementAmount from the settlement file.
        /// A negative amount will result in this parameter being set to zero, indicating no incoming funds to the escrow wallet.
        /// </summary>
        public int ActualSettlementAmount { get; set; }
        
        /// <summary>
        /// The difference between ActualSettlementAmount and the amount received on the escrow wallet
        /// </summary>
        public int FundsMissingAmount { get; set; }
    }
}