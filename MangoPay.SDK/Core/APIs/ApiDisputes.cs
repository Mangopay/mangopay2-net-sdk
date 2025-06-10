using System;
using System.IO;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;

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
        public async Task<DisputeDTO> GetAsync(string disputeId)
        {
            return await this.GetObjectAsync<DisputeDTO>(MethodKey.DisputesGet, disputeId);
        }

        /// <summary>Gets all disputes.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public async Task<ListPaginated<DisputeDTO>> GetAllAsync(Pagination pagination = null, FilterDisputes filters = null, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetAll, pagination, sort, filters.GetValues());
        }

        /// <summary>Gets dispute's transactions.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Transaction instances returned from API.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(string disputeId, Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return await this.GetListAsync<TransactionDTO>(MethodKey.DisputesGetTransactions, pagination, sort, filters.GetValues(), entitiesId: disputeId);
        }

        /// <summary>Gets dispute's documents for wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of dispute instances returned from API.</returns>
        public async Task<ListPaginated<DisputeDTO>> GetDisputesForWalletAsync(string walletId, Pagination pagination, FilterDisputes filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetForWallet, pagination, sort, filters.GetValues(), entitiesId: walletId);
        }

        /// <summary>Gets user's disputes.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public async Task<ListPaginated<DisputeDTO>> GetDisputesForUserAsync(string userId, Pagination pagination, FilterDisputes filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetForUser, pagination, sort, filters.GetValues(), entitiesId: userId);
        }
        
        /// <summary>Gets payin's disputes.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Dispute instances returned from API.</returns>
        public async Task<ListPaginated<DisputeDTO>> GetDisputesForPayInAsync(string payInId, Pagination pagination, 
            FilterDisputes filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputes();

            return await this.GetListAsync<DisputeDTO>(MethodKey.DisputesGetForPayIn, pagination, sort, 
                filters.GetValues(), entitiesId: payInId);
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
        public async Task<DisputeDocumentDTO> GetDocumentAsync(string documentId)
        {
            return await this.GetObjectAsync<DisputeDocumentDTO>(MethodKey.DisputesDocumentGet, documentId);
        }

        /// <summary>Gets documents for dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of DisputeDocument instances returned from API.</returns>
        public async Task<ListPaginated<DisputeDocumentDTO>> GetDocumentsForDisputeAsync(string disputeId, Pagination pagination, FilterDisputeDocuments filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterDisputeDocuments();

            return await this.GetListAsync<DisputeDocumentDTO>(MethodKey.DisputesDocumentGetForDispute, pagination, sort, filters.GetValues(), entitiesId: disputeId);
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
        public async Task<RepudiationDTO> GetRepudiationAsync(string repudiationId)
        {
            return await this.GetObjectAsync<RepudiationDTO>(MethodKey.DisputesRepudiationGet, repudiationId);
        }

        /// <summary>Creates settlement transfer.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="settlementTransfer">Settlement transfer.</param>
        /// <param name="repudiationId">Repudiation identifier.</param>
        /// <returns>Transfer settlement instance returned from API.</returns>
        public async Task<SettlementDTO> CreateSettlementTransferAsync(SettlementTransferPostDTO settlementTransfer, string repudiationId, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<SettlementDTO, SettlementTransferPostDTO>(MethodKey.DisputesRepudiationCreateSettlement, settlementTransfer, idempotentKey, repudiationId);
        }

        /// <summary>Updates dispute's tag.</summary>
        /// <param name="tag">New tag text.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public async Task<DisputeDTO> UpdateTagAsync(string tag, string disputeId)
        {
            DisputeTagPutDTO disputeTag = new DisputeTagPutDTO { Tag = tag };

            return await this.UpdateObjectAsync<DisputeDTO, DisputeTagPutDTO>(MethodKey.DisputesSaveTag, disputeTag, entitiesId: disputeId);
        }

        /// <summary>Submits dispute document.</summary>
        /// <param name="disputeDocument">Dispute document to be submitted.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="disputeDocumentId">Dispute document identifier.</param>
        /// <returns>Dispute document instance returned from API.</returns>
        public async Task<DisputeDocumentDTO> SubmitDisputeDocumentAsync(DisputeDocumentPutDTO disputeDocument, string disputeId, string disputeDocumentId)
        {
            return await this.UpdateObjectAsync<DisputeDocumentDTO, DisputeDocumentPutDTO>(
                MethodKey.DisputesDocumentSubmit, 
                disputeDocument, 
                entitiesId: new string[]
                    {
                        disputeId, 
                        disputeDocumentId
                    }
                );
        }

        /// <summary>Contests dispute.</summary>
        /// <param name="contestedFunds">Contested funds.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public async Task<DisputeDTO> ContestDisputeAsync(Money contestedFunds, string disputeId)
        {
            var disputeContest = new DisputeContestPutDTO
            {
                ContestedFunds = contestedFunds
            };

            return await this.UpdateObjectAsync<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, disputeContest, entitiesId: disputeId);
        }

        /// <summary>Resubmits dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public async Task<DisputeDTO> ResubmitDisputeAsync(string disputeId)
        {
            var dispute = new DisputeContestPutDTO();
            return await this.UpdateObjectAsync<DisputeDTO, DisputeContestPutDTO>(MethodKey.DisputesSaveContestFunds, dispute, entitiesId: disputeId);
        }

        /// <summary>Closes dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute instance returned from API.</returns>
        public async Task<DisputeDTO> CloseDisputeAsync(string disputeId)
        {
            return await this.UpdateObjectAsync<DisputeDTO, EntityPutBase>(MethodKey.DisputeSaveClose, new EntityPutBase(), entitiesId: disputeId);
        }

        /// <summary>Creates document for dispute.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="disputeDocument">Dispute document to be created.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <returns>Dispute document returned from API.</returns>
        public async Task<DisputeDocumentDTO> CreateDisputeDocumentAsync(DisputeDocumentPostDTO disputeDocument, string disputeId, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<DisputeDocumentDTO, DisputeDocumentPostDTO>(MethodKey.DisputesDocumentCreate, disputeDocument, idempotentKey, disputeId);
        }

        /// <summary>Creates document's page for dispute.</summary>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="documentId">Dispute document identifier.</param>
        /// <param name="filePath">Path to the file the DisputePage will be created from.</param>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        public async Task<bool> CreateDisputePageAsync(string disputeId, string documentId, string filePath, string idempotentKey = null)
        {
            var binaryData = File.ReadAllBytes(filePath);
            return await CreateDisputePageAsync(disputeId, documentId, binaryData, idempotentKey);
        }

        /// <summary>Creates document's page for dispute.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="disputeId">Dispute identifier.</param>
        /// <param name="documentId">Dispute document identifier.</param>
        /// <param name="binaryData">The byte array the DisputePage will be created from.</param>
        public async Task<bool> CreateDisputePageAsync(string disputeId, string documentId, byte[] binaryData, string idempotentKey = null)
        {
            var fileContent = Convert.ToBase64String(binaryData);

            var disputePage = new DisputePagePostDTO(fileContent);

            var result = await this.CreateObjectAsync<DisputePageDTO, DisputePagePostDTO>(MethodKey.DisputesDocumentPageCreate, disputePage, idempotentKey, disputeId, documentId);

            return result != null;
        }

        /// <summary>Gets settlement transfer.</summary>
        /// <param name="settlementId">Settlement transfer identifier.</param>
        /// <returns>Settlement instance returned from API.</returns>
        public async Task<SettlementDTO> GetSettlementTransferAsync(string settlementId)
        {
            return await this.GetObjectAsync<SettlementDTO>(MethodKey.SettlementsGet, entitiesId: settlementId);
        }

        /// <summary>
        /// Get consultation for all dispute documents
        /// </summary>
        /// <param name="disputeDocumentId">Dispute document identifier.</param>
        /// <returns>Document consultation list</returns>
        public async Task<ListPaginated<DocumentConsultationDTO>> GetDocumentConsultationsAsync(string disputeDocumentId)
        {
            return await this.GetListAsync<DocumentConsultationDTO>(MethodKey.DisputesDocumentConsult, entitiesId: disputeDocumentId);
        }
    }
}
