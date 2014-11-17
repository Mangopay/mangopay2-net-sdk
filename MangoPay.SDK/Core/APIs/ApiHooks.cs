using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;

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
        public HookDTO Create(HookPostDTO hook)
        {
            return this.CreateObject<HookDTO, HookPostDTO>(MethodKey.HooksCreate, hook);
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
