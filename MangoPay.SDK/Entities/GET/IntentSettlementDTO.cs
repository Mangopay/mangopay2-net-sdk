namespace MangoPay.SDK.Entities.GET
{
    public class IntentSettlementDTO : EntityBase
    {
        public string SettlementId { get; set; }
        
        public string Status { get; set; }
        
        public string SettlementDate { get; set; }
        
        public string ExternalProviderName { get; set; }
        
        public int DeclaredIntentAmount { get; set; }
        
        public int ExternalProcessorFeesAmount { get; set; }
        
        public int ActualSettlementAmount { get; set; }
        
        public int FundsMissingAmount { get; set; }
    }
}