using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
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

        /// <summary>See the status and basic details of an identity verification session</summary>
        /// <param name="id">Identity verification identitifer.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IdentityVerificationDTO> GetAsync(string id)
        {
            return await this.GetObjectAsync<IdentityVerificationDTO>(MethodKey.IdentityVerificationGet,
                entitiesId: id);
        }
        
        /// <summary>Get all identity verifications for a user</summary>
        /// <param name="userId">User identitifer.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List returned from API.</returns>
        public async Task<ListPaginated<IdentityVerificationDTO>> GetAllAsync(string userId, Pagination pagination = null,
            Sort sort = null)
        {
            return await this.GetListAsync<IdentityVerificationDTO>(MethodKey.IdentityVerificationGetAll,
                entitiesId: userId, pagination: pagination, sort: sort);
        }
    }
}