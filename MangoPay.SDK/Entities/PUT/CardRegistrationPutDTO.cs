using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Card registration PUT entity.</summary>
    public class CardRegistrationPutDTO : EntityPutBase
    {
        /// <summary>Registration data. This have to be prefixed by "data=".</summary>
        public String RegistrationData { get; set; }
        
        /// <summary>Custom data.</summary>
        public String Tag { get; set; }
    }
}
