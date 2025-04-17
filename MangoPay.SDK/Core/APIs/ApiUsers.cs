using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for users.</summary>
    public class ApiUsers : ApiBase
    {
        /// <summary>Instantiates new ApiUsers object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiUsers(MangoPayApi root) : base(root)
        {
        }

        /// <summary>Gets user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>User instance returned from API, which is either of UserNatural or UserLegal type.</returns>
        public async Task<UserDTO> GetAsync(string userId)
        {
            return await this.GetObjectAsync<UserDTO>(MethodKey.UsersGet, entitiesId: userId);
        }

        /// <summary>Gets SCA user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>SCA User instance returned from API, which is either of UserNaturalSca or UserLegalSca type.</returns>
        public async Task<UserDTO> GetScaAsync(string userId)
        {
            return await this.GetObjectAsync<UserDTO>(MethodKey.UsersGetSca, entitiesId: userId);
        }

        /// <summary>Creates new owner user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserNatural object to be created.</param>
        /// <returns>UserNatural instance returned from API.</returns>
        public async Task<UserNaturalDTO> CreateOwnerAsync(UserNaturalOwnerPostDTO user, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserNaturalDTO, UserNaturalOwnerPostDTO>(MethodKey.UsersCreateNaturals,
                user, idempotentKey);
        }

        /// <summary>Creates new owner SCA user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserNaturalSca object to be created.</param>
        /// <returns>UserNaturalSca instance returned from API.</returns>
        public async Task<UserNaturalScaDTO> CreateOwnerAsync(UserNaturalScaOwnerPostDTO user,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserNaturalScaDTO, UserNaturalScaOwnerPostDTO>(
                MethodKey.UsersCreateNaturalsSca, user, idempotentKey);
        }

        /// <summary>Creates new payer user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserNatural object to be created.</param>
        /// <returns>UserNatural instance returned from API.</returns>
        public async Task<UserNaturalDTO> CreatePayerAsync(UserNaturalPayerPostDTO user, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserNaturalDTO, UserNaturalPayerPostDTO>(MethodKey.UsersCreateNaturals,
                user, idempotentKey);
        }

        /// <summary>Creates new payer SCA user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserNaturalSca object to be created.</param>
        /// <returns>UserNaturalSca instance returned from API.</returns>
        public async Task<UserNaturalScaDTO> CreatePayerAsync(UserNaturalScaPayerPostDTO user,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserNaturalScaDTO, UserNaturalScaPayerPostDTO>(
                MethodKey.UsersCreateNaturalsSca, user, idempotentKey);
        }

        /// <summary>Creates new legal payer user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserLegal object to be created.</param>
        /// <returns>UserLegal instance returned from API.</returns>
        public async Task<UserLegalDTO> CreatePayerAsync(UserLegalPayerPostDTO user, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserLegalDTO, UserLegalPayerPostDTO>(MethodKey.UsersCreateLegals, user,
                idempotentKey);
        }

        /// <summary>Creates new legal payer SCA user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserLegalSca object to be created.</param>
        /// <returns>UserLegalSca instance returned from API.</returns>
        public async Task<UserLegalScaDTO> CreatePayerAsync(UserLegalScaPayerPostDTO user, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserLegalScaDTO, UserLegalScaPayerPostDTO>(
                MethodKey.UsersCreateLegalsSca, user, idempotentKey);
        }

        /// <summary>Creates new legal owner user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserLegal object to be created.</param>
        /// <returns>UserLegal instance returned from API.</returns>
        public async Task<UserLegalDTO> CreateOwnerAsync(UserLegalOwnerPostDTO user, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserLegalDTO, UserLegalOwnerPostDTO>(MethodKey.UsersCreateLegals, user,
                idempotentKey);
        }

        /// <summary>Creates new legal SCA owner user.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="user">UserLegalSca object to be created.</param>
        /// <returns>UserLegalSca instance returned from API.</returns>
        public async Task<UserLegalScaDTO> CreateOwnerAsync(UserLegalScaOwnerPostDTO user, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<UserLegalScaDTO, UserLegalScaOwnerPostDTO>(
                MethodKey.UsersCreateLegalsSca, user, idempotentKey);
        }


        /// <summary>Gets users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of User instances.</returns>
        public async Task<ListPaginated<UserDTO>> GetAllAsync(Pagination pagination = null, Sort sort = null)
        {
            return await this.GetListAsync<UserDTO>(MethodKey.UsersAll, pagination, sort);
        }

        /// <summary>Gets natural user.</summary>
        /// <param name="userId">UserNatural identifier.</param>
        /// <returns>UserNatural object returned from API.</returns>
        public async Task<UserNaturalDTO> GetNaturalAsync(string userId)
        {
            return await this.GetObjectAsync<UserNaturalDTO>(MethodKey.UsersGetNaturals, entitiesId: userId);
        }

        /// <summary>Gets SCA natural user.</summary>
        /// <param name="userId">UserNaturalSca identifier.</param>
        /// <returns>UserNaturalSca object returned from API.</returns>
        public async Task<UserNaturalScaDTO> GetNaturalScaAsync(string userId)
        {
            return await this.GetObjectAsync<UserNaturalScaDTO>(MethodKey.UsersGetNaturalsSca, entitiesId: userId);
        }

        /// <summary>Gets legal user.</summary>
        /// <param name="userId">UserLegal identifier.</param>
        /// <returns>UserLegal object returned from API.</returns>
        public async Task<UserLegalDTO> GetLegalAsync(string userId)
        {
            return await this.GetObjectAsync<UserLegalDTO>(MethodKey.UsersGetLegals, entitiesId: userId);
        }

        /// <summary>Gets legal SCA user.</summary>
        /// <param name="userId">UserLegalSca identifier.</param>
        /// <returns>UserLegalSca object returned from API.</returns>
        public async Task<UserLegalScaDTO> GetLegalScaAsync(string userId)
        {
            return await this.GetObjectAsync<UserLegalScaDTO>(MethodKey.UsersGetLegalsSca, entitiesId: userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance of UserNatural class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public async Task<UserNaturalDTO> UpdateNaturalAsync(UserNaturalPutDTO user, string userId)
        {
            return await this.UpdateObjectAsync<UserNaturalDTO, UserNaturalPutDTO>(MethodKey.UsersSaveNaturals, user,
                entitiesId: userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance of UserNaturalSca class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated SCA User object returned from API.</returns>
        public async Task<UserNaturalScaDTO> UpdateNaturalAsync(UserNaturalScaPutDTO user, string userId)
        {
            return await this.UpdateObjectAsync<UserNaturalScaDTO, UserNaturalScaPutDTO>(MethodKey.UsersSaveNaturalsSca,
                user, entitiesId: userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance UserLegal class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public async Task<UserLegalDTO> UpdateLegalAsync(UserLegalPutDTO user, string userId)
        {
            return await this.UpdateObjectAsync<UserLegalDTO, UserLegalPutDTO>(MethodKey.UsersSaveLegals, user,
                entitiesId: userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance UserLegalSca class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public async Task<UserLegalScaDTO> UpdateLegalAsync(UserLegalScaPutDTO user, string userId)
        {
            return await this.UpdateObjectAsync<UserLegalScaDTO, UserLegalScaPutDTO>(MethodKey.UsersSaveLegalsSca, user,
                entitiesId: userId);
        }

        /// <summary>Gets all user's wallets.</summary>
        /// <param name="userId">User identifier to get wallets of.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's wallets.</returns>
        public async Task<ListPaginated<WalletDTO>> GetWalletsAsync(string userId, Pagination pagination,
            Sort sort = null)
        {
            return await this.GetListAsync<WalletDTO>(MethodKey.UsersAllWallets, pagination, sort, entitiesId: userId);
        }

        /// <summary>Creates CA bank account.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountCaDTO> CreateBankAccountCaAsync(string userId, BankAccountCaPostDTO bankAccount,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<BankAccountCaDTO, BankAccountCaPostDTO>(
                MethodKey.UsersCreateBankAccountsCa, bankAccount, idempotentKey, userId);
        }

        /// <summary>Creates GB bank account.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountGbDTO> CreateBankAccountGbAsync(string userId, BankAccountGbPostDTO bankAccount,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<BankAccountGbDTO, BankAccountGbPostDTO>(
                MethodKey.UsersCreateBankAccountsGb, bankAccount, idempotentKey, userId);
        }

        /// <summary>Creates IBAN bank account.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountIbanDTO> CreateBankAccountIbanAsync(string userId,
            BankAccountIbanPostDTO bankAccount, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<BankAccountIbanDTO, BankAccountIbanPostDTO>(
                    MethodKey.UsersCreateBankAccountsIban, bankAccount, idempotentKey, userId);
        }

        /// <summary>Creates OTHER bank account.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountOtherDTO> CreateBankAccountOtherAsync(string userId,
            BankAccountOtherPostDTO bankAccount, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<BankAccountOtherDTO, BankAccountOtherPostDTO>(
                    MethodKey.UsersCreateBankAccountsOther, bankAccount, idempotentKey, userId);
        }

        /// <summary>Creates US bank account.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public async Task<BankAccountUsDTO> CreateBankAccountUsAsync(string userId, BankAccountUsPostDTO bankAccount,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<BankAccountUsDTO, BankAccountUsPostDTO>(
                MethodKey.UsersCreateBankAccountsUs, bankAccount, idempotentKey, userId);
        }

        /// <summary>Gets all user's bank accounts.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public async Task<ListPaginated<BankAccountDTO>> GetBankAccountsAsync(string userId, Pagination pagination,
            Sort sort = null)
        {
            return await this.GetListAsync<BankAccountDTO>(MethodKey.UsersAllBankAccount, pagination, sort,
                entitiesId: userId);
        }

        /// <summary>Gets bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountDTO> GetBankAccountAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        public async Task<BankAccountObsoleteDTO> GetBankAccountObsoleteAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountObsoleteDTO>(MethodKey.UsersGetBankAccount, userId,
                bankAccountId);
        }

        /// <summary>Gets CA bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountCaDTO> GetBankAccountCaAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountCaDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        public async Task<BankAccountCaObsoleteDTO> GetBankAccountCaObsoleteAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountCaObsoleteDTO>(MethodKey.UsersGetBankAccount, userId,
                bankAccountId);
        }

        /// <summary>Gets GB bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountGbDTO> GetBankAccountGbAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountGbDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        public async Task<BankAccountGbObsoleteDTO> GetBankAccountGbObsoleteAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountGbObsoleteDTO>(MethodKey.UsersGetBankAccount, userId,
                bankAccountId);
        }

        /// <summary>Gets IBAN bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountIbanDTO> GetBankAccountIbanAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountIbanDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        public async Task<BankAccountIbanObsoleteDTO> GetBankAccountIbanObsoleteAsync(string userId,
            string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountIbanObsoleteDTO>(MethodKey.UsersGetBankAccount, userId,
                bankAccountId);
        }

        /// <summary>Gets OTHER bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountOtherDTO> GetBankAccountOtherAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountOtherDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        public async Task<BankAccountOtherObsoleteDTO> GetBankAccountOtherObsoleteAsync(string userId,
            string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountOtherObsoleteDTO>(MethodKey.UsersGetBankAccount, userId,
                bankAccountId);
        }

        /// <summary>Gets US bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountUsDTO> GetBankAccountUsAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountUsDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        public async Task<BankAccountUsObsoleteDTO> GetBankAccountUsObsoleteAsync(string userId, string bankAccountId)
        {
            return await this.GetObjectAsync<BankAccountUsObsoleteDTO>(MethodKey.UsersGetBankAccount, userId,
                bankAccountId);
        }

        /// <summary>Updates bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be updated.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public async Task<BankAccountDTO> UpdateBankAccountAsync(string userId,
            DisactivateBankAccountPutDTO bankAccount, string bankAccountId)
        {
            return await this.UpdateObjectAsync<BankAccountDTO, DisactivateBankAccountPutDTO>(
                MethodKey.UsersSaveBankAccount, bankAccount, null, userId, bankAccountId);
        }

        /// <summary>Lists transactions for a bank account</summary>
        /// <param name="bankAccountId">Id of the bank account to get transactions</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of transactions for a bank account</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsForBankAccountAsync(string bankAccountId,
            Pagination pagination, FilterTransactions filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterTransactions();

            return await GetListAsync<TransactionDTO>(MethodKey.BankAccountsGetTransactions, pagination, sort,
                filters.GetValues(), entitiesId: bankAccountId);
        }

        /// <summary>Gets transactions for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's transactions.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(string userId, Pagination pagination,
            FilterTransactions filter, Sort sort = null)
        {
            return await this.GetListAsync<TransactionDTO>(MethodKey.UsersAllTransactions, pagination, sort,
                filter.GetValues(), entitiesId: userId);
        }

        /// <summary>Gets all cards for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's cards.</returns>
        public async Task<ListPaginated<CardDTO>> GetCardsAsync(string userId, Pagination pagination, Sort sort = null)
        {
            return await this.GetListAsync<CardDTO>(MethodKey.UsersAllCards, pagination, sort, entitiesId: userId);
        }

        /// <summary>Creates KycPage from byte array.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="binaryData">The byte array the KycPage will be created from.</param>
        public async Task CreateKycPageAsync(string userId, string kycDocumentId, byte[] binaryData,
            string idempotentKey = null)
        {
            var fileContent = Convert.ToBase64String(binaryData);

            var kycPage = new KycPagePostDTO(fileContent);

            var result = await this.CreateObjectAsync<KycPageDTO, KycPagePostDTO>(MethodKey.UsersCreateKycPage, kycPage,
                idempotentKey, userId, kycDocumentId);
        }

        /// <summary>Creates KycPage from file.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="filePath">Path to the file the KycPage will be created from.</param>
        public async Task CreateKycPageAsync(string userId, string kycDocumentId, string filePath,
            string idempotentKey = null)
        {
            var fileArray = File.ReadAllBytes(filePath);
            await CreateKycPageAsync(userId, kycDocumentId, fileArray, idempotentKey);
        }

        /// <summary>Creates KycDocument.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="type">Type of KycDocument.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public async Task<KycDocumentDTO> CreateKycDocumentAsync(string userId, KycDocumentType type, string tag = null,
            string idempotentKey = null)
        {
            var kycDocument = new KycDocumentPostDTO(type)
            {
                Tag = tag
            };

            return await this.CreateObjectAsync<KycDocumentDTO, KycDocumentPostDTO>(MethodKey.UsersCreateKycDocument,
                kycDocument, idempotentKey, userId);
        }

        /// <summary>Gets KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public async Task<KycDocumentDTO> GetKycDocumentAsync(string userId, string kycDocumentId)
        {
            return await this.GetObjectAsync<KycDocumentDTO>(MethodKey.UsersGetKycDocument, userId, kycDocumentId);
        }

        /// <summary>Updates KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocument">KycDocument entity instance to be updated.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public async Task<KycDocumentDTO> UpdateKycDocumentAsync(string userId, KycDocumentPutDTO kycDocument,
            string kycDocumentId)
        {
            return await this.UpdateObjectAsync<KycDocumentDTO, KycDocumentPutDTO>(MethodKey.UsersSaveKycDocument,
                kycDocument, null, userId, kycDocumentId);
        }

        /// <summary>Gets a list of all the uploaded documents for the particular user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of user's uploaded documents.</returns>
        public async Task<ListPaginated<KycDocumentDTO>> GetKycDocumentsAsync(string userId, Pagination pagination,
            FilterKycDocuments filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterKycDocuments();

            return await this.GetListAsync<KycDocumentDTO>(MethodKey.UsersGetKycDocuments, pagination, sort,
                filter.GetValues(), entitiesId: userId);
        }

        /// <summary>Gets Emoney object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="currency">Currency ISO code.</param>
        /// <returns>Emoney object returned from API.</returns>
        public async Task<EmoneyDTO> GetEmoneyAsync(string userId, CurrencyIso currency = CurrencyIso.NotSpecified)
        {
            Dictionary<string, string> additionalUrlParams = null;
            if (currency != CurrencyIso.NotSpecified)
            {
                additionalUrlParams = new Dictionary<string, string>
                {
                    { "currency", currency.ToString() }
                };
            }

            return await this.GetObjectAsync<EmoneyDTO>(MethodKey.UsersEmoneyGet,
                additionalUrlParams: additionalUrlParams, userId, currency.ToString());
        }

        /// <summary>Gets Emoney object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="year">Emoney accounts for year</param>
        /// <param name="currency">Currency ISO code.</param>
        /// <returns>Emoney object returned from API.</returns>
        public async Task<EmoneyDTO> GetEmoneyForYearAsync(string userId, string year,
            CurrencyIso currency = CurrencyIso.NotSpecified)
        {
            Dictionary<string, string> additionalUrlParams = null;
            if (currency != CurrencyIso.NotSpecified)
            {
                additionalUrlParams = new Dictionary<string, string>
                {
                    { "currency", currency.ToString() }
                };
            }

            return await this.GetObjectAsync<EmoneyDTO>(MethodKey.UsersEmoneyYearGet, additionalUrlParams, userId, year,
                currency.ToString());
        }

        /// <summary>Gets Emoney object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="year">Emoney accounts for year</param>
        /// <param name="month">Emoney accounts for month</param>
        /// <param name="currency">Currency ISO code.</param>
        /// <returns>Emoney object returned from API.</returns>
        public async Task<EmoneyDTO> GetEmoneyForYearAndMonthAsync(string userId, string year, string month,
            CurrencyIso currency = CurrencyIso.NotSpecified)
        {
            Dictionary<string, string> additionalUrlParams = null;
            if (currency != CurrencyIso.NotSpecified)
            {
                additionalUrlParams = new Dictionary<string, string>
                {
                    { "currency", currency.ToString() }
                };
            }

            return await this.GetObjectAsync<EmoneyDTO>(MethodKey.UsersEmoneyYearMonthGet, additionalUrlParams, userId,
                year, month, currency.ToString());
        }

        /// <summary>
        /// Gets the user regulatory async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UsersBlockStatusDTO> GetUserRegulatoryAsync(string userId)
        {
            return await this.GetObjectAsync<UsersBlockStatusDTO>(MethodKey.UsersRegulatory, entitiesId: userId);
        }

        /// <summary>Transition a Natural Payer to Owner and enroll them in SCA</summary>
        /// <param name="user">Instance of CategorizeUserNaturalPutDTO class.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated SCA User object returned from API.</returns>
        public async Task<UserNaturalScaDTO> CategorizeNaturalAsync(CategorizeUserNaturalPutDTO user, string userId)
        {
            return await this.UpdateObjectAsync<UserNaturalScaDTO, CategorizeUserNaturalPutDTO>(
                MethodKey.UsersCategorizeNatural, user, entitiesId: userId);
        }

        /// <summary>Transition a Legal Payer to Owner and enroll them in SCA</summary>
        /// <param name="user">Instance of CategorizeUserLegalPutDTO class.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated SCA User object returned from API.</returns>
        public async Task<UserLegalScaDTO> CategorizeLegalAsync(CategorizeUserLegalPutDTO user, string userId)
        {
            return await this.UpdateObjectAsync<UserLegalScaDTO, CategorizeUserLegalPutDTO>(
                MethodKey.UsersCategorizeLegal, user, entitiesId: userId);
        }

        /// <summary>Obtain an SCA redirection link to enroll an Owner user</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>ScaEnrollmentResultDTO instance returned from API.</returns>
        public async Task<ScaEnrollmentResultDTO> EnrollSca(string userId, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<ScaEnrollmentResultDTO, EntityPostBase>(MethodKey.UsersEnrollSca, null,
                idempotentKey, userId);
        }

        /// <summary>
        /// Close a natural user (change status to CLOSED). The resource remains available for historical purposes.
        /// </summary>
        /// <param name="userId"></param>
        public async Task CloseNaturalAsync(string userId)
        {
            await this.DeleteObjectAsync(MethodKey.UsersCloseNatural, userId);
        }
        
        /// <summary>
        /// Close a legal user (change status to CLOSED). The resource remains available for historical purposes.
        /// </summary>
        /// <param name="userId"></param>
        public async Task CloseLegalAsync(string userId)
        {
            await this.DeleteObjectAsync(MethodKey.UsersCloseLegal, userId);
        }
    }
}