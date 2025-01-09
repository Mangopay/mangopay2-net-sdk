using System.Collections.Generic;

namespace MangoPay.SDK.Entities
{
    public class VirtualAccountAvailabilities : EntityBase
    {
        public VirtualAccountAvailabilities()
        {
            Collection = new List<VirtualAccountAvailability>();
            UserOwned = new List<VirtualAccountAvailability>();
        }

        public List<VirtualAccountAvailability> Collection;

        public List<VirtualAccountAvailability> UserOwned;
    }
}