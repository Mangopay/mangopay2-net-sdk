using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using System;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for KYC documents.</summary>
    public class ApiKyc : ApiBase
    {
		/// <summary>Instantiates new ApiKyc object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
		public ApiKyc(MangoPayApi root) : base(root) { }

        /// <summary>Gets the list of all the uploaded documents for all users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of all users' uploaded documents.</returns>
        public ListPaginated<KycDocumentDTO> GetKycDocuments(Pagination pagination, FilterKycDocuments filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterKycDocuments();

            return this.GetList<KycDocumentDTO>(MethodKey.ClientGetKycDocuments, pagination, null, sort, filter.GetValues());
        }

        /// <summary>Gets KYC document.</summary>
		/// <param name="kycDocumentId">KYC document identifier.</param>
		/// <returns>KYC document instance returned from API.</returns>
        public KycDocumentDTO Get(String kycDocumentId)
        {
			return this.GetObject<KycDocumentDTO>(MethodKey.GetKycDocument, kycDocumentId);
        }

		/// <summary>
		/// Get consultation for all KYC documents or a Dispute document 
		/// </summary>
		/// <param name="kycDocumentId">KYC document identifier.</param>
		/// <returns>Document consultation list</returns>
		public ListPaginated<DocumentConsultationDTO> GetDocumentConsultations(String kycDocumentId)
		{
			var endPoint = GetApiEndPoint(MethodKey.KycDocumentConsult);
			endPoint.SetParameters(kycDocumentId);
			var rest = new RestTool(_root, true);
			return rest.RequestList<DocumentConsultationDTO>(endPoint);
		}
	}
}
