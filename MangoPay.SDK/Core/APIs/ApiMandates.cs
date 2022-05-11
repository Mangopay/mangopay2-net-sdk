using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for mandates.</summary>
    public class ApiMandates : ApiBase
    {
        /// <summary>Instantiates new ApiMandates object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiMandates(MangoPayApi root) : base(root) { }

        /// <summary>Creates new mandate.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="mandate">Mandate instance to be created.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public async Task<MandateDTO> CreateAsync(MandatePostDTO mandate, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<MandateDTO, MandatePostDTO>(MethodKey.MandateCreate, mandate, idempotentKey);
        }

        /// <summary>Gets mandate.</summary>
        /// <param name="mandateId">Mandate identifier.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public async Task<MandateDTO> GetAsync(string mandateId)
        {
            return await this.GetObjectAsync<MandateDTO>(MethodKey.MandateGet, entitiesId: mandateId);
        }

        /// <summary>Gets all mandates.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Mandate instances returned from API.</returns>
        public async Task<ListPaginated<MandateDTO>> GetAllAsync(Pagination pagination = null, FilterMandates filters = null, Sort sort = null)
        {
            if (filters == null) filters = new FilterMandates();

            return await this.GetListAsync<MandateDTO>(MethodKey.MandatesGetAll, pagination, sort, filters.GetValues());
        }

        /// <summary>Gets mandates for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Mandate instances returned from API.</returns>
        public async Task<ListPaginated<MandateDTO>> GetForUserAsync(string userId, Pagination pagination, FilterMandates filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterMandates();

            return await this.GetListAsync<MandateDTO>(MethodKey.MandatesGetForUser, pagination, sort, filters.GetValues(), null, userId);
        }

        /// <summary>Gets mandates for bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Mandate instances returned from API.</returns>
        public async Task<ListPaginated<MandateDTO>> GetForBankAccountAsync(string userId, string bankAccountId, Pagination pagination, FilterMandates filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterMandates();

            return await this.GetListAsync<MandateDTO>(MethodKey.MandatesGetForBankAccount, pagination, sort, filters.GetValues(), null, userId, bankAccountId);
        }

        /// <summary>Cancels mandate.</summary>
        /// <param name="mandateId">Mandate identifier.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public async Task<MandateDTO> CancelAsync(string mandateId)
        {
            return await this.UpdateObjectAsync<MandateDTO, EntityPutBase>(MethodKey.MandateCancel, new EntityPutBase(), entitiesId: mandateId);
        }

        /// <summary>Lists transactions for a mandate</summary>
        /// <param name="mandateId">Id of the mandate to get transactions</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of transactions for a mandate</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsForMandateAsync(string mandateId, Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return await GetListAsync<TransactionDTO>(MethodKey.MandatesGetTransactions, pagination, sort, filters.GetValues(), entitiesId: mandateId);
        }
    }
}
