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
		public async Task<ReportRequestDTO> CreateAsync(ReportRequestPostDTO reportRequest)
        {
			if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

			return await CreateAsync(null, reportRequest);
        }

		/// <summary>Creates new report request.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="hook">Report request instance to be created.</param>
		/// <returns>Report request instance returned from API.</returns>
		public async Task<ReportRequestDTO> CreateAsync(String idempotencyKey, ReportRequestPostDTO reportRequest)
		{
			if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

			var reportRequestTransport = ReportRequestTransportPostDTO.CreateFromBusinessObject(reportRequest);

			var reportRequestTransportDTO = await this.CreateObjectAsync<ReportRequestTransportDTO, ReportRequestTransportPostDTO>(idempotencyKey, MethodKey.ReportRequest, reportRequestTransport, reportRequestTransport.ReportType.ToString().ToLower());

            return reportRequestTransportDTO.GetBusinessObject();
        }

		/// <summary>Gets report request.</summary>
		/// <param name="hookId">Report request identifier.</param>
		/// <returns>Report request instance returned from API.</returns>
		public async Task<ReportRequestDTO> GetAsync(String reportId)
        {
            var reportRequestTransportDTO = await this.GetObjectAsync<ReportRequestTransportDTO>(MethodKey.ReportGet, reportId);

            return reportRequestTransportDTO.GetBusinessObject();
        }

		/// <summary>Gets all report requests.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
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

        /// <summary>Creates new report request.</summary>
        /// <param name="hook">Report request instance to be created.</param>
        /// <returns>Report request instance returned from API.</returns>
        public ReportRequestDTO Create(ReportRequestPostDTO reportRequest)
        {
            if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

            return Create(null, reportRequest);
        }

        /// <summary>Creates new report request.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="hook">Report request instance to be created.</param>
        /// <returns>Report request instance returned from API.</returns>
        public ReportRequestDTO Create(String idempotencyKey, ReportRequestPostDTO reportRequest)
        {
            if (!reportRequest.ReportType.HasValue) reportRequest.ReportType = ReportType.TRANSACTIONS;

            var reportRequestTransport = ReportRequestTransportPostDTO.CreateFromBusinessObject(reportRequest);

            var reportRequestTransportDTO = this.CreateObject<ReportRequestTransportDTO, ReportRequestTransportPostDTO>(idempotencyKey, MethodKey.ReportRequest, reportRequestTransport, reportRequestTransport.ReportType.ToString().ToLower());

            return reportRequestTransportDTO.GetBusinessObject();
        }

        /// <summary>Gets report request.</summary>
        /// <param name="hookId">Report request identifier.</param>
        /// <returns>Report request instance returned from API.</returns>
        public ReportRequestDTO Get(String reportId)
        {
            var reportRequestTransportDTO = this.GetObject<ReportRequestTransportDTO>(MethodKey.ReportGet, reportId);

            return reportRequestTransportDTO.GetBusinessObject();
        }

        /// <summary>Gets all report requests.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of ReportRequest instances returned from API.</returns>
        public ListPaginated<ReportRequestDTO> GetAll(Pagination pagination = null, FilterReportsList filters = null, Sort sort = null)
        {
            if (filters == null) filters = new FilterReportsList();

            var resultTransport = this.GetList<ReportRequestTransportDTO>(MethodKey.ReportGetAll, pagination, sort, filters.GetValues());

            var result = new List<ReportRequestDTO>();
            foreach (ReportRequestTransportDTO item in resultTransport)
            {
                result.Add(item.GetBusinessObject());
            }

            return new ListPaginated<ReportRequestDTO>(result, resultTransport.TotalPages, resultTransport.TotalItems);
        }
    }
}
