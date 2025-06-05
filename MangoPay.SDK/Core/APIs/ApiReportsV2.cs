using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for reports V2 (2025).</summary>
    public class ApiReportsV2 : ApiBase
    {
        /// <summary>Instantiates new ApiReportsV2 object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiReportsV2(MangoPayApi root) : base(root)
        {
        }

        /// <summary>Creates new report.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="report">Report instance to be created.</param>
        /// <returns>Report instance returned from API.</returns>
        public async Task<ReportDTO> CreateAsync(ReportPostDTO report, string idempotentKey = null)
        {
            return await CreateObjectAsync<ReportDTO, ReportPostDTO>(MethodKey.ReportCreate, report, idempotentKey);
        }

        /// <summary>Gets report.</summary>
        /// <param name="reportId">Report identifier.</param>
        /// <returns>Report instance returned from API.</returns>
        public async Task<ReportDTO> GetAsync(string reportId)
        {
            return await GetObjectAsync<ReportDTO>(MethodKey.ReportGetV2, entitiesId: reportId);
        }

        /// <summary>Gets all reports.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <param name="filters">Filters.</param>
        /// <returns>List of Report instances returned from API.</returns>
        public async Task<ListPaginated<ReportDTO>> GetAllAsync(Pagination pagination = null,
            FilterReportsListV2 filters = null, Sort sort = null)
        {
            if (filters == null) filters = new FilterReportsListV2();
            return await GetListAsync<ReportDTO>(MethodKey.ReportGetAllV2, pagination, sort, filters.GetValues());
        }
    }
}