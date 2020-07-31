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
		/// <param name="hook">Report request instance to be created.</param>
		/// <returns>Report request instance returned from API.</returns>
		public async Task<ReportRequestDTO> Create(ReportRequestPostDTO reportRequest)
        {
			if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

			return await Create(null, reportRequest);
        }

		/// <summary>Creates new report request.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="hook">Report request instance to be created.</param>
		/// <returns>Report request instance returned from API.</returns>
		public async Task<ReportRequestDTO> Create(String idempotencyKey, ReportRequestPostDTO reportRequest)
		{
			if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

			var reportRequestTransport = ReportRequestTransportPostDTO.CreateFromBusinessObject(reportRequest);

			var reportRequestTransportDTO = await this.CreateObject<ReportRequestTransportDTO, ReportRequestTransportPostDTO>(idempotencyKey, MethodKey.ReportRequest, reportRequestTransport, reportRequestTransport.ReportType.ToString().ToLower());

            return reportRequestTransportDTO.GetBusinessObject();
        }

		/// <summary>Gets report request.</summary>
		/// <param name="hookId">Report request identifier.</param>
		/// <returns>Report request instance returned from API.</returns>
		public async Task<ReportRequestDTO> Get(String reportId)
        {
            var reportRequestTransportDTO = await this.GetObject<ReportRequestTransportDTO>(MethodKey.ReportGet, reportId);

            return reportRequestTransportDTO.GetBusinessObject();
        }

		/// <summary>Gets all report requests.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
		/// <returns>List of ReportRequest instances returned from API.</returns>
		public async Task<ListPaginated<ReportRequestDTO>> GetAll(Pagination pagination, FilterReportsList filters = null, Sort sort = null)
        {
			if (filters == null) filters = new FilterReportsList();

			var resultTransport = await this.GetList<ReportRequestTransportDTO>(MethodKey.ReportGetAll, pagination, sort, filters.GetValues());

			var result = new List<ReportRequestDTO>();
			foreach (ReportRequestTransportDTO item in resultTransport)
			{
				result.Add(item.GetBusinessObject());
			}

            return new ListPaginated<ReportRequestDTO>(result, resultTransport.TotalPages, resultTransport.TotalItems);
        }

        /// <summary>Gets all report requests.</summary>
        /// <returns>List of ReportRequest instances returned from API.</returns>
		public async Task<ListPaginated<ReportRequestDTO>> GetAll()
        {
            return await this.GetAll(null);
        }
    }
}
