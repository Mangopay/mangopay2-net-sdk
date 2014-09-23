using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;

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
            return this.CreateObject<CardPreAuthorizationDTO, CardPreAuthorizationPostDTO>(MethodKey.PreauthorizationCreate, cardPreAuthorization);
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
    }
}
