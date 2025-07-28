using System.Collections.Generic;

namespace MangoPay.SDK.Entities
{
    public class Bank
    {
        public string BankName { get; set; }
        
        public List<string> Scheme { get; set; }
        
        public string Name { get; set; }
    }
}