using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>Card registration PUT entity.</summary>
    public class CardRegistrationPutDTO : EntityPutBase
    {
        /// <summary>Registration data.</summary>
        public String RegistrationData { get; set; }
    }
}
