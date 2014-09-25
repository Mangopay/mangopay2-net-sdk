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
    /// <summary>API for users.</summary>
    public class ApiUsers : ApiBase
    {
        /// <summary>Instantiates new ApiUsers object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiUsers(MangoPayApi root) : base(root) { }

        /// <summary>Gets user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>User instance returned from API, which is either of UserNatural or UserLegal type.</returns>
        public UserDTO Get(String userId)
        {
            return this.GetObject<UserDTO>(MethodKey.UsersGet, userId);
        }

        /// <summary>Creates new user.</summary>
        /// <param name="user">UserNatural object to be created.</param>
        /// <returns>UserNatural instance returned from API.</returns>
        public UserNaturalDTO Create(UserNaturalPostDTO user)
        {
            return this.CreateObject<UserNaturalDTO, UserNaturalPostDTO>(MethodKey.UsersCreateNaturals, user);
        }

        /// <summary>Creates new user.</summary>
        /// <param name="user">UserLegal object to be created.</param>
        /// <returns>UserLegal instance returned from API.</returns>
        public UserLegalDTO Create(UserLegalPostDTO user)
        {
            return this.CreateObject<UserLegalDTO, UserLegalPostDTO>(MethodKey.UsersCreateLegals, user);
        }

        /// <summary>Gets users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of User instances.</returns>
        public List<UserDTO> GetAll(Pagination pagination)
        {
            return this.GetList<UserDTO>(MethodKey.UsersAll, pagination);
        }

        /// <summary>Gets first page of users.</summary>
        /// <returns>Collection of User instances.</returns>
        public List<UserDTO> GetAll()
        {
            return GetAll(null);
        }

        /// <summary>Gets natural user.</summary>
        /// <param name="userId">UserNatural identifier.</param>
        /// <returns>UserNatural object returned from API.</returns>
        public UserNaturalDTO GetNatural(String userId)
        {
            return this.GetObject<UserNaturalDTO>(MethodKey.UsersGetNaturals, userId);
        }

        /// <summary>Gets legal user.</summary>
        /// <param name="userId">UserLegal identifier.</param>
        /// <returns>UserLegal object returned from API.</returns>
        public UserLegalDTO GetLegal(String userId)
        {
            return this.GetObject<UserLegalDTO>(MethodKey.UsersGetLegals, userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance of UserNatural class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public UserNaturalDTO UpdateNatural(UserNaturalPutDTO user, String userId)
        {
            return this.UpdateObject<UserNaturalDTO, UserNaturalPutDTO>(MethodKey.UsersSaveNaturals, user, userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance UserLegal class to be updated.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Updated User object returned from API.</returns>
        public UserLegalDTO UpdateLegal(UserLegalPutDTO user, String userId)
        {
            return this.UpdateObject<UserLegalDTO, UserLegalPutDTO>(MethodKey.UsersSaveLegals, user, userId);
        }

		/// <summary>Gets all user's wallets.</summary>
		/// <param name="userId">User identifier to get wallets of.</param>
		/// <param name="pagination">Pagination.</param>
		/// <returns>Collection of user's wallets.</returns>
		public List<WalletDTO> GetWallets(String userId, Pagination pagination)
		{
			return this.GetList<WalletDTO>(MethodKey.UsersAllWallets, pagination, userId);
		}

        /// <summary>Creates CA bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public BankAccountCaDTO CreateBankAccountCa(String userId, BankAccountCaPostDTO bankAccount)
        {
            return this.CreateObject<BankAccountCaDTO, BankAccountCaPostDTO>(MethodKey.UsersCreateBankAccountsCa, bankAccount, userId);
        }

        /// <summary>Creates GB bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public BankAccountGbDTO CreateBankAccountGb(String userId, BankAccountGbPostDTO bankAccount)
        {
            return this.CreateObject<BankAccountGbDTO, BankAccountGbPostDTO>(MethodKey.UsersCreateBankAccountsGb, bankAccount, userId);
        }

        /// <summary>Creates IBAN bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public BankAccountIbanDTO CreateBankAccountIban(String userId, BankAccountIbanPostDTO bankAccount)
        {
            return this.CreateObject<BankAccountIbanDTO, BankAccountIbanPostDTO>(MethodKey.UsersCreateBankAccountsIban, bankAccount, userId);
        }

        /// <summary>Creates OTHER bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public BankAccountOtherDTO CreateBankAccountOther(String userId, BankAccountOtherPostDTO bankAccount)
        {
            return this.CreateObject<BankAccountOtherDTO, BankAccountOtherPostDTO>(MethodKey.UsersCreateBankAccountsOther, bankAccount, userId);
        }

        /// <summary>Creates US bank account.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccount">Bank account instance to be created.</param>
        /// <returns>Bank account instance returned from API.</returns>
        public BankAccountUsDTO CreateBankAccountUs(String userId, BankAccountUsPostDTO bankAccount)
        {
            return this.CreateObject<BankAccountUsDTO, BankAccountUsPostDTO>(MethodKey.UsersCreateBankAccountsUs, bankAccount, userId);
        }

        /// <summary>Gets all user's bank accounts.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public List<BankAccountDTO> GetBankAccounts(String userId, Pagination pagination)
        {
            return this.GetList<BankAccountDTO>(MethodKey.UsersAllBankAccount, pagination, userId);
        }

        /// <summary>Gets first page of all bank accounts of user.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public List<BankAccountDTO> GetBankAccounts(String userId)
        {
            return GetBankAccounts(userId, null);
        }

        /// <summary>Gets bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccountDTO GetBankAccount(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccountDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        /// <summary>Gets CA bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccountCaDTO GetBankAccountCa(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccountCaDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        /// <summary>Gets GB bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccountGbDTO GetBankAccountGb(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccountGbDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        /// <summary>Gets IBAN bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccountIbanDTO GetBankAccountIban(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccountIbanDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        /// <summary>Gets OTHER bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccountOtherDTO GetBankAccountOther(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccountOtherDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        /// <summary>Gets US bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccountUsDTO GetBankAccountUs(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccountUsDTO>(MethodKey.UsersGetBankAccount, userId, bankAccountId);
        }

        /// <summary>Gets transactions for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <returns>Collection of user's transactions.</returns>
        public List<TransactionDTO> GetTransactions(String userId, Pagination pagination, FilterTransactions filter)
        {
            return this.GetList<TransactionDTO>(MethodKey.UsersAllTransactions, pagination, userId, null, filter.GetValues());
        }

        /// <summary>Gets all cards for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of user's cards.</returns>
        public List<CardDTO> GetCards(String userId, Pagination pagination)
        {
            return this.GetList<CardDTO>(MethodKey.UsersAllCards, pagination, userId);
        }

        /// <summary>Creates KycPage from byte array.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="binaryData">The byte array the KycPage will be created from.</param>
        public void CreateKycPage(String userId, String kycDocumentId, byte[] binaryData)
        {
            String fileContent = Convert.ToBase64String(binaryData);

            KycPagePostDTO kycPage = new KycPagePostDTO(fileContent);

            this.CreateObject<KycPageDTO, KycPagePostDTO>(MethodKey.UsersCreateKycPage, kycPage, userId, kycDocumentId);
        }

        /// <summary>Creates KycPage from file.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="filePath">Path to the file the KycPage will be created from.</param>
        public void CreateKycPage(String userId, String kycDocumentId, String filePath)
        {
            byte[] fileArray = File.ReadAllBytes(filePath);
            CreateKycPage(userId, kycDocumentId, fileArray);
        }

        /// <summary>Creates KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="type">Type of KycDocument.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public KycDocumentDTO CreateKycDocument(String userId, KycDocumentType type, string tag = null)
        {
            KycDocumentPostDTO kycDocument = new KycDocumentPostDTO(type);
            kycDocument.Tag = tag;

            return this.CreateObject<KycDocumentDTO, KycDocumentPostDTO>(MethodKey.UsersCreateKycDocument, kycDocument, userId);
        }

        /// <summary>Gets KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public KycDocumentDTO GetKycDocument(String userId, String kycDocumentId)
        {
            return this.GetObject<KycDocumentDTO>(MethodKey.UsersGetKycDocument, userId, kycDocumentId);
        }

        /// <summary>Updates KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocument">KycDocument entity instance to be updated.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public KycDocumentDTO UpdateKycDocument(String userId, KycDocumentPutDTO kycDocument, String kycDocumentId)
        {
            return this.UpdateObject<KycDocumentDTO, KycDocumentPutDTO>(MethodKey.UsersSaveKycDocument, kycDocument, userId, kycDocumentId);
        }

        /// <summary>Gets a list of all the uploaded documents for the particular user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of user's uploaded documents.</returns>
        public List<KycDocumentDTO> GetKycDocuments(String userId, Pagination pagination)
        {
            return this.GetList<KycDocumentDTO>(MethodKey.UsersGetKycDocuments, pagination, userId);
        }
    }
}
