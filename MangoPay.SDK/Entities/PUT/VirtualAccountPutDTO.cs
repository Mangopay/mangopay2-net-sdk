using System.Collections.Generic;

namespace MangoPay.SDK.Entities.PUT
{
    public class VirtualAccountPutDTO : EntityPutBase
    {
        public VirtualAccountPutDTO()
        {
            
        }

        public VirtualAccountPutDTO(bool active)
        {
            Active = active;
        }
        
        public string WalletId { get; set; }

        public string CreditedUserId { get; set; }

        public string VirtualAccountPurpose { get; set; }

        public string Country { get; set; }

        public string Status { get; set; }

        public bool Active { get; set; }

        public string AccountOwner { get; set; }

        public LocalAccountDetails LocalAccountDetails { get; set; }

        public List<InternationalAccountDetails> InternationalAccountDetails { get; set; }

        public VirtualAccountCapabilities Capabilities { get; set; }
    }
}