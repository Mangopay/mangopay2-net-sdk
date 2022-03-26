using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for single sign on users.</summary>
    public class ApiSingleSignOns : ApiBase
    {
        /// <summary>Instantiates new ApiSingleSignOns object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiSingleSignOns(MangoPayApi root) : base(root) { }

        /// <summary>Gets single sign on user, async.</summary>
        /// <param name="singleSignOnId">Single sign on user identifier.</param>
        /// <returns>Single sign on user instance returned from API.</returns>
        public async Task<SingleSignOnDTO> GetAsync(string singleSignOnId)
        {
            return await this.GetObjectAsync<SingleSignOnDTO>(MethodKey.SingleSignOnGet, singleSignOnId);
        }

        /// <summary>Creates new user, async.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="singleSignOn">SingleSignOn object to be created.</param>
        /// <returns>UserNatural instance returned from API.</returns>
        public async Task<SingleSignOnDTO> CreateAsync(SingleSignOnPostDTO singleSignOn, string idempotentKey)
        {
            return await this.CreateObjectAsync<SingleSignOnDTO, SingleSignOnPostDTO>(MethodKey.SingleSignOnCreate, singleSignOn, idempotentKey);
        }

        /// <summary>Gets single sign on users, async.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of single sign on user instances.</returns>
        public async Task<ListPaginated<SingleSignOnDTO>> GetAllAsync(Pagination pagination = null, Sort sort = null)
        {
            return await this.GetListAsync<SingleSignOnDTO>(MethodKey.SingleSignOnAll, pagination, sort);
        }

        /// <summary>Updates the single sign on user, async.</summary>
        /// <param name="singleSignOn">Instance of single sign on class to be updated.</param>
        /// <param name="singleSignOnId">Single sign on user identifier.</param>
        /// <returns>Updated single sign on user object returned from API.</returns>
        public async Task<SingleSignOnDTO> UpdateAsync(SingleSignOnPutDTO singleSignOn, string singleSignOnId)
        {
            return await this.UpdateObjectAsync<SingleSignOnDTO, SingleSignOnPutDTO>(MethodKey.SingleSignOnSave, singleSignOn, entitiesId: singleSignOnId);
        }

        /// <summary>Extend single sign on invitation, async.</summary>
        /// <param name="singleSignOnId">Single sign on user identifier.</param>
        /// <returns>Single sign on user object returned from API.</returns>
        public async Task<SingleSignOnDTO> ExtendInvitationAsync(string singleSignOnId)
        {
            return await this.UpdateObjectAsync<SingleSignOnDTO, SingleSignOnPutDTO>(MethodKey.SingleSignOnExtendInvitation, new SingleSignOnPutDTO(), entitiesId: singleSignOnId);
        }

        /// <summary>Gets single sign on for the current user, async.</summary>
        /// <returns>Single sign on user instance returned from API.</returns>
        /// <remarks>Requires an API token associated with an SSO based authorization</remarks>
        public async Task<SingleSignOnDTO> GetSsoForCurrentUserAsync()
        {
            return await this.GetObjectAsync<SingleSignOnDTO>(MethodKey.SingleSignOnsMe);
        }

        /// <summary>Gets permission group for the current user, async.</summary>
        /// <returns>Instance of permission group returned from API.</returns>
        /// <remarks>Requires an API token associated with an SSO based authorization</remarks>
        public async Task<PermissionGroupDTO> GetPermissionGroupForCurrentUserAsync()
        {
            return await this.GetObjectAsync<PermissionGroupDTO>(MethodKey.SingleSignOnsMePermissionGroup);
        }
    }
}
