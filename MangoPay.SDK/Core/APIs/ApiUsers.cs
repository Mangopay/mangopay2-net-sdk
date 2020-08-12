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
    /// <summary>API for users.</summary>
    public class ApiUsers : ApiBase
    {
        /// <summary>Instantiates new ApiUsers object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiUsers(MangoPayApi root) : base(root) { }

        /// <summary>Gets user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>User instance returned from API, which is either of UserNatural or UserLegal type.</returns>
        public async Task<UserDTO> Get(String userId)
        {
            return await this.GetObject<UserDTO>(MethodKey.UsersGet, userId);
        }

		/// <summary>Creates new user.</summary>
		/// <param name="user">UserNatural object to be created.</param>
		/// <returns>UserNatural instance returned from API.</returns>
		public async Task<UserNaturalDTO> Create(UserNaturalPostDTO user)
		{
			return await Create(null, user);
		}

		/// <summary>Creates new user.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="user">UserNatural object to be created.</param>
		/// <returns>UserNatural instance returned from API.</returns>
		public async Task<UserNaturalDTO> Create(String idempotencyKey, UserNaturalPostDTO user)
		{
			return await this.CreateObject<UserNaturalDTO, UserNaturalPostDTO>(idempotencyKey, MethodKey.UsersCreateNaturals, user);
		}

        /// <summary>Creates new user.</summary>
        /// <param name="user">UserLegal object to be created.</param>
        /// <returns>UserLegal instance returned from API.</returns>
        public async Task<UserLegalDTO> Create(UserLegalPostDTO user)
        {
            return await Create(null, user);
        }

		/// <summary>Creates new user.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="user">UserLegal object to be created.</param>
		/// <returns>UserLegal instance returned from API.</returns>
		public async Task<UserLegalDTO> Create(String idempotencyKey, UserLegalPostDTO user)
		{
			return await this.CreateObject<UserLegalDTO, UserLegalPostDTO>(idempotencyKey, MethodKey.UsersCreateLegals, user);
		}

        /// <summary>Gets users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of User instances.</returns>
        public async Task<ListPaginated<UserDTO>> GetAll(Pagination pagination, Sort sort = null)
        {
            return await this.GetList<UserDTO>(MethodKey.UsersAll, pagination, sort);
        }

        /// <summary>Gets first page of users.</summary>
        /// <returns>Collection of User instances.</returns>
        public async Task<ListPaginated<UserDTO>> GetAll()
        {
            return await GetAll(null);
        }

        /// <summary>Gets natural user.</summary>
        /// <param name="userId">UserNatural identifier.</param>
        /// <returns>UserNatural object returned from API.</returns>
        public async Task<UserNaturalDTO> GetNatural(String userId)
        {
            return await this.GetObject<UserNaturalDTO>(MethodKey.UsersGetNaturals, userId);
        }

		/// <summary>TEMPORAL SOLUTION: Use this method only against API v2.</summary>
		/// <param name="userId">UserNatural identifier.</param>
		/// <returns>UserNaturalObsolete object returned from API</returns>
		public async Task<UserNaturalObsoleteDTO> GetNaturalObsolete(String userId)
		{
			return await this.GetObject<UserNaturalObsoleteDTO>(MethodKey.UsersGetNaturals, userId);
		}

        /// <summary>Gets legal user.</summary>
        /// <param name="userId">UserLegal identifier.</param>
        /// <returns>UserLegal object returned from API.</returns>
        public async Task<UserLegalDTO> GetLegal(String userId)
        {
            return await this.GetObject<UserLegalDTO>(MethodKey.UsersGetLegals, userId);
        }

		/// <summary>TEMPORAL SOLUTION: Use this method only against API v2.</summary>
		/// <param name="userId">UserLegal identifier.</param>
		/// <returns>UserLegalObsolete object returned from API</returns>
		public async Task<UserLegalObsoleteDTO> GetLegalObsolete(String userId)
		{
			return await this.GetObject<UserLegalObsoleteDTO>(MethodKey.UsersGetLegals, userId);
		}

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance of UserNatural class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public async Task<UserNaturalDTO> UpdateNatural(UserNaturalPutDTO user, String userId)
        {
            return await this.UpdateObject<UserNaturalDTO, UserNaturalPutDTO>(MethodKey.UsersSaveNaturals, user, userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance UserLegal class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public async Task<UserLegalDTO> UpdateLegal(UserLegalPutDTO user, String userId)
        {
            return await this.UpdateObject<UserLegalDTO, UserLegalPutDTO>(MethodKey.UsersSaveLegals, user, userId);
        }

		/// <summary>Gets all user's wallets.</summary>
		/// <param name="userId">User identifier to get wallets of.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
		/// <returns>Collection of user's wallets.</returns>
        public async Task<ListPaginated<WalletDTO>> GetWallets(String userId, Pagination pagination, Sort sort = null)
		{
			return await this.GetList<WalletDTO>(MethodKey.UsersAllWallets, pagination, sort,userId);
		}

        /// <summary>Creates CA bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountCaDTO> CreateBankAccountCa(String userId, BankAccountCaPostDTO bankAccount)
        {
			return await CreateBankAccountCa(null, userId, bankAccount);
        }

		/// <summary>Creates CA bank account.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="bankAccount">Bank account instance to be created.</param>
		/// <returns>Bank account instance returned from API.</returns>
		public async Task<BankAccountCaDTO> CreateBankAccountCa(String idempotencyKey, String userId, BankAccountCaPostDTO bankAccount)
		{
			return await this.CreateObject<BankAccountCaDTO, BankAccountCaPostDTO>(idempotencyKey, MethodKey.UsersCreateBankAccountsCa, bankAccount, userId);
		}

        /// <summary>Creates GB bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountGbDTO> CreateBankAccountGb(String userId, BankAccountGbPostDTO bankAccount)
        {
            return await CreateBankAccountGb(null, userId, bankAccount);
        }

		/// <summary>Creates GB bank account.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="bankAccount">Bank account instance to be created.</param>
		/// <returns>Bank account instance returned from API.</returns>
		public async Task<BankAccountGbDTO> CreateBankAccountGb(String idempotencyKey, String userId, BankAccountGbPostDTO bankAccount)
		{
			return await this.CreateObject<BankAccountGbDTO, BankAccountGbPostDTO>(idempotencyKey, MethodKey.UsersCreateBankAccountsGb, bankAccount, userId);
		}

        /// <summary>Creates IBAN bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountIbanDTO> CreateBankAccountIban(String userId, BankAccountIbanPostDTO bankAccount)
        {
            return await CreateBankAccountIban(null, userId, bankAccount);
        }

		/// <summary>Creates IBAN bank account.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="bankAccount">Bank account instance to be created.</param>
		/// <returns>Bank account instance returned from API.</returns>
		public async Task<BankAccountIbanDTO> CreateBankAccountIban(String idempotencyKey, String userId, BankAccountIbanPostDTO bankAccount)
		{
			return await this.CreateObject<BankAccountIbanDTO, BankAccountIbanPostDTO>(idempotencyKey, MethodKey.UsersCreateBankAccountsIban, bankAccount, userId);
		}

        /// <summary>Creates OTHER bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountOtherDTO> CreateBankAccountOther(String userId, BankAccountOtherPostDTO bankAccount)
        {
            return await CreateBankAccountOther(null, userId, bankAccount);
        }

		/// <summary>Creates OTHER bank account.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="bankAccount">Bank account instance to be created.</param>
		/// <returns>Bank account instance returned from API.</returns>
		public async Task<BankAccountOtherDTO> CreateBankAccountOther(String idempotencyKey, String userId, BankAccountOtherPostDTO bankAccount)
		{
			return await this.CreateObject<BankAccountOtherDTO, BankAccountOtherPostDTO>(idempotencyKey, MethodKey.UsersCreateBankAccountsOther, bankAccount, userId);
		}

        /// <summary>Creates US bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountUsDTO> CreateBankAccountUs(String userId, BankAccountUsPostDTO bankAccount)
        {
            return await CreateBankAccountUs(null, userId, bankAccount);
        }

		/// <summary>Creates US bank account.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="bankAccount">Bank account instance to be created.</param>
		/// <returns>Bank account instance returned from API.</returns>
		public async Task<BankAccountUsDTO> CreateBankAccountUs(String idempotencyKey, String userId, BankAccountUsPostDTO bankAccount)
		{
			return await this.CreateObject<BankAccountUsDTO, BankAccountUsPostDTO>(idempotencyKey, MethodKey.UsersCreateBankAccountsUs, bankAccount, userId);
		}

        /// <summary>Gets all user's bank accounts.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public async Task<ListPaginated<BankAccountDTO>> GetBankAccounts(String userId, Pagination pagination, Sort sort = null)
        {
            return await this.GetList<BankAccountDTO>(MethodKey.UsersAllBankAccount, pagination, sort,userId);
        }

        /// <summary>Gets first page of all bank accounts of user.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public async Task<ListPaginated<BankAccountDTO>> GetBankAccounts(String userId)
        {
            return await GetBankAccounts(userId, null);
        }

        /// <summary>Gets bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
		public async Task<BankAccountDTO> GetBankAccount(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

		public async Task<BankAccountObsoleteDTO> GetBankAccountObsolete(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountObsoleteDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

        /// <summary>Gets CA bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
		public async Task<BankAccountCaDTO> GetBankAccountCa(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountCaDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

		public async Task<BankAccountCaObsoleteDTO> GetBankAccountCaObsolete(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountCaObsoleteDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

        /// <summary>Gets GB bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
		public async Task<BankAccountGbDTO> GetBankAccountGb(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountGbDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

		public async Task<BankAccountGbObsoleteDTO> GetBankAccountGbObsolete(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountGbObsoleteDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

        /// <summary>Gets IBAN bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
		public async Task<BankAccountIbanDTO> GetBankAccountIban(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountIbanDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

		public async Task<BankAccountIbanObsoleteDTO> GetBankAccountIbanObsolete(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountIbanObsoleteDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

        /// <summary>Gets OTHER bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountOtherDTO> GetBankAccountOther(String userId, String bankAccountId)
        {
            return await this.GetObject<BankAccountOtherDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

		public async Task<BankAccountOtherObsoleteDTO> GetBankAccountOtherObsolete(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountOtherObsoleteDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

        /// <summary>Gets US bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountUsDTO> GetBankAccountUs(String userId, String bankAccountId)
        {
            return await this.GetObject<BankAccountUsDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

		public async Task<BankAccountUsObsoleteDTO> GetBankAccountUsObsolete(String userId, String bankAccountId)
		{
			return await this.GetObject<BankAccountUsObsoleteDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
		}

		/// <summary>Updates bank account.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="bankAccount">Bank account instance to be updated.</param>
		/// <param name="bankAccountId">Bank account identifier.</param>
		/// <returns>Bank account object returned from API.</returns>
		public async Task<BankAccountDTO> UpdateBankAccount(String userId, DisactivateBankAccountPutDTO bankAccount, String bankAccountId)
		{
			return await this.UpdateObject<BankAccountDTO, DisactivateBankAccountPutDTO>(MethodKey.UsersSaveBankAccount, bankAccount, userId, bankAccountId);
		}

		/// <summary>Lists transactions for a bank account</summary>
		/// <param name="bankAccountId">Id of the bank account to get transactions</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filter">Filter.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>List of transactions for a bank account</returns>
		public async Task<ListPaginated<TransactionDTO>> GetTransactionsForBankAccount(string bankAccountId, Pagination pagination, FilterTransactions filters, Sort sort = null)
		{
			if (filters == null) filters = new FilterTransactions();

			return await GetList<TransactionDTO>(MethodKey.BankAccountsGetTransactions, pagination, sort, filters.GetValues(),bankAccountId);
		}

		/// <summary>Gets transactions for user.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filter">Filter.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>Collection of user's transactions.</returns>
		public async Task<ListPaginated<TransactionDTO>> GetTransactions(String userId, Pagination pagination, FilterTransactions filter, Sort sort = null)
        {
            return await this.GetList<TransactionDTO>(MethodKey.UsersAllTransactions, pagination, sort, filter.GetValues(), userId);
        }

        /// <summary>Gets all cards for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's cards.</returns>
        public async Task<ListPaginated<CardDTO>> GetCards(String userId, Pagination pagination, Sort sort = null)
        {
            return await this.GetList<CardDTO>(MethodKey.UsersAllCards, pagination, sort,userId);
        }

        /// <summary>Creates KycPage from byte array.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="binaryData">The byte array the KycPage will be created from.</param>
        public async Task CreateKycPage(String userId, String kycDocumentId, byte[] binaryData)
        {
			await CreateKycPage(null, userId, kycDocumentId, binaryData);
        }

		/// <summary>Creates KycPage from byte array.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="kycDocumentId">KycDocument identifier.</param>
		/// <param name="binaryData">The byte array the KycPage will be created from.</param>
		public async Task CreateKycPage(String idempotencyKey, String userId, String kycDocumentId, byte[] binaryData)
		{
			String fileContent = Convert.ToBase64String(binaryData);

			KycPagePostDTO kycPage = new KycPagePostDTO(fileContent);

			var result = await this.CreateObject<KycPageDTO, KycPagePostDTO>(idempotencyKey, MethodKey.UsersCreateKycPage, kycPage, userId, kycDocumentId);
		}

        /// <summary>Creates KycPage from file.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="filePath">Path to the file the KycPage will be created from.</param>
        public async Task CreateKycPage(String userId, String kycDocumentId, String filePath)
        {
            await CreateKycPage(null, userId, kycDocumentId, filePath);
        }

		/// <summary>Creates KycPage from file.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="kycDocumentId">KycDocument identifier.</param>
		/// <param name="filePath">Path to the file the KycPage will be created from.</param>
		public async Task CreateKycPage(String idempotencyKey, String userId, String kycDocumentId, String filePath)
		{
			byte[] fileArray = File.ReadAllBytes(filePath);
			await CreateKycPage(idempotencyKey, userId, kycDocumentId, fileArray);
		}

        /// <summary>Creates KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="type">Type of KycDocument.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public async Task<KycDocumentDTO> CreateKycDocument(String userId, KycDocumentType type, string tag = null)
        {
			return await CreateKycDocument(null, userId, type, tag);
        }

		/// <summary>Creates KycDocument.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="type">Type of KycDocument.</param>
		/// <returns>KycDocument object returned from API.</returns>
		public async Task<KycDocumentDTO> CreateKycDocument(String idempotencyKey, String userId, KycDocumentType type, string tag = null)
		{
            KycDocumentPostDTO kycDocument = new KycDocumentPostDTO(type)
            {
                Tag = tag
            };

            return await this.CreateObject<KycDocumentDTO, KycDocumentPostDTO>(idempotencyKey, MethodKey.UsersCreateKycDocument, kycDocument, userId);
		}

        /// <summary>Gets KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public async Task<KycDocumentDTO> GetKycDocument(String userId, String kycDocumentId)
        {
            return await this.GetObject<KycDocumentDTO>(MethodKey.UsersGetKycDocument, userId, kycDocumentId);
        }

        /// <summary>Updates KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocument">KycDocument entity instance to be updated.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public async Task<KycDocumentDTO> UpdateKycDocument(String userId, KycDocumentPutDTO kycDocument, String kycDocumentId)
        {
            return await this.UpdateObject<KycDocumentDTO, KycDocumentPutDTO>(MethodKey.UsersSaveKycDocument, kycDocument, userId, kycDocumentId);
        }

        /// <summary>Gets a list of all the uploaded documents for the particular user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's uploaded documents.</returns>
        public async Task<ListPaginated<KycDocumentDTO>> GetKycDocuments(String userId, Pagination pagination, FilterKycDocuments filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterKycDocuments();

            return await this.GetList<KycDocumentDTO>(MethodKey.UsersGetKycDocuments, pagination, sort, filter.GetValues(),userId);
        }

		/// <summary>Gets Emoney object.</summary>
		/// <param name="userId">User identifier.</param>
		/// <returns>Emoney object returned from API.</returns>
		public async Task<EmoneyDTO> GetEmoney(String userId)
		{
			return await GetEmoney(userId, CurrencyIso.NotSpecified);
		}

		/// <summary>Gets Emoney object.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="currency">Currency ISO code.</param>
		/// <returns>Emoney object returned from API.</returns>
		public async Task<EmoneyDTO> GetEmoney(String userId, CurrencyIso currency)
		{
			var endPoint = GetApiEndPoint(MethodKey.UsersEmoneyGet);
			endPoint.SetParameters(new []{userId});
			var rest = new RestTool(_root, true);
			var parameters = new Dictionary<string, string>();
            if (currency != CurrencyIso.NotSpecified)
            {
                parameters.Add("currency", currency.ToString());
            }

			return await rest.Request<EmoneyDTO, EmoneyDTO>(endPoint, parameters);
		}
		
		/// <summary>Gets Emoney object.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="year">Emoney accounts for year</param>
		/// <returns>Emoney object returned from API.</returns>
		public async Task<EmoneyDTO> GetEmoneyForYear(String userId, String year)
		{
			return await GetEmoneyForYear(userId, year, CurrencyIso.NotSpecified);
		}

		/// <summary>Gets Emoney object.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="year">Emoney accounts for year</param>
		/// <param name="currency">Currency ISO code.</param>
		/// <returns>Emoney object returned from API.</returns>
		public async Task<EmoneyDTO> GetEmoneyForYear(String userId, String year, CurrencyIso currencyIso)
		{
			var endPoint = GetApiEndPoint(MethodKey.UsersEmoneyYearGet);
			endPoint.SetParameters(new []{userId, year});
			var rest = new RestTool(_root, true);
			var parameters = new Dictionary<string, string>();
            if (currencyIso != CurrencyIso.NotSpecified)
            {
                parameters.Add("currency", currencyIso.ToString());
            }

			return await rest.Request<EmoneyDTO, EmoneyDTO>(endPoint, parameters);
		}

		/// <summary>Gets Emoney object.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="year">Emoney accounts for year</param>
		/// <param name="month">Emoney accounts for month</param>
		/// <returns>Emoney object returned from API.</returns>
		public async Task<EmoneyDTO> GetEmoneyForYearAndMonth(String userId, String year, String month)
		{
			return await GetEmoneyForYearAndMonth(userId, year, month, CurrencyIso.NotSpecified);
		}

		/// <summary>Gets Emoney object.</summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="year">Emoney accounts for year</param>
		/// <param name="month">Emoney accounts for month</param>
		/// <param name="currency">Currency ISO code.</param>
		/// <returns>Emoney object returned from API.</returns>
		public async Task<EmoneyDTO> GetEmoneyForYearAndMonth(String userId, String year, String month, CurrencyIso currencyIso)
		{
			var endPoint = GetApiEndPoint(MethodKey.UsersEmoneyYearGet);
			endPoint.SetParameters(new []{userId, year, month});
			var rest = new RestTool(_root, true);
			var parameters = new Dictionary<string, string>();
            if (currencyIso != CurrencyIso.NotSpecified)
            {
                parameters.Add("currency", currencyIso.ToString());
            }

			return await rest.Request<EmoneyDTO, EmoneyDTO>(endPoint, parameters);
		}

        /// <summary>Gets Emoney object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="year">The year</param>
        /// <param name="currency">Currency ISO code.</param>
        /// <returns>Emoney object returned from API.</returns>
        public async Task<EmoneyDTO> GetEmoney(String userId, String year, CurrencyIso currency)
        {
            var endPoint = GetApiEndPoint(MethodKey.UsersEmoneyYearGet);
            endPoint.SetParameters(new[] { userId, year });
            var rest = new RestTool(_root, true);
            var parameters = new Dictionary<string, string>();
            if (currency != CurrencyIso.NotSpecified)
            {
                parameters.Add("currency", currency.ToString());
            }

            return await rest.Request<EmoneyDTO, EmoneyDTO>(endPoint, parameters);
        }

        /// <summary>Gets Emoney object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="currency">Currency ISO code.</param>
        /// <returns>Emoney object returned from API.</returns>
        public async Task<EmoneyDTO> GetEmoney(String userId, String year, String month, CurrencyIso currency)
        {
            var endPoint = GetApiEndPoint(MethodKey.UsersEmoneyMonthGet);
            endPoint.SetParameters(new[] { userId, year, month });
            var rest = new RestTool(_root, true);
            var parameters = new Dictionary<string, string>();
            if (currency != CurrencyIso.NotSpecified)
            {
                parameters.Add("currency", currency.ToString());
            }

            return await rest.Request<EmoneyDTO, EmoneyDTO>(endPoint, parameters);
        }
    }
}
