using System;
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
        /// <returns>Card registration instance returned from API.</returns>
        public CardPreAuthorizationDTO Create(CardPreAuthorizationPostDTO cardPreAuthorization)
        {
            return Create(null, cardPreAuthorization);
        }

        /// <summary>Creates new pre-authorization object.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="cardPreAuthorization">PreAuthorization object to be created.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardPreAuthorizationDTO Create(String idempotencyKey, CardPreAuthorizationPostDTO cardPreAuthorization)
        {
            return this.CreateObject<CardPreAuthorizationDTO, CardPreAuthorizationPostDTO>(idempotencyKey, MethodKey.PreauthorizationCreate, cardPreAuthorization);
        }

        /// <summary>Gets pre-authorization object.</summary>
        /// <param name="cardPreAuthorizationId">PreAuthorization identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardPreAuthorizationDTO Get(String cardPreAuthorizationId)
        {
            return this.GetObject<CardPreAuthorizationDTO>(MethodKey.PreauthorizationGet, cardPreAuthorizationId);
        }

        /// <summary>Updates pre-authorization object.</summary>
        /// <param name="cardPreAuthorization">PreAuthorization object to be updated.</param>
        /// <param name="cardPreAuthorizationId">PreAuthorization object identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardPreAuthorizationDTO Update(CardPreAuthorizationPutDTO cardPreAuthorization, String cardPreAuthorizationId)
        {
            return this.UpdateObject<CardPreAuthorizationDTO, CardPreAuthorizationPutDTO>(MethodKey.PreauthorizationSave, cardPreAuthorization, cardPreAuthorizationId);
        }

        /// <summary>Lists PreAuthorizations for a user</summary>
        /// <param name="userId">Id of the user to get PreAuthorizations for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of PreAuthorizations for a user</returns>
        public ListPaginated<CardPreAuthorizationDTO> GetPreAuthorizationsForUser(String userId, Pagination pagination, FilterPreAuthorizations filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterPreAuthorizations();

            return GetList<CardPreAuthorizationDTO>(MethodKey.UsersPreauthorizations, pagination, sort, filters.GetValues(),userId);
        }

        /// <summary>Lists PreAuthorizations for a card</summary>
        /// <param name="cardId">Id of the card to get PreAuthorizations for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of PreAuthorizations for a card</returns>
        public ListPaginated<CardPreAuthorizationDTO> GetPreAuthorizationsForCard(String cardId, Pagination pagination, FilterPreAuthorizations filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterPreAuthorizations();

            return GetList<CardPreAuthorizationDTO>(MethodKey.CardPreauthorizations, pagination, sort, filters.GetValues(), cardId);
        }
    }
}