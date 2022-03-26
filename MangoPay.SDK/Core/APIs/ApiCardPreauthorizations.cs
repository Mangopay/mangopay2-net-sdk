using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for card pre-authorizations.</summary>
    public class ApiCardPreAuthorizations : ApiBase
    {
        /// <summary>Instantiates new ApiCardPreAuthorizations object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiCardPreAuthorizations(MangoPayApi root) : base(root) { }

        /// <summary>Creates new pre-authorization object.</summary>
        /// <param name="cardPreAuthorization">PreAuthorization object to be created.</param>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public async Task<CardPreAuthorizationDTO> CreateAsync(CardPreAuthorizationPostDTO cardPreAuthorization, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<CardPreAuthorizationDTO, CardPreAuthorizationPostDTO>(MethodKey.PreauthorizationCreate, cardPreAuthorization, idempotentKey);
        }

        /// <summary>Gets pre-authorization object.</summary>
        /// <param name="cardPreAuthorizationId">PreAuthorization identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public async Task<CardPreAuthorizationDTO> GetAsync(string cardPreAuthorizationId)
        {
            return await this.GetObjectAsync<CardPreAuthorizationDTO>(MethodKey.PreauthorizationGet, entitiesId: cardPreAuthorizationId);
        }

        /// <summary>Gets pre-authorization object.</summary>
        /// <param name="cardPreAuthorizationId">PreAuthorization identifier.</param>
        /// <param name="pagination">Pagination</param>
        /// <returns>Card registration instance returned from API.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(string cardPreAuthorizationId, Pagination pagination)
        {
            return await this.GetListAsync<TransactionDTO>(MethodKey.PreauthorizationTransactionsGet, pagination, entitiesId: cardPreAuthorizationId);
        }

        /// <summary>Updates pre-authorization object.</summary>
        /// <param name="cardPreAuthorization">PreAuthorization object to be updated.</param>
        /// <param name="cardPreAuthorizationId">PreAuthorization object identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public async Task<CardPreAuthorizationDTO> UpdateAsync(CardPreAuthorizationPutDTO cardPreAuthorization, string cardPreAuthorizationId)
        {
            return await this.UpdateObjectAsync<CardPreAuthorizationDTO, CardPreAuthorizationPutDTO>(MethodKey.PreauthorizationSave, cardPreAuthorization, entitiesId: cardPreAuthorizationId);
        }

        /// <summary>Lists PreAuthorizations for a user</summary>
        /// <param name="userId">Id of the user to get PreAuthorizations for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of PreAuthorizations for a user</returns>
        public async Task<ListPaginated<CardPreAuthorizationDTO>> GetPreAuthorizationsForUserAsync(string userId, Pagination pagination, FilterPreAuthorizations filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterPreAuthorizations();

            return await GetListAsync<CardPreAuthorizationDTO>(MethodKey.UsersPreauthorizations, pagination, sort, filters.GetValues(), entitiesId: userId);
        }

        /// <summary>Lists PreAuthorizations for a card</summary>
        /// <param name="cardId">Id of the card to get PreAuthorizations for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of PreAuthorizations for a card</returns>
        public async Task<ListPaginated<CardPreAuthorizationDTO>> GetPreAuthorizationsForCardAsync(string cardId, Pagination pagination, FilterPreAuthorizations filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterPreAuthorizations();

            return await GetListAsync<CardPreAuthorizationDTO>(MethodKey.CardPreauthorizations, pagination, sort, filters.GetValues(), entitiesId: cardId);
        }
    }
}