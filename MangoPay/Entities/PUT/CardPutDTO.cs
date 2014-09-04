using MangoPay.Core;

namespace MangoPay.Entities
{
    /// <summary>Card PUT entity.</summary>
    public class CardPutDTO : EntityPutBase
    {
        /// <summary>You only can switch from TRUE to FALSE to disable the card. Note that this action is irreversible.</summary>
        public bool Active { get; set; }
    }
}
