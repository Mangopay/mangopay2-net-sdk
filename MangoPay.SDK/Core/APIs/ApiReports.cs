using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.Transport;
using System;
using System.Collections.Generic;

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

			ReportRequestTransportPostDTO reportRequestTransport = ReportRequestTransportPostDTO.CreateFromBusinessObject(reportRequest);

			return this.CreateObject<ReportRequestTransportDTO, ReportRequestTransportPostDTO>(idempotencyKey, MethodKey.ReportRequest, reportRequestTransport, reportRequestTransport.ReportType.ToString().ToLower()).GetBusinessObject();
		}

		/// <summary>Gets report request.</summary>
		/// <param name="hookId">Report request identifier.</param>
		/// <returns>Report request instance returned from API.</returns>
		public ReportRequestDTO Get(String reportId)
        {
			return this.GetObject<ReportRequestTransportDTO>(MethodKey.ReportGet, reportId).GetBusinessObject();
        }

		/// <summary>Gets all report requests.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
		/// <returns>List of ReportRequest instances returned from API.</returns>
		public ListPaginated<ReportRequestDTO> GetAll(Pagination pagination, FilterReportsList filters = null, Sort sort = null)
        {
			if (filters == null) filters = new FilterReportsList();

			ListPaginated<ReportRequestTransportDTO> resultTransport = this.GetList<ReportRequestTransportDTO>(MethodKey.ReportGetAll, pagination, null, sort, filters.GetValues());

			List<ReportRequestDTO> result = new List<ReportRequestDTO>();
			foreach (ReportRequestTransportDTO item in resultTransport)
			{
				result.Add(item.GetBusinessObject());
			}

			ListPaginated<ReportRequestDTO> resultPaginated = new ListPaginated<ReportRequestDTO>(result, resultTransport.TotalPages, resultTransport.TotalItems);
			return resultPaginated;
        }

        /// <summary>Gets all report requests.</summary>
        /// <returns>List of ReportRequest instances returned from API.</returns>
		public ListPaginated<ReportRequestDTO> GetAll()
        {
            return this.GetAll(null);
        }
    }
}
