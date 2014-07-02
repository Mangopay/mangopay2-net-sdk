using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Client entity.</summary>
    public class Client : EntityBase
    {
        /// <summary>Client identifier.</summary>
        public String ClientId;

        /// <summary>Name of this client.</summary>
        public String Name;

        /// <summary>Email of this client.</summary>
        public String Email;

        /// <summary>Password for this client.</summary>
        public String Passphrase;
    }
}
