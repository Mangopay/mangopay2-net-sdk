using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for identity verification.</summary>
    public class ApiIdentityVerifications : ApiBase
    {
        /// <summary>Instantiates new ApiIdentityVerification object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiIdentityVerifications(MangoPayApi root) : base(root)
        {
        }

        /// <summary>Creates new identity verification.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="identityVerification">Object instance to be created.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IdentityVerificationDTO> CreateAsync(IdentityVerificationPostDto identityVerification,
            string userId, string idempotentKey = null)
        {
            return await CreateObjectAsync<IdentityVerificationDTO, IdentityVerificationPostDto>(
                MethodKey.IdentityVerificationCreate, identityVerification,
                idempotentKey, userId);
        }

        /// <summary>Get an identity verification.</summary>
        /// <param name="identityVerificationId">Identity verification identitifer.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IdentityVerificationDTO> GetAsync(string identityVerificationId)
        {
            return await this.GetObjectAsync<IdentityVerificationDTO>(MethodKey.IdentityVerificationGet,
                entitiesId: identityVerificationId);
        }
    }
}