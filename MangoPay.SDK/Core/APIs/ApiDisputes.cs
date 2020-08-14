using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for disputes.</summary>
    public class ApiDisputes : ApiBase
    {
		/// <summary>Instantiates new ApiDisputes object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
		public ApiDisputes(MangoPayApi root) : base(root) { }

		/// <summary>Gets dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute instance returned from API.</returns>
		public async Task<DisputeDTO> GetAsync(String disputeId)
		{
			return await this.GetObjectAsync<DisputeDTO>(MethodKey.DisputesGet, disputeId);
		}

		/// <summary>Gets all disputes.</summary>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of Dispute instances returned from API.</returns>
		public async Task<ListPaginated<DisputeDTO>> GetAllAsync(Pagination pagination, FilterDisputes filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterDisputes();

			return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetAll, pagination, sort, filters.GetValues());
		}

		/// <summary>Gets all disputes.</summary>
		/// <returns>List of Dispute instances returned from API.</returns>
		public async Task<ListPaginated<DisputeDTO>> GetAllAsync()
		{
			return await this.GetAllAsync(null, null);
		}

		/// <summary>Gets dispute's transactions.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of Transaction instances returned from API.</returns>
		public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(String disputeId, Pagination pagination, FilterTransactions filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterTransactions();

			return await this.GetListAsync<TransactionDTO>(MethodKey.DisputesGetTransactions, pagination,sort, filters.GetValues(), disputeId);
		}

		/// <summary>Gets dispute's documents for wallet.</summary>
		/// <param name="walletId">Wallet identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of dispute instances returned from API.</returns>
		public async Task<ListPaginated<DisputeDTO>> GetDisputesForWalletAsync(String walletId, Pagination pagination, FilterDisputes filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterDisputes();

			return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetForWallet, pagination, sort, filters.GetValues(), walletId);
		}

		/// <summary>Gets user's disputes.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of Dispute instances returned from API.</returns>
		public async Task<ListPaginated<DisputeDTO>> GetDisputesForUserAsync(String userId, Pagination pagination, FilterDisputes filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterDisputes();

			return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetForUser, pagination, sort, filters.GetValues(), userId);
		}

        /// <summary>Gets Disputes which need settling.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public async Task<ListPaginated<DisputeDTO>> GetDisputesPendingSettlementAsync(Pagination pagination, Sort sort = null)
        {
            return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetPendingSettlement, pagination, sort);
        }

		/// <summary>Gets dispute's document.</summary>
		/// <param name="documentId">Dispute's document identifier.</param>
		/// <returns>Dispute's document object returned from API.</returns>
		public async Task<DisputeDocumentDTO> GetDocumentAsync(String documentId)
		{
			return await this.GetObjectAsync<DisputeDocumentDTO>(MethodKey.DisputesDocumentGet, documentId);
		}

		/// <summary>Gets documents for dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of DisputeDocument instances returned from API.</returns>
		public async Task<ListPaginated<DisputeDocumentDTO>> GetDocumentsForDisputeAsync(String disputeId, Pagination pagination, FilterDisputeDocuments filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterDisputeDocuments();

			return await this.GetListAsync<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForDispute, pagination, sort, filters.GetValues(),disputeId);
		}

		/// <summary>Gets dispute's documents for client.</summary>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of dispute documents returned from API.</returns>
		public async Task<ListPaginated<DisputeDocumentDTO>> GetDocumentsForClientAsync(Pagination pagination, FilterDisputeDocuments filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterDisputeDocuments();

			return await this.GetListAsync<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForClient, pagination, sort, filters.GetValues());
		}

		/// <summary>Gets repudiation.</summary>
		/// <param name="repudiationId">Repudiation identifier.</param>
		/// <returns>Repudiation instance returned from API.</returns>
		public async Task<RepudiationDTO> GetRepudiationAsync(String repudiationId)
		{
			return await this.GetObjectAsync<RepudiationDTO>(MethodKey.DisputesRepudiationGet, repudiationId);
		}

		/// <summary>Creates settlement transfer.</summary>
		/// <param name="settlementTransfer">Settlement transfer.</param>
		/// <param name="repudiationId">Repudiation identifier.</param>
		/// <returns>Transfer settlement instance returned from API.</returns>
		public async Task<SettlementDTO> CreateSettlementTransferAsync(SettlementTransferPostDTO settlementTransfer, String repudiationId)
		{
			return await CreateSettlementTransferAsync(null, settlementTransfer, repudiationId);
		}

		/// <summary>Creates settlement transfer.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="settlementTransfer">Settlement transfer.</param>
		/// <param name="repudiationId">Repudiation identifier.</param>
		/// <returns>Transfer settlement instance returned from API.</returns>
		public async Task<SettlementDTO> CreateSettlementTransferAsync(String idempotencyKey, SettlementTransferPostDTO settlementTransfer, String repudiationId)
		{
			return await this.CreateObjectAsync<SettlementDTO, SettlementTransferPostDTO>(idempotencyKey, MethodKey.DisputesRepudiationCreateSettlement, settlementTransfer, repudiationId);
		}

		/// <summary>Updates dispute's tag.</summary>
		/// <param name="tag">New tag text.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute instance returned from API.</returns>
		public async Task<DisputeDTO> UpdateTagAsync(String tag, String disputeId)
		{
			DisputeTagPutDTO disputeTag = new DisputeTagPutDTO { Tag = tag };

			return await this.UpdateObjectAsync<DisputeDTO, DisputeTagPutDTO>(MethodKey.DisputesSaveTag, disputeTag, disputeId);
		}

		/// <summary>Submits dispute document.</summary>
		/// <param name="disputeDocument">Dispute document to be submitted.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="disputeDocumentId">Dispute document identifier.</param>
		/// <returns>Dispute document instance returned from API.</returns>
		public async Task<DisputeDocumentDTO> SubmitDisputeDocumentAsync(DisputeDocumentPutDTO disputeDocument, String disputeId, String disputeDocumentId)
		{
			return await this.UpdateObjectAsync<DisputeDocumentDTO, DisputeDocumentPutDTO>(MethodKey.DisputesDocumentSubmit, disputeDocument, disputeId, disputeDocumentId);
		}

		/// <summary>Contests dispute.</summary>
		/// <param name="contestedFunds">Contested funds.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute instance returned from API.</returns>
		public async Task<DisputeDTO> ContestDisputeAsync(Money contestedFunds, String disputeId)
		{
            var disputeContest = new DisputeContestPutDTO
            {
                ContestedFunds = contestedFunds
            };

            return await this.UpdateObjectAsync<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, disputeContest, disputeId);
		}

		/// <summary>Resubmits dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute instance returned from API.</returns>
		public async Task<DisputeDTO> ResubmitDisputeAsync(String disputeId)
		{
			var dispute = new DisputeContestPutDTO();
			return await this.UpdateObjectAsync<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, dispute, disputeId);
		}

		/// <summary>Closes dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute instance returned from API.</returns>
		public async Task<DisputeDTO> CloseDisputeAsync(String disputeId)
		{
			return await this.UpdateObjectAsync<DisputeDTO, EntityPutBase>(MethodKey.DisputeSaveClose, new EntityPutBase(), disputeId);
		}

		/// <summary>Creates document for dispute.</summary>
		/// <param name="disputeDocument">Dispute document to be created.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute document returned from API.</returns>
		public async Task<DisputeDocumentDTO> CreateDisputeDocumentAsync(DisputeDocumentPostDTO disputeDocument, string disputeId)
		{
			return await CreateDisputeDocumentAsync(null, disputeDocument, disputeId);
		}

		/// <summary>Creates document for dispute.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="disputeDocument">Dispute document to be created.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute document returned from API.</returns>
		public async Task<DisputeDocumentDTO> CreateDisputeDocumentAsync(String idempotencyKey, DisputeDocumentPostDTO disputeDocument, string disputeId)
		{
			return await this.CreateObjectAsync<DisputeDocumentDTO, DisputeDocumentPostDTO>(idempotencyKey, MethodKey.DisputesDocumentCreate, disputeDocument, disputeId);
		}

		/// <summary>Creates document's page for dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="documentId">Dispute document identifier.</param>
		/// <param name="filePath">Path to the file the DisputePage will be created from.</param>
		public async Task<bool> CreateDisputePageAsync(string disputeId, string documentId, string filePath)
		{
			byte[] fileArray = File.ReadAllBytes(filePath);
			return await CreateDisputePageAsync(disputeId, documentId, fileArray);
		}

		/// <summary>Creates document's page for dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="documentId">Dispute document identifier.</param>
		/// <param name="binaryData">The byte array the DisputePage will be created from.</param>
		public async Task<bool> CreateDisputePageAsync(string disputeId, string documentId, byte[] binaryData)
		{
			return await CreateDisputePageAsync(null, disputeId, documentId, binaryData);
		}

		/// <summary>Creates document's page for dispute.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="documentId">Dispute document identifier.</param>
		/// <param name="binaryData">The byte array the DisputePage will be created from.</param>
		public async Task<bool> CreateDisputePageAsync(string idempotencyKey, string disputeId, string documentId, byte[] binaryData)
		{
			var fileContent = Convert.ToBase64String(binaryData);

			var disputePage = new DisputePagePostDTO(fileContent);

			var result = await this.CreateObjectAsync<DisputePageDTO, DisputePagePostDTO>(idempotencyKey, MethodKey.DisputesDocumentPageCreate, disputePage, disputeId, documentId);

            return result != null;
		}

		/// <summary>Gets settlement transfer.</summary>
		/// <param name="settlementId">Settlement transfer isentifier.</param>
		/// <returns>Settlement instance returned from API.</returns>
		public async Task<SettlementDTO> GetSettlementTransferAsync(string settlementId)
		{
			return await this.GetObjectAsync<SettlementDTO>(MethodKey.SettlementsGet, settlementId);
		}

		/// <summary>
		/// Get consultation for all dispute documents
		/// </summary>
		/// <param name="disputeDocumentId">Dispute document identifier.</param>
		/// <returns>Document consultation list</returns>
		public async Task<ListPaginated<DocumentConsultationDTO>> GetDocumentConsultationsAsync(String disputeDocumentId)
		{
			var endPoint = GetApiEndPoint(MethodKey.DisputesDocumentConsult);
			endPoint.SetParameters(new []{disputeDocumentId});
			var rest = new RestTool(_root, true);
			return await rest.RequestListAsync<DocumentConsultationDTO>(endPoint);
		}

        /// <summary>Gets dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public DisputeDTO Get(String disputeId)
        {
            return this.GetObject<DisputeDTO>(MethodKey.DisputesGet, disputeId);
        }

        /// <summary>Gets all disputes.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public ListPaginated<DisputeDTO> GetAll(Pagination pagination, FilterDisputes filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return this.GetList<DisputeDTO>(MethodKey.DisputesGetAll, pagination, sort, filters.GetValues());
        }

        /// <summary>Gets all disputes.</summary>
        /// <returns>List of Dispute instances returned from API.</returns>
        public ListPaginated<DisputeDTO> GetAll()
        {
            return this.GetAll(null, null);
        }

        /// <summary>Gets dispute's transactions.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Transaction instances returned from API.</returns>
        public ListPaginated<TransactionDTO> GetTransactions(String disputeId, Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return this.GetList<TransactionDTO>(MethodKey.DisputesGetTransactions, pagination, sort, filters.GetValues(), disputeId);
        }

        /// <summary>Gets dispute's documents for wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of dispute instances returned from API.</returns>
        public ListPaginated<DisputeDTO> GetDisputesForWallet(String walletId, Pagination pagination, FilterDisputes filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return this.GetList<DisputeDTO>(MethodKey.DisputesGetForWallet, pagination, sort, filters.GetValues(), walletId);
        }

        /// <summary>Gets user's disputes.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public ListPaginated<DisputeDTO> GetDisputesForUser(String userId, Pagination pagination, FilterDisputes filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return this.GetList<DisputeDTO>(MethodKey.DisputesGetForUser, pagination, sort, filters.GetValues(), userId);
        }

        /// <summary>Gets Disputes which need settling.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public ListPaginated<DisputeDTO> GetDisputesPendingSettlement(Pagination pagination, Sort sort = null)
        {
            return this.GetList<DisputeDTO>(MethodKey.DisputesGetPendingSettlement, pagination, sort);
        }

        /// <summary>Gets dispute's document.</summary>
        /// <param name="documentId">Dispute's document identifier.</param>
        /// <returns>Dispute's document object returned from API.</returns>
        public DisputeDocumentDTO GetDocument(String documentId)
        {
            return this.GetObject<DisputeDocumentDTO>(MethodKey.DisputesDocumentGet, documentId);
        }

        /// <summary>Gets documents for dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of DisputeDocument instances returned from API.</returns>
        public ListPaginated<DisputeDocumentDTO> GetDocumentsForDispute(String disputeId, Pagination pagination, FilterDisputeDocuments filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputeDocuments();

            return this.GetList<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForDispute, pagination, sort, filters.GetValues(), disputeId);
        }

        /// <summary>Gets dispute's documents for client.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of dispute documents returned from API.</returns>
        public ListPaginated<DisputeDocumentDTO> GetDocumentsForClient(Pagination pagination, FilterDisputeDocuments filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputeDocuments();

            return this.GetList<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForClient, pagination, sort, filters.GetValues());
        }

        /// <summary>Gets repudiation.</summary>
        /// <param name="repudiationId">Repudiation identifier.</param>
        /// <returns>Repudiation instance returned from API.</returns>
        public RepudiationDTO GetRepudiation(String repudiationId)
        {
            return this.GetObject<RepudiationDTO>(MethodKey.DisputesRepudiationGet, repudiationId);
        }

        /// <summary>Creates settlement transfer.</summary>
        /// <param name="settlementTransfer">Settlement transfer.</param>
        /// <param name="repudiationId">Repudiation identifier.</param>
        /// <returns>Transfer settlement instance returned from API.</returns>
        public SettlementDTO CreateSettlementTransfer(SettlementTransferPostDTO settlementTransfer, String repudiationId)
        {
            return CreateSettlementTransfer(null, settlementTransfer, repudiationId);
        }

        /// <summary>Creates settlement transfer.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="settlementTransfer">Settlement transfer.</param>
        /// <param name="repudiationId">Repudiation identifier.</param>
        /// <returns>Transfer settlement instance returned from API.</returns>
        public SettlementDTO CreateSettlementTransfer(String idempotencyKey, SettlementTransferPostDTO settlementTransfer, String repudiationId)
        {
            return this.CreateObject<SettlementDTO, SettlementTransferPostDTO>(idempotencyKey, MethodKey.DisputesRepudiationCreateSettlement, settlementTransfer, repudiationId);
        }

        /// <summary>Updates dispute's tag.</summary>
        /// <param name="tag">New tag text.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public DisputeDTO UpdateTag(String tag, String disputeId)
        {
            DisputeTagPutDTO disputeTag = new DisputeTagPutDTO { Tag = tag };

            return this.UpdateObject<DisputeDTO, DisputeTagPutDTO>(MethodKey.DisputesSaveTag, disputeTag, disputeId);
        }

        /// <summary>Submits dispute document.</summary>
        /// <param name="disputeDocument">Dispute document to be submitted.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="disputeDocumentId">Dispute document identifier.</param>
        /// <returns>Dispute document instance returned from API.</returns>
        public DisputeDocumentDTO SubmitDisputeDocument(DisputeDocumentPutDTO disputeDocument, String disputeId, String disputeDocumentId)
        {
            return this.UpdateObject<DisputeDocumentDTO, DisputeDocumentPutDTO>(MethodKey.DisputesDocumentSubmit, disputeDocument, disputeId, disputeDocumentId);
        }

        /// <summary>Contests dispute.</summary>
        /// <param name="contestedFunds">Contested funds.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public DisputeDTO ContestDispute(Money contestedFunds, String disputeId)
        {
            var disputeContest = new DisputeContestPutDTO
            {
                ContestedFunds = contestedFunds
            };

            return this.UpdateObject<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, disputeContest, disputeId);
        }

        /// <summary>Resubmits dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public DisputeDTO ResubmitDispute(String disputeId)
        {
            var dispute = new DisputeContestPutDTO();
            return this.UpdateObject<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, dispute, disputeId);
        }

        /// <summary>Closes dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public DisputeDTO CloseDispute(String disputeId)
        {
            return this.UpdateObject<DisputeDTO, EntityPutBase>(MethodKey.DisputeSaveClose, new EntityPutBase(), disputeId);
        }

        /// <summary>Creates document for dispute.</summary>
        /// <param name="disputeDocument">Dispute document to be created.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute document returned from API.</returns>
        public DisputeDocumentDTO CreateDisputeDocument(DisputeDocumentPostDTO disputeDocument, string disputeId)
        {
            return CreateDisputeDocument(null, disputeDocument, disputeId);
        }

        /// <summary>Creates document for dispute.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="disputeDocument">Dispute document to be created.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute document returned from API.</returns>
        public DisputeDocumentDTO CreateDisputeDocument(String idempotencyKey, DisputeDocumentPostDTO disputeDocument, string disputeId)
        {
            return this.CreateObject<DisputeDocumentDTO, DisputeDocumentPostDTO>(idempotencyKey, MethodKey.DisputesDocumentCreate, disputeDocument, disputeId);
        }

        /// <summary>Creates document's page for dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="documentId">Dispute document identifier.</param>
        /// <param name="filePath">Path to the file the DisputePage will be created from.</param>
        public bool CreateDisputePage(string disputeId, string documentId, string filePath)
        {
            byte[] fileArray = File.ReadAllBytes(filePath);
            return CreateDisputePage(disputeId, documentId, fileArray);
        }

        /// <summary>Creates document's page for dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="documentId">Dispute document identifier.</param>
        /// <param name="binaryData">The byte array the DisputePage will be created from.</param>
        public bool CreateDisputePage(string disputeId, string documentId, byte[] binaryData)
        {
            return CreateDisputePage(null, disputeId, documentId, binaryData);
        }

        /// <summary>Creates document's page for dispute.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="documentId">Dispute document identifier.</param>
        /// <param name="binaryData">The byte array the DisputePage will be created from.</param>
        public bool CreateDisputePage(string idempotencyKey, string disputeId, string documentId, byte[] binaryData)
        {
            var fileContent = Convert.ToBase64String(binaryData);

            var disputePage = new DisputePagePostDTO(fileContent);

            var result = this.CreateObject<DisputePageDTO, DisputePagePostDTO>(idempotencyKey, MethodKey.DisputesDocumentPageCreate, disputePage, disputeId, documentId);

            return result != null;
        }

        /// <summary>Gets settlement transfer.</summary>
        /// <param name="settlementId">Settlement transfer isentifier.</param>
        /// <returns>Settlement instance returned from API.</returns>
        public SettlementDTO GetSettlementTransfer(string settlementId)
        {
            return this.GetObject<SettlementDTO>(MethodKey.SettlementsGet, settlementId);
        }

        /// <summary>
        /// Get consultation for all dispute documents
        /// </summary>
        /// <param name="disputeDocumentId">Dispute document identifier.</param>
        /// <returns>Document consultation list</returns>
        public ListPaginated<DocumentConsultationDTO> GetDocumentConsultations(String disputeDocumentId)
        {
            var endPoint = GetApiEndPoint(MethodKey.DisputesDocumentConsult);
            endPoint.SetParameters(new[] { disputeDocumentId });
            var rest = new RestTool(_root, true);
            return rest.RequestList<DocumentConsultationDTO>(endPoint);
        }
    }
}
