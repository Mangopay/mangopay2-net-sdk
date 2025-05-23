namespace MangoPay.SDK.Entities
{
    public class LocalAccount
    {
        public string AccountNumber { get; set; }

        public string SortCode { get; set; }
        
        public string Iban { get; set; }

        public string Bic { get; set; }
        
        public string AchNumber { get; set; }
        
        public string FedWireNumber { get; set; }
        
        public string AccountType { get; set; }
        
        public string BranchCode { get; set; }
        
        public string InstitutionNumber { get; set; }
    }
}