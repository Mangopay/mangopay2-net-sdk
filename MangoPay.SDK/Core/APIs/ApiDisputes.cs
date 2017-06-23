using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;
using System.IO;

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

			return this.GetList<DisputeDTO>(MethodKey.DisputesGetAll, pagination, null, sort, filters.GetValues());
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

			return this.GetList<TransactionDTO>(MethodKey.DisputesGetTransactions, pagination, disputeId, sort, filters.GetValues());
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

			return this.GetList<DisputeDTO>(MethodKey.DisputesGetForWallet, pagination, walletId, sort, filters.GetValues());
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

			return this.GetList<DisputeDTO>(MethodKey.DisputesGetForUser, pagination, userId, sort, filters.GetValues());
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

			return this.GetList<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForDispute, pagination, disputeId, sort, filters.GetValues());
		}

		/// <summary>Gets dispute's documents for client.</summary>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of dispute documents returned from API.</returns>
		public ListPaginated<DisputeDocumentDTO> GetDocumentsForClient(Pagination pagination, FilterDisputeDocuments filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterDisputeDocuments();

			return this.GetList<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForClient, pagination, null, sort, filters.GetValues());
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
			DisputeContestPutDTO disputeContest = new DisputeContestPutDTO();
			disputeContest.ContestedFunds = contestedFunds;

			return this.UpdateObject<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, disputeContest, disputeId);
		}

		/// <summary>Resubmits dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <returns>Dispute instance returned from API.</returns>
		public DisputeDTO ResubmitDispute(String disputeId)
		{
			DisputeContestPutDTO dispute = new DisputeContestPutDTO();
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
		public void CreateDisputePage(string disputeId, string documentId, string filePath)
		{
			byte[] fileArray = File.ReadAllBytes(filePath);
			CreateDisputePage(disputeId, documentId, fileArray);
		}

		/// <summary>Creates document's page for dispute.</summary>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="documentId">Dispute document identifier.</param>
		/// <param name="binaryData">The byte array the DisputePage will be created from.</param>
		public void CreateDisputePage(string disputeId, string documentId, byte[] binaryData)
		{
			CreateDisputePage(null, disputeId, documentId, binaryData);
		}

		/// <summary>Creates document's page for dispute.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="disputeId">Dispute identifier.</param>
		/// <param name="documentId">Dispute document identifier.</param>
		/// <param name="binaryData">The byte array the DisputePage will be created from.</param>
		public void CreateDisputePage(string idempotencyKey, string disputeId, string documentId, byte[] binaryData)
		{
			string fileContent = Convert.ToBase64String(binaryData);

			DisputePagePostDTO disputePage = new DisputePagePostDTO(fileContent);

			this.CreateObject<DisputePageDTO, DisputePagePostDTO>(idempotencyKey, MethodKey.DisputesDocumentPageCreate, disputePage, disputeId, documentId);
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
			endPoint.SetParameters(disputeDocumentId);
			var rest = new RestTool(_root, true);
			return rest.RequestList<DocumentConsultationDTO>(endPoint);
		}
	}
}
