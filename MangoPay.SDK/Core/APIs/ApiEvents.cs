using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for events.</summary>
    public class ApiEvents : ApiBase
    {
        /// <summary>Instantiates new ApiEvents object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiEvents(MangoPayApi root) : base(root) { }

        /// <summary>Gets events.</summary>
		/// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filters for events.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of events matching passed filter criteria.</returns>
        public async Task<ListPaginated<EventDTO>> GetAll(Pagination pagination, FilterEvents filter = null, Sort sort = null)
        {
            if (filter == null)
            {
                return await this.GetList<EventDTO>(MethodKey.EventsAll, pagination);
            }

            return await this.GetList<EventDTO>(MethodKey.EventsAll, pagination, sort, filter.GetValues());
        }
    }
}
