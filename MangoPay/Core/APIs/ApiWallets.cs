using MangoPay.Entities;
using System;
using System.Collections.Generic;

namespace MangoPay.Core
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
        public WalletDTO Create(WalletPostDTO wallet)
        {
            return this.CreateObject<WalletDTO, WalletPostDTO>(MethodKey.WalletsCreate, wallet);
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
        /// <returns>Transactions for wallet returned from API.</returns>
        public List<TransactionDTO> GetTransactions(String walletId, Pagination pagination, FilterTransactions filter)
        {
            return this.GetList<TransactionDTO>(MethodKey.WalletsAllTransactions, pagination, walletId, filter.GetValues());
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public List<TransactionDTO> GetTransactions(String walletId, Pagination pagination)
        {
            return GetTransactions(walletId, pagination, new FilterTransactions());
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public List<TransactionDTO> GetTransactions(String walletId)
        {
            return GetTransactions(walletId, null, new FilterTransactions());
        }
    }
}
