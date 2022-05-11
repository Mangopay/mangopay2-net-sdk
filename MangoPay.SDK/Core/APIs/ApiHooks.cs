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
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="hook">Hook instance to be created.</param>
        /// <returns>Hook instance returned from API.</returns>
        public async Task<HookDTO> CreateAsync(HookPostDTO hook, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<HookDTO, HookPostDTO>(MethodKey.HooksCreate, hook, idempotentKey);
        }

        /// <summary>Gets hook.</summary>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public async Task<HookDTO> GetAsync(string hookId)
        {
            return await this.GetObjectAsync<HookDTO>(MethodKey.HooksGet, entitiesId: hookId);
        }

        /// <summary>Saves a hook.</summary>
        /// <param name="hook">Hook instance to save.</param>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public async Task<HookDTO> UpdateAsync(HookPutDTO hook, string hookId)
        {
            return await this.UpdateObjectAsync<HookDTO, HookPutDTO>(MethodKey.HooksSave, hook, entitiesId: hookId);
        }

        /// <summary>Gets all hooks.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Hook instances returned from API.</returns>
        public async Task<ListPaginated<HookDTO>> GetAllAsync(Pagination pagination = null, Sort sort = null)
        {
            return await this.GetListAsync<HookDTO>(MethodKey.HooksAll, pagination, sort);
        }
    }
}
