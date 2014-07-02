using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Wallet Create(Wallet wallet)
        {
            return this.CreateObject<Wallet>("wallets_create", wallet);
        }

        /// <summary>Gets wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public Wallet Get(String walletId)
        {
            return this.GetObject<Wallet>("wallets_get", walletId);
        }

        /// <summary>Updates wallet.</summary>
        /// <param name="wallet">Wallet object to save.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public Wallet Update(Wallet wallet)
        {
            return this.UpdateObject<Wallet>("wallets_save", wallet);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public List<Transaction> GetTransactions(String walletId, Pagination pagination, FilterTransactions filter)
        {
            return this.GetList<Transaction>("wallets_alltransactions", pagination, walletId, filter.GetValues());
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public List<Transaction> GetTransactions(String walletId, Pagination pagination)
        {
            return GetTransactions(walletId, pagination, new FilterTransactions());
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public List<Transaction> GetTransactions(String walletId)
        {
            return GetTransactions(walletId, null, new FilterTransactions());
        }
    }
}
