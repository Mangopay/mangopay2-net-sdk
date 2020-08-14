using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for hooks.</summary>
    public class ApiHooks : ApiBase
    {
        /// <summary>Instantiates new ApiHooks object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiHooks(MangoPayApi root) : base(root) { }

        /// <summary>Creates new hook.</summary>
        /// <param name="hook">Hook instance to be created.</param>
        /// <returns>Hook instance returned from API.</returns>
        public async Task<HookDTO> CreateAsync(HookPostDTO hook)
        {
            return await CreateAsync(null, hook);
        }

		/// <summary>Creates new hook.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="hook">Hook instance to be created.</param>
		/// <returns>Hook instance returned from API.</returns>
		public async Task<HookDTO> CreateAsync(String idempotencyKey, HookPostDTO hook)
		{
			return await this.CreateObjectAsync<HookDTO, HookPostDTO>(idempotencyKey, MethodKey.HooksCreate, hook);
		}

        /// <summary>Gets hook.</summary>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public async Task<HookDTO> GetAsync(String hookId)
        {
            return await this.GetObjectAsync<HookDTO>(MethodKey.HooksGet, hookId);
        }

        /// <summary>Saves a hook.</summary>
        /// <param name="hook">Hook instance to save.</param>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public async Task<HookDTO> UpdateAsync(HookPutDTO hook, String hookId)
        {
            return await this.UpdateObjectAsync<HookDTO, HookPutDTO>(MethodKey.HooksSave, hook, hookId);
        }

        /// <summary>Gets all hooks.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Hook instances returned from API.</returns>
        public async Task<ListPaginated<HookDTO>> GetAllAsync(Pagination pagination, Sort sort = null)
        {
            return await this.GetListAsync<HookDTO>(MethodKey.HooksAll, pagination, sort);
        }

        /// <summary>Gets all hooks.</summary>
        /// <returns>List of Hook instances returned from API.</returns>
        public async Task<ListPaginated<HookDTO>> GetAllAsync()
        {
            return await this.GetAllAsync(null);
        }

        /// <summary>Creates new hook.</summary>
        /// <param name="hook">Hook instance to be created.</param>
        /// <returns>Hook instance returned from API.</returns>
        public HookDTO Create(HookPostDTO hook)
        {
            return Create(null, hook);
        }

        /// <summary>Creates new hook.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="hook">Hook instance to be created.</param>
        /// <returns>Hook instance returned from API.</returns>
        public HookDTO Create(String idempotencyKey, HookPostDTO hook)
        {
            return this.CreateObject<HookDTO, HookPostDTO>(idempotencyKey, MethodKey.HooksCreate, hook);
        }

        /// <summary>Gets hook.</summary>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public HookDTO Get(String hookId)
        {
            return this.GetObject<HookDTO>(MethodKey.HooksGet, hookId);
        }

        /// <summary>Saves a hook.</summary>
        /// <param name="hook">Hook instance to save.</param>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public HookDTO Update(HookPutDTO hook, String hookId)
        {
            return this.UpdateObject<HookDTO, HookPutDTO>(MethodKey.HooksSave, hook, hookId);
        }

        /// <summary>Gets all hooks.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Hook instances returned from API.</returns>
        public ListPaginated<HookDTO> GetAll(Pagination pagination, Sort sort = null)
        {
            return this.GetList<HookDTO>(MethodKey.HooksAll, pagination, sort);
        }

        /// <summary>Gets all hooks.</summary>
        /// <returns>List of Hook instances returned from API.</returns>
        public ListPaginated<HookDTO> GetAll()
        {
            return this.GetAll(null);
        }
    }
}
