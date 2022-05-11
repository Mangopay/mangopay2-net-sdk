using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for reports.</summary>
    public class ApiReports : ApiBase
    {
        /// <summary>Instantiates new ApiReports object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiReports(MangoPayApi root) : base(root) { }

        /// <summary>Creates new report request.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="reportRequest">Report request instance to be created.</param>
        /// <returns>Report request instance returned from API.</returns>
        public async Task<ReportRequestDTO> CreateAsync(ReportRequestPostDTO reportRequest, string idempotentKey = null)
        {
            if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

            var reportRequestTransport = ReportRequestTransportPostDTO.CreateFromBusinessObject(reportRequest);

            var reportRequestTransportDto = await this.CreateObjectAsync<ReportRequestTransportDTO, ReportRequestTransportPostDTO>(MethodKey.ReportRequest, reportRequestTransport, idempotentKey, reportRequestTransport.ReportType.ToString().ToLower());

            return reportRequestTransportDto.GetBusinessObject();
        }

        /// <summary>Gets report request.</summary>
        /// <param name="reportId">Report request identifier.</param>
        /// <returns>Report request instance returned from API.</returns>
        public async Task<ReportRequestDTO> GetAsync(string reportId)
        {
            var reportRequestTransportDto = await this.GetObjectAsync<ReportRequestTransportDTO>(MethodKey.ReportGet, entitiesId: reportId);

            return reportRequestTransportDto.GetBusinessObject();
        }

        /// <summary>Gets all report requests.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <param name="filters">Filters.</param>
        /// <returns>List of ReportRequest instances returned from API.</returns>
        public async Task<ListPaginated<ReportRequestDTO>> GetAllAsync(Pagination pagination = null, FilterReportsList filters = null, Sort sort = null)
        {
            if (filters == null) filters = new FilterReportsList();

            var resultTransport = await this.GetListAsync<ReportRequestTransportDTO>(MethodKey.ReportGetAll, pagination, sort, filters.GetValues());

            var result = new List<ReportRequestDTO>();
            foreach (ReportRequestTransportDTO item in resultTransport)
            {
                result.Add(item.GetBusinessObject());
            }

            return new ListPaginated<ReportRequestDTO>(result, resultTransport.TotalPages, resultTransport.TotalItems);
        }
    }
}
