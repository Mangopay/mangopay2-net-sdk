using MangoPay.Entities;
using System;

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
        public CardDTO Get(String cardId)
        {
            return this.GetObject<CardDTO>(MethodKey.CardGet, cardId);
        }

        /// <summary>Saves card.</summary>
        /// <param name="card">Card instance to be updated.</param>
        /// <param name="cardId">Card identifier.</param>
        /// <returns>Card instance returned from API.</returns>
        public CardDTO Update(CardPutDTO card, String cardId)
        {
            return this.UpdateObject<CardDTO, CardPutDTO>(MethodKey.CardSave, card, cardId);
        }
    }
}
