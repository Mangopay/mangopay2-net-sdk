using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>Client entity.</summary>
    public class ClientDTO : EntityBase
    {
        /// <summary>Client identifier.</summary>
        public String ClientId { get; set; }

        /// <summary>Name of this client.</summary>
        public String Name { get; set; }

        /// <summary>Email of this client.</summary>
        public String Email { get; set; }

        /// <summary>Password for this client.</summary>
        public String Passphrase { get; set; }
    }
}
