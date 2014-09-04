using MangoPay.Entities;
using System;

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
        public CardRegistrationDTO Create(CardRegistrationPostDTO cardRegistration)
        {
            return this.CreateObject<CardRegistrationDTO, CardRegistrationPostDTO>(MethodKey.CardRegistrationCreate, cardRegistration);
        }

        /// <summary>Gets card registration.</summary>
        /// <param name="cardRegistrationId">Card registration identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public CardRegistrationDTO Get(String cardRegistrationId)
        {
            return this.GetObject<CardRegistrationDTO>(MethodKey.CardRegistrationGet, cardRegistrationId);
        }

        /// <summary>Updates card registration.</summary>
        /// <param name="cardRegistration">Card registration instance to be updated.</param>
        /// <param name="cardRegistrationId">Card registration identifier.</param>
        /// <returns>Card registration object returned from API.</returns>
        public CardRegistrationDTO Update(CardRegistrationPutDTO cardRegistration, String cardRegistrationId)
        {
            return this.UpdateObject<CardRegistrationDTO, CardRegistrationPutDTO>(MethodKey.CardRegistrationSave, cardRegistration, cardRegistrationId);
        }
    }
}
