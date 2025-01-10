using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    public class VirtualAccountAvailabilitiesDTO : EntityBase
    {
        public VirtualAccountAvailabilitiesDTO()
        {
            Collection = new List<VirtualAccountAvailability>();
            UserOwned = new List<VirtualAccountAvailability>();
        }

        public List<VirtualAccountAvailability> Collection;

        public List<VirtualAccountAvailability> UserOwned;
    }
}