using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for card registrations.</summary>
    public class ApiCardRegistrations : ApiBase
    {
        /// <summary>Instantiates new ApiCardRegistration object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiCardRegistrations(MangoPayApi root) : base(root) { }

        /// <summary>Creates new card registration.</summary>
        /// <param name="cardRegistration">Card registration object to create.</param>
        /// <returns>Card registration object returned from API.</returns>
        public CardRegistration Create(CardRegistration cardRegistration)
        {
            return this.CreateObject<CardRegistration>("cardregistration_create", cardRegistration);
        }

        /// <summary>Gets card registration.</summary>
        /// <param name="cardRegistrationId">Card registration identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardRegistration Get(String cardRegistrationId)
        {
            return this.GetObject<CardRegistration>("cardregistration_get", cardRegistrationId);
        }

        /// <summary>Updates card registration.</summary>
        /// <param name="cardRegistration">Card registration instance to be updated.</param>
        /// <returns>Card registration object returned from API.</returns>
        public CardRegistration Update(CardRegistration cardRegistration)
        {
            return this.UpdateObject<CardRegistration>("cardregistration_save", cardRegistration);
        }
    }
}
