using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
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
        public User Get(String userId)
        {
            return this.GetObject<User>("users_get", userId);
        }

        /// <summary>Creates new user.</summary>
        /// <param name="user">UserNatural object to be created.</param>
        /// <returns>UserNatural instance returned from API.</returns>
        public UserNatural Create(UserNatural user)
        {
            return this.CreateObject<UserNatural>("users_createnaturals", user);
        }

        /// <summary>Creates new user.</summary>
        /// <param name="user">UserLegal object to be created.</param>
        /// <returns>UserLegal instance returned from API.</returns>
        public UserLegal Create(UserLegal user)
        {
            return this.CreateObject<UserLegal>("users_createlegals", user);
        }

        /// <summary>Gets users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of User instances.</returns>
        public List<User> GetAll(Pagination pagination)
        {
            return this.GetList<User>("users_all", pagination);
        }

        /// <summary>Gets first page of users.</summary>
        /// <returns>Collection of User instances.</returns>
        public List<User> GetAll()
        {
            return GetAll(null);
        }

        /// <summary>Gets natural user.</summary>
        /// <param name="userId">UserNatural identifier.</param>
        /// <returns>UserNatural object returned from API.</returns>
        public UserNatural GetNatural(String userId)
        {
            return this.GetObject<UserNatural>("users_getnaturals", userId);
        }

        /// <summary>Gets legal user.</summary>
        /// <param name="userId">UserLegal identifier.</param>
        /// <returns>UserLegal object returned from API.</returns>
        public UserLegal GetLegal(String userId)
        {
            return this.GetObject<UserLegal>("users_getlegals", userId);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="user">Instance of UserNatural or UserLegal class to be updated.</param>
        /// <returns>Updated User object returned from API.</returns>
        public User Update(User user)
        {
            if (user is UserNatural)
                return this.UpdateObject<UserNatural>("users_savenaturals", (UserNatural)user);
            else if (user is UserLegal)
                return this.UpdateObject<UserLegal>("users_savelegals", (UserLegal)user);
            else
                throw new Exception("Unsupported user entity type.");
        }

		/// <summary>Gets all user's wallets.</summary>
		/// <param name="userId">User identifier to get wallets of.</param>
		/// <param name="pagination">Pagination.</param>
		/// <returns>Collection of user's wallets.</returns>
		public List<Wallet> GetWallets(String userId, Pagination pagination)
		{
			return this.GetList<Wallet>("users_allwallets", pagination, userId);
		}

        /// <summary>Creates bank account for user.</summary>
        /// <param name="userId">User identifier to create bank account for.</param>
        /// <param name="bankAccount">Bank account object to be created.</param>
        /// <returns>Created bank account object returned from API.</returns>
        public BankAccount CreateBankAccount(String userId, BankAccount bankAccount)
        {
            String type = this.GetBankAccountType(bankAccount);
            return this.CreateObject<BankAccount>("users_createbankaccounts_" + type, bankAccount, userId);
        }

        /// <summary>Gets all user's bank accounts.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public List<BankAccount> GetBankAccounts(String userId, Pagination pagination)
        {
            return this.GetList<BankAccount>("users_allbankaccount", pagination, userId);
        }

        /// <summary>Gets first page of all bank accounts of user.</summary>
        /// <param name="userId">User identifier to get bank accounts of.</param>
        /// <returns>Collection of user's bank accounts.</returns>
        public List<BankAccount> GetBankAccounts(String userId)
        {
            return GetBankAccounts(userId, null);
        }

        /// <summary>Gets bank account of user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="bankAccountId">Bank account identifier.</param>
        /// <returns>Bank account object returned from API.</returns>
        public BankAccount GetBankAccount(String userId, String bankAccountId)
        {
            return this.GetObject<BankAccount>("users_getbankaccount", userId, bankAccountId);
        }

        /// <summary>Gets transactions for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <returns>Collection of user's transactions.</returns>
        public List<Transaction> GetTransactions(String userId, Pagination pagination, FilterTransactions filter)
        {
            return this.GetList<Transaction>("users_alltransactions", pagination, userId, filter.GetValues());
        }

        /// <summary>Gets all cards for user.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of user's cards.</returns>
        public List<Card> GetCards(String userId, Pagination pagination)
        {
            return this.GetList<Card>("users_allcards", pagination, userId);
        }

        /// <summary>Creates KycPage from byte array.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <param name="binaryData">The byte array the KycPage will be created from.</param>
        public void CreateKycPage(String userId, String kycDocumentId, byte[] binaryData)
        {
            KycPage kycPage = new KycPage();

            String fileContent = Convert.ToBase64String(binaryData);

            kycPage.File = fileContent;

            this.CreateObject<KycPage>("users_createkycpage", kycPage, userId, kycDocumentId);
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
        public KycDocument CreateKycDocument(String userId, KycDocumentType type, string tag = null)
        {
            KycDocument kycDocument = new KycDocument();
            kycDocument.Type = type.ToString();
            kycDocument.Tag = tag;

            return this.CreateObject<KycDocument>("users_createkycdocument", kycDocument, userId);
        }

        /// <summary>Gets KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocumentId">KycDocument identifier.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public KycDocument GetKycDocument(String userId, String kycDocumentId)
        {
            return this.GetObject<KycDocument>("users_getkycdocument", userId, kycDocumentId);
        }

        /// <summary>Updates KycDocument.</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="kycDocument">KycDocument entity instance to be updated.</param>
        /// <returns>KycDocument object returned from API.</returns>
        public KycDocument UpdateKycDocument(String userId, KycDocument kycDocument)
        {
            return this.UpdateObject<KycDocument>("users_savekycdocument", kycDocument, userId);
        }

        private String GetBankAccountType(BankAccount bankAccount)
        {
            if (bankAccount.Details == null)
                throw new Exception("Details is not defined.");

            String className = bankAccount.Details.GetType().Name.Replace("BankAccountDetails", "");
            return className.ToLower();
        }
    }
}
