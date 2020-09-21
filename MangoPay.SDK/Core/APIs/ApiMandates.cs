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
		/// <param name="mandate">Mandate instance to be created.</param>
		/// <returns>Mandate instance returned from API.</returns>
		public async Task<MandateDTO> CreateAsync(MandatePostDTO mandate)
		{
			return await CreateAsync(null, mandate);
		}

		/// <summary>Creates new mandate.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="mandate">Mandate instance to be created.</param>
		/// <returns>Mandate instance returned from API.</returns>
		public async Task<MandateDTO> CreateAsync(string idempotencyKey, MandatePostDTO mandate)
		{
			return await this.CreateObjectAsync<MandateDTO, MandatePostDTO>(idempotencyKey, MethodKey.MandateCreate, mandate);
		}

		/// <summary>Gets mandate.</summary>
		/// <param name="mandateId">Mandate identifier.</param>
		/// <returns>Mandate instance returned from API.</returns>
		public async Task<MandateDTO> GetAsync(string mandateId)
		{
			return await this.GetObjectAsync<MandateDTO>(MethodKey.MandateGet, mandateId);
		}

		/// <summary>Gets all mandates.</summary>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filters">Filters.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of Mandate instances returned from API.</returns>
		public async Task<ListPaginated<MandateDTO>> GetAllAsync(Pagination pagination, FilterMandates filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterMandates();

			return await this.GetListAsync<MandateDTO>(MethodKey.MandatesGetAll, pagination, sort, filters.GetValues());
		}

		/// <summary>Gets all mandates.</summary>
		/// <returns>List of Mandate instances returned from API.</returns>
		public async Task<ListPaginated<MandateDTO>> GetAllAsync()
		{
			return await GetAllAsync(null, null);
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

			return await this.GetListAsync<MandateDTO>(MethodKey.MandatesGetForUser, pagination, sort, filters.GetValues(),userId);
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

			return await this.GetListAsync<MandateDTO>(MethodKey.MandatesGetForBankAccount, pagination, sort, filters.GetValues(), userId, bankAccountId);
		}

		/// <summary>Cancels mandate.</summary>
		/// <param name="mandateId">Mandate identifier.</param>
		/// <returns>Mandate instance returned from API.</returns>
		public async Task<MandateDTO> CancelAsync(string mandateId)
		{
			return await this.UpdateObjectAsync<MandateDTO, EntityPutBase>(MethodKey.MandateCancel, new EntityPutBase(), mandateId);
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

			return await GetListAsync<TransactionDTO>(MethodKey.MandatesGetTransactions, pagination, sort, filters.GetValues(),mandateId);
		}

        /// <summary>Creates new mandate.</summary>
        /// <param name="mandate">Mandate instance to be created.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public MandateDTO Create(MandatePostDTO mandate)
        {
            return Create(null, mandate);
        }

        /// <summary>Creates new mandate.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="mandate">Mandate instance to be created.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public MandateDTO Create(string idempotencyKey, MandatePostDTO mandate)
        {
            return this.CreateObject<MandateDTO, MandatePostDTO>(idempotencyKey, MethodKey.MandateCreate, mandate);
        }

        /// <summary>Gets mandate.</summary>
        /// <param name="mandateId">Mandate identifier.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public MandateDTO Get(string mandateId)
        {
            return this.GetObject<MandateDTO>(MethodKey.MandateGet, mandateId);
        }

        /// <summary>Gets all mandates.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Mandate instances returned from API.</returns>
        public ListPaginated<MandateDTO> GetAll(Pagination pagination, FilterMandates filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterMandates();

            return this.GetList<MandateDTO>(MethodKey.MandatesGetAll, pagination, sort, filters.GetValues());
        }

        /// <summary>Gets all mandates.</summary>
        /// <returns>List of Mandate instances returned from API.</returns>
        public ListPaginated<MandateDTO> GetAll()
        {
            return GetAll(null, null);
        }

        /// <summary>Gets mandates for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Mandate instances returned from API.</returns>
        public ListPaginated<MandateDTO> GetForUser(string userId, Pagination pagination, FilterMandates filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterMandates();

            return this.GetList<MandateDTO>(MethodKey.MandatesGetForUser, pagination, sort, filters.GetValues(), userId);
        }

        /// <summary>Gets mandates for bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of Mandate instances returned from API.</returns>
        public ListPaginated<MandateDTO> GetForBankAccount(string userId, string bankAccountId, Pagination pagination, FilterMandates filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterMandates();

            return this.GetList<MandateDTO>(MethodKey.MandatesGetForBankAccount, pagination, sort, filters.GetValues(), userId, bankAccountId);
        }

        /// <summary>Cancels mandate.</summary>
        /// <param name="mandateId">Mandate identifier.</param>
        /// <returns>Mandate instance returned from API.</returns>
        public MandateDTO Cancel(string mandateId)
        {
            return this.UpdateObject<MandateDTO, EntityPutBase>(MethodKey.MandateCancel, new EntityPutBase(), mandateId);
        }

        /// <summary>Lists transactions for a mandate</summary>
        /// <param name="mandateId">Id of the mandate to get transactions</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of transactions for a mandate</returns>
        public ListPaginated<TransactionDTO> GetTransactionsForMandate(string mandateId, Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return GetList<TransactionDTO>(MethodKey.MandatesGetTransactions, pagination, sort, filters.GetValues(), mandateId);
        }
    }
}
