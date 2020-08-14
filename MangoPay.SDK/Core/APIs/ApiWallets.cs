using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for wallets.</summary>
    public class ApiWallets : ApiBase
    {
        /// <summary>Instantiates new ApiWallets object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiWallets(MangoPayApi root) : base(root) { }

        /// <summary>Creates new wallet.</summary>
        /// <param name="wallet">Wallet instance to be created.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public async Task<WalletDTO> CreateAsync(WalletPostDTO wallet)
        {
			return await CreateAsync(null, wallet);
        }

		/// <summary>Creates new wallet.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="wallet">Wallet instance to be created.</param>
		/// <returns>Wallet instance returned from API.</returns>
		public async Task<WalletDTO> CreateAsync(String idempotencyKey, WalletPostDTO wallet)
		{
			return await this.CreateObjectAsync<WalletDTO, WalletPostDTO>(idempotencyKey, MethodKey.WalletsCreate, wallet);
		}

        /// <summary>Gets wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public async Task<WalletDTO> GetAsync(String walletId)
        {
            return await this.GetObjectAsync<WalletDTO>(MethodKey.WalletsGet, walletId);
        }

        /// <summary>Updates wallet.</summary>
        /// <param name="wallet">Wallet object to save.</param>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public async Task<WalletDTO> UpdateAsync(WalletPutDTO wallet, String walletId)
        {
            return await this.UpdateObjectAsync<WalletDTO, WalletPutDTO>(MethodKey.WalletsSave, wallet, walletId);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(String walletId, Pagination pagination, FilterTransactions filter, Sort sort = null)
        {
            return await this.GetListAsync<TransactionDTO>(MethodKey.WalletsAllTransactions, pagination, sort, filter.GetValues(),walletId);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(String walletId, Pagination pagination, Sort sort = null)
        {
            return await GetTransactionsAsync(walletId, pagination, new FilterTransactions(), sort);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(String walletId)
        {
            return await GetTransactionsAsync(walletId, null, new FilterTransactions(), null);
        }

        /// <summary>Creates new wallet.</summary>
        /// <param name="wallet">Wallet instance to be created.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public WalletDTO Create(WalletPostDTO wallet)
        {
            return Create(null, wallet);
        }

        /// <summary>Creates new wallet.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="wallet">Wallet instance to be created.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public WalletDTO Create(String idempotencyKey, WalletPostDTO wallet)
        {
            return this.CreateObject<WalletDTO, WalletPostDTO>(idempotencyKey, MethodKey.WalletsCreate, wallet);
        }

        /// <summary>Gets wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public WalletDTO Get(String walletId)
        {
            return this.GetObject<WalletDTO>(MethodKey.WalletsGet, walletId);
        }

        /// <summary>Updates wallet.</summary>
        /// <param name="wallet">Wallet object to save.</param>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public WalletDTO Update(WalletPutDTO wallet, String walletId)
        {
            return this.UpdateObject<WalletDTO, WalletPutDTO>(MethodKey.WalletsSave, wallet, walletId);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public ListPaginated<TransactionDTO> GetTransactions(String walletId, Pagination pagination, FilterTransactions filter, Sort sort = null)
        {
            return this.GetList<TransactionDTO>(MethodKey.WalletsAllTransactions, pagination, sort, filter.GetValues(), walletId);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public ListPaginated<TransactionDTO> GetTransactions(String walletId, Pagination pagination, Sort sort = null)
        {
            return GetTransactions(walletId, pagination, new FilterTransactions(), sort);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public ListPaginated<TransactionDTO> GetTransactions(String walletId)
        {
            return GetTransactions(walletId, null, new FilterTransactions(), null);
        }
    }
}
