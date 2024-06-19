using MangoPay.SDK.Core;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Card PUT entity.</summary>
    public class CardPutDTO : EntityPutBase
    {
        /// <summary>You only can switch from TRUE to FALSE to disable the card. Note that this action is irreversible.</summary>
        public bool? Active { get; set; }
        
        /// <summary>
        /// The cardholder’s name shown on the payment card.
        /// </summary>
        public string CardHolderName { get; set; }
    }
}
