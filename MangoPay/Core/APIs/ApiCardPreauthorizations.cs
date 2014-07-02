using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
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
        public CardPreAuthorization Create(CardPreAuthorization cardPreAuthorization)
        {
            return this.CreateObject<CardPreAuthorization>("preauthorization_create", cardPreAuthorization);
        }

        /// <summary>Gets pre-authorization object.</summary>
        /// <param name="cardPreAuthorizationId">PreAuthorization identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardPreAuthorization Get(String cardPreAuthorizationId)
        {
            return this.GetObject<CardPreAuthorization>("preauthorization_get", cardPreAuthorizationId);
        }

        /// <summary>Updates pre-authorization object.</summary>
        /// <param name="cardPreAuthorization">PreAuthorization object to be updated.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardPreAuthorization Update(CardPreAuthorization cardPreAuthorization)
        {
            return this.UpdateObject<CardPreAuthorization>("preauthorization_save", cardPreAuthorization);
        }
    }
}
