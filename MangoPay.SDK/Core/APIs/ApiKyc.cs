using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Threading.Tasks;

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
        public async Task<ListPaginated<KycDocumentDTO>> GetKycDocumentsAsync(Pagination pagination, FilterKycDocuments filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterKycDocuments();

            return await this.GetListAsync<KycDocumentDTO>(MethodKey.ClientGetKycDocuments, pagination, sort, filter.GetValues());
        }

        /// <summary>Gets KYC document.</summary>
		/// <param name="kycDocumentId">KYC document identifier.</param>
		/// <returns>KYC document instance returned from API.</returns>
        public async Task<KycDocumentDTO> GetAsync(string kycDocumentId)
        {
            return await this.GetObjectAsync<KycDocumentDTO>(MethodKey.GetKycDocument, entitiesId: kycDocumentId);
        }

        /// <summary>
        /// Get consultation for all KYC documents or a Dispute document 
        /// </summary>
        /// <param name="kycDocumentId">KYC document identifier.</param>
        /// <returns>Document consultation list</returns>
        public async Task<ListPaginated<DocumentConsultationDTO>> GetDocumentConsultationsAsync(string kycDocumentId)
        {
            return await this.GetListAsync<DocumentConsultationDTO>(MethodKey.KycDocumentConsult, entitiesId: kycDocumentId);
        }
    }
}
