using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for events.</summary>
    public class ApiEvents : ApiBase
    {
        /// <summary>Instantiates new ApiEvents object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiEvents(MangoPayApi root) : base(root) { }

        /// <summary>Gets events.</summary>
        /// <param name="filter">Filters for events.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>List of events matching passed filter criteria.</returns>
        public List<Event> Get(FilterEvents filter, Pagination pagination)
        {
            return this.GetList<Event>("events_all", pagination, "", filter.GetValues());
        }
    }
}
