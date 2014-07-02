using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Hook Create(Hook hook)
        {
            return this.CreateObject<Hook>("hooks_create", hook);
        }

        /// <summary>Gets hook.</summary>
        /// <param name="hookId">Hook identifier.</param>
        /// <returns>Hook instance returned from API.</returns>
        public Hook Get(String hookId)
        {
            return this.GetObject<Hook>("hooks_get", hookId);
        }

        /// <summary>Saves a hook.</summary>
        /// <param name="hook">Hook instance to save.</param>
        /// <returns>Hook instance returned from API.</returns>
        public Hook Update(Hook hook)
        {
            return this.UpdateObject<Hook>("hooks_save", hook);
        }

        /// <summary>Gets all hooks.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <returns>List of Hook instances returned from API.</returns>
        public List<Hook> GetAll(Pagination pagination)
        {
            return this.GetList<Hook>("hooks_all", pagination);
        }

        /// <summary>Gets all hooks.</summary>
        /// <returns>List of Hook instances returned from API.</returns>
        public List<Hook> GetAll()
        {
            return this.GetAll(null);
        }
    }
}
