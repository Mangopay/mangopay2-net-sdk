using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    public class ApiPermissionGroups : ApiBase
    {
        /// <summary>Instantiates new ApiPermissionGroups object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiPermissionGroups(MangoPayApi root) : base(root) { }

        /// <summary>Gets permission group by ID.</summary>
        /// <param name="permissionGroupId">Permission group identifier.</param>
        /// <returns>Permission group instance returned from API.</returns>
        public async Task<PermissionGroupDTO> GetAsync(string permissionGroupId)
        {
            return await this.GetObjectAsync<PermissionGroupDTO>(MethodKey.PermissionGroupGet, permissionGroupId);
        }

        /// <summary>Creates new permission group.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="permissionGroup">Permission group object to be created.</param>
        /// <returns>Permission group instance returned from API.</returns>
        public async Task<PermissionGroupDTO> CreateAsync(PermissionGroupPostDTO permissionGroup, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PermissionGroupDTO, PermissionGroupPostDTO>(MethodKey.PermissionGroupCreate, permissionGroup, idempotentKey);
        }

        /// <summary>Gets permission groups.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of permission group instances.</returns>
        public async Task<ListPaginated<PermissionGroupDTO>> GetAllAsync(Pagination pagination = null, Sort sort = null)
        {
            return await this.GetListAsync<PermissionGroupDTO>(MethodKey.PermissionGroupAll, pagination, sort);
        }

        /// <summary>Gets SSOs for a permission group.</summary>
        /// <param name="permissionGroupId">Permission group identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of permission group instances.</returns>
        public async Task<ListPaginated<SingleSignOnDTO>> GetSingleSignOnsAsync(string permissionGroupId, Pagination pagination, Sort sort = null)
        {
            return await this.GetListAsync<SingleSignOnDTO>(MethodKey.PermissionGroupAllSsos, pagination, sort, entitiesId: permissionGroupId);
        }

        /// <summary>Updates the permission group.</summary>
        /// <param name="permissionGroup">Instance of permission group class to be updated.</param>
        /// <param name="permissionGroupId">Permission group user identifier.</param>
        /// <returns>Updated permission group object returned from API.</returns>
        public async Task<PermissionGroupDTO> UpdateAsync(PermissionGroupPutDTO permissionGroup, string permissionGroupId)
        {
            return await this.UpdateObjectAsync<PermissionGroupDTO, PermissionGroupPutDTO>(MethodKey.PermissionGroupSave, permissionGroup, entitiesId: permissionGroupId);
        }
    }
}
