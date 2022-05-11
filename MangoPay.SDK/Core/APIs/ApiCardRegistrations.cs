using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for card registrations.</summary>
    public class ApiCardRegistrations : ApiBase
    {
        /// <summary>Instantiates new ApiCardRegistration object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiCardRegistrations(MangoPayApi root) : base(root) { }

        /// <summary>Creates new card registration.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="cardRegistration">Card registration object to create.</param>
        /// <returns>Card registration object returned from API.</returns>
        public async Task<CardRegistrationDTO> CreateAsync(CardRegistrationPostDTO cardRegistration, string idempotentKey = null)
        {
            return await 
                this.CreateObjectAsync<CardRegistrationDTO, CardRegistrationPostDTO>(MethodKey.CardRegistrationCreate, cardRegistration, idempotentKey);
        }

        /// <summary>Gets card registration.</summary>
        /// <param name="cardRegistrationId">Card registration identifier.</param>
        /// <returns>Card registration instance returned from API.</returns>
        public async Task<CardRegistrationDTO> GetAsync(string cardRegistrationId)
        {
            return await this.GetObjectAsync<CardRegistrationDTO>(MethodKey.CardRegistrationGet, entitiesId: cardRegistrationId);
        }

        /// <summary>Updates card registration.</summary>
        /// <param name="cardRegistration">Card registration instance to be updated.</param>
        /// <param name="cardRegistrationId">Card registration identifier.</param>
        /// <returns>Card registration object returned from API.</returns>
        public async Task<CardRegistrationDTO> UpdateAsync(CardRegistrationPutDTO cardRegistration, string cardRegistrationId)
        {
            return await this.UpdateObjectAsync<CardRegistrationDTO, CardRegistrationPutDTO>(MethodKey.CardRegistrationSave, cardRegistration, entitiesId: cardRegistrationId);
        }
    }
}
