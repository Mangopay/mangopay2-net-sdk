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
		public async Task<PermissionGroupDTO> GetAsync(String permissionGroupId)
		{
			return await this.GetObjectAsync<PermissionGroupDTO>(MethodKey.PermissionGroupGet, permissionGroupId);
		}

		/// <summary>Creates new permission group.</summary>
		/// <param name="permissionGroup">Permission group object to be created.</param>
		/// <returns>Permission group instance returned from API.</returns>
		public async Task<PermissionGroupDTO> CreateAsync(PermissionGroupPostDTO permissionGroup)
		{
			return await CreateAsync(null, permissionGroup);
		}

		/// <summary>Creates new permission group.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="permissionGroup">Permission group object to be created.</param>
		/// <returns>Permission group instance returned from API.</returns>
		public async Task<PermissionGroupDTO> CreateAsync(String idempotencyKey, PermissionGroupPostDTO permissionGroup)
		{
			return await this.CreateObjectAsync<PermissionGroupDTO, PermissionGroupPostDTO>(idempotencyKey, MethodKey.PermissionGroupCreate, permissionGroup);
		}

		/// <summary>Gets permission groups.</summary>
		/// <param name="pagination">Pagination.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>Collection of permission group instances.</returns>
		public async Task<ListPaginated<PermissionGroupDTO>> GetAllAsync(Pagination pagination, Sort sort = null)
		{
			return await this.GetListAsync<PermissionGroupDTO>(MethodKey.PermissionGroupAll, pagination, sort);
		}

		/// <summary>Gets first page of permission groups.</summary>
		/// <returns>Collection of permission group instances.</returns>
		public async Task<ListPaginated<PermissionGroupDTO>> GetAllAsync()
		{
			return await GetAllAsync(null);
		}

		/// <summary>Gets SSOs for a permission group.</summary>
		/// <param name="permissionGroupId">Permission group identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>Collection of permission group instances.</returns>
		public async Task<ListPaginated<SingleSignOnDTO>> GetSingleSignOnsAsync(String permissionGroupId, Pagination pagination, Sort sort = null)
		{
			return await this.GetListAsync<SingleSignOnDTO>(MethodKey.PermissionGroupAllSsos, pagination, sort,permissionGroupId);
		}

		/// <summary>Updates the permission group.</summary>
		/// <param name="permissionGroup">Instance of permission group class to be updated.</param>
		/// <param name="permissionGroupId">Permission group user identifier.</param>
		/// <returns>Updated permission group object returned from API.</returns>
		public async Task<PermissionGroupDTO> UpdateAsync(PermissionGroupPutDTO permissionGroup, String permissionGroupId)
		{
			return await this.UpdateObjectAsync<PermissionGroupDTO, PermissionGroupPutDTO>(MethodKey.PermissionGroupSave, permissionGroup, permissionGroupId);
		}

        /// <summary>Gets permission group by ID.</summary>
        /// <param name="permissionGroupId">Permission group identifier.</param>
        /// <returns>Permission group instance returned from API.</returns>
        public PermissionGroupDTO Get(String permissionGroupId)
        {
            return this.GetObject<PermissionGroupDTO>(MethodKey.PermissionGroupGet, permissionGroupId);
        }

        /// <summary>Creates new permission group.</summary>
        /// <param name="permissionGroup">Permission group object to be created.</param>
        /// <returns>Permission group instance returned from API.</returns>
        public PermissionGroupDTO Create(PermissionGroupPostDTO permissionGroup)
        {
            return Create(null, permissionGroup);
        }

        /// <summary>Creates new permission group.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="permissionGroup">Permission group object to be created.</param>
        /// <returns>Permission group instance returned from API.</returns>
        public PermissionGroupDTO Create(String idempotencyKey, PermissionGroupPostDTO permissionGroup)
        {
            return this.CreateObject<PermissionGroupDTO, PermissionGroupPostDTO>(idempotencyKey, MethodKey.PermissionGroupCreate, permissionGroup);
        }

        /// <summary>Gets permission groups.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of permission group instances.</returns>
        public ListPaginated<PermissionGroupDTO> GetAll(Pagination pagination, Sort sort = null)
        {
            return this.GetList<PermissionGroupDTO>(MethodKey.PermissionGroupAll, pagination, sort);
        }

        /// <summary>Gets first page of permission groups.</summary>
        /// <returns>Collection of permission group instances.</returns>
        public ListPaginated<PermissionGroupDTO> GetAll()
        {
            return GetAll(null);
        }

        /// <summary>Gets SSOs for a permission group.</summary>
        /// <param name="permissionGroupId">Permission group identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of permission group instances.</returns>
        public ListPaginated<SingleSignOnDTO> GetSingleSignOns(String permissionGroupId, Pagination pagination, Sort sort = null)
        {
            return this.GetList<SingleSignOnDTO>(MethodKey.PermissionGroupAllSsos, pagination, sort, permissionGroupId);
        }

        /// <summary>Updates the permission group.</summary>
        /// <param name="permissionGroup">Instance of permission group class to be updated.</param>
        /// <param name="permissionGroupId">Permission group user identifier.</param>
        /// <returns>Updated permission group object returned from API.</returns>
        public PermissionGroupDTO Update(PermissionGroupPutDTO permissionGroup, String permissionGroupId)
        {
            return this.UpdateObject<PermissionGroupDTO, PermissionGroupPutDTO>(MethodKey.PermissionGroupSave, permissionGroup, permissionGroupId);
        }
    }
}
