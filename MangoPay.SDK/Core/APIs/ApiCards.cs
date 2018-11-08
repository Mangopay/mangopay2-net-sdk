using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using System;
using MangoPay.SDK.Entities;

namespace MangoPay.SDK.Core.APIs
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

        /// <summary>Lists transactions for a card</summary>
        /// <param name="cardId">Id of the card to get transactions</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of transactions for a card</returns>
        public ListPaginated<TransactionDTO> GetTransactionsForCard(string cardId, Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return GetList<TransactionDTO>(MethodKey.CardTransactions, pagination, cardId, sort, filters.GetValues());
        }

        /// <summary>
        /// Gets a list of cards having the same fingerprint.
        /// </summary>
        /// <param name="fingerprint">The fingerprint hash</param>
        /// <returns>List of Cards corresponding to provided fingerprint</returns>
        public ListPaginated<CardDTO> GetCardsByFingerprint(string fingerprint)
        {
            return GetCardsByFingerprint(fingerprint, null, null);
        }

        /// <summary>
        /// Gets a list of cards having the same fingerprint.
        /// </summary>
        /// <param name="fingerprint">The fingerprint hash</param>
        /// <param name="pagination">The pagionation object</param>
        /// <param name="sort">The sort object</param>
        /// <returns></returns>
        public ListPaginated<CardDTO> GetCardsByFingerprint(string fingerprint, Pagination pagination, Sort sort)
        {
            return GetList<CardDTO>(MethodKey.CardByFingerprintGet, pagination, fingerprint, sort);
        }
    }
}
