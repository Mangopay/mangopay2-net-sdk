using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using MangoPay.SDK.Entities;
using System.Threading.Tasks;

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
        public async Task<CardDTO> GetAsync(string cardId)
        {
            return await this.GetObjectAsync<CardDTO>(MethodKey.CardGet, entitiesId: cardId);
        }

        /// <summary>Saves card.</summary>
        /// <param name="card">Card instance to be updated.</param>
        /// <param name="cardId">Card identifier.</param>
        /// <returns>Card instance returned from API.</returns>
        public async Task<CardDTO> UpdateAsync(CardPutDTO card, string cardId)
        {
            return await this.UpdateObjectAsync<CardDTO, CardPutDTO>(MethodKey.CardSave, card, entitiesId: cardId);
        }

        /// <summary>Lists transactions for a card</summary>
        /// <param name="cardId">Id of the card to get transactions</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of transactions for a card</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsForCardAsync(string cardId, Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return await GetListAsync<TransactionDTO>(MethodKey.CardTransactions, pagination, sort, filters.GetValues(), entitiesId: cardId);
        }

        /// <summary>
        /// Gets a list of cards having the same fingerprint.
        /// </summary>
        /// <param name="fingerprint">The fingerprint hash</param>
        /// <param name="pagination">The pagination object</param>
        /// <param name="sort">The sort object</param>
        /// <returns></returns>
        public async Task<ListPaginated<CardDTO>> GetCardsByFingerprintAsync(string fingerprint, Pagination pagination = null, Sort sort = null)
        {
            return await GetListAsync<CardDTO>(MethodKey.CardByFingerprintGet, pagination, sort, entitiesId: fingerprint);
        }

        /// <summary>Validates the card.</summary>
        /// <param name="cardId">Card identifier.</param>
        /// <returns>Card instance returned from API.</returns>
        public async Task<CardDTO> ValidateAsync(string cardId)
        {
            return await this.GetObjectAsync<CardDTO>(MethodKey.CardValidate, entitiesId: cardId);
        }
    }
}
