using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using RestSharp;
using System;
using System.Net;

namespace MangoPay.SDK.Core.APIs
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

        /// <summary>Creates new card registration data.</summary>
        /// <param name="cardRegistration">Card registration data object to create.</param>
        /// <returns>Card registration object returned from API.</returns>
        public CardRegistrationDataDTO RegisterCardData(CardRegistrationDataPostDTO cardRegistrationData)
        {
            var client = new RestClient(cardRegistrationData.CardRegistrationURL);

            var request = new RestRequest(Method.POST);
            request.AddParameter(Constants.DATA, cardRegistrationData.PreregistrationData);
            request.AddParameter(Constants.ACCESS_KEY_REF, cardRegistrationData.AccessKey);
            request.AddParameter(Constants.CARD_NUMBER, cardRegistrationData.CardNumber);
            request.AddParameter(Constants.CARD_EXPIRATION_DATE, cardRegistrationData.CardExpirationDate);
            request.AddParameter(Constants.CARD_CVX, cardRegistrationData.CardCvx);

            var response = client.Execute(request);

            var responseString = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var cardRegistrationDataDTO = new CardRegistrationDataDTO
                {
                    RegistrationData = responseString
                };
                return cardRegistrationDataDTO;
            }
            else
                throw new Exception(responseString);
        }
    }
}
