using System;

namespace MangoPay.SDK.Entities.GET
{
    public class CountryAuthorizationDataDTO
    {
        public Boolean BlockUserCreation { get; set; }
        
        public Boolean BlockBankAccountCreation { get; set; }
        
        public Boolean BlockPayout { get; set; }
    }
}