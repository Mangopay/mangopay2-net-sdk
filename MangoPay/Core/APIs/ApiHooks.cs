using MangoPay.Entities;
using System;
using System.Collections.Generic;

namespace MangoPay.Core
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
        /// <returns>List of Hook instances returned from API.</returns>
        public List<HookDTO> GetAll(Pagination pagination)
        {
            return this.GetList<HookDTO>(MethodKey.HooksAll, pagination);
        }

        /// <summary>Gets all hooks.</summary>
        /// <returns>List of Hook instances returned from API.</returns>
        public List<HookDTO> GetAll()
        {
            return this.GetAll(null);
        }
    }
}
