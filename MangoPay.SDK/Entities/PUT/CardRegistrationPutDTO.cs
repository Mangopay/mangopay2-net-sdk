using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Card registration PUT entity.</summary>
    public class CardRegistrationPutDTO : EntityPutBase
    {
        /// <summary>Registration data. This have to be prefixed by "data=".</summary>
        public string RegistrationData { get; set; }
        
        /// <summary>Custom data.</summary>
        public string Tag { get; set; }
        
        /// <summary>
        /// The cardholder’s name shown on the payment card.
        /// </summary>
        public string CardHolderName { get; set; }
    }
}
