using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for cards.</summary>
    public class ApiCards : ApiBase
    {
        /// <summary>Instantiates new ApiCards object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiCards(MangoPayApi root) : base(root) { }

        /// <summary>Gets card.</summary>
        /// <param name="cardId">Card identifier.</param>
        /// <returns>Card instance returned from API.</returns>
        public Card Get(String cardId)
        {
            return this.GetObject<Card>("card_get", cardId);
        }

        /// <summary>Saves card.</summary>
        /// <param name="card">Card instance to be updated.</param>
        /// <returns>Card instance returned from API.</returns>
        public Card Update(Card card)
        {
            return this.UpdateObject<Card>("card_save", card);
        }

        /// <summary>Disables card (sets { INVALID } as the value of Validity field).</summary>
        /// <param name="card">Card instance to be updated.</param>
        /// <returns>Card instance returned from API.</returns>
        public Card Disable(Card card)
        {
            card.Validity = "INVALID";
            return Update(card);
        }
    }
}
