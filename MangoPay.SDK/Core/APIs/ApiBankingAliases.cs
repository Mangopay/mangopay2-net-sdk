using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;

namespace MangoPay.SDK.Core.APIs
{
	/// <summary>API for manage banking aliases.</summary>
	public class ApiBankingAliases : ApiBase
    {
        /// <summary>Instantiates new ApiWallets object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiBankingAliases(MangoPayApi root) : base(root) { }

		/// <summary>Create an IBAN banking alias.</summary>
		/// <param name="walletId">Wallet identifier.</param>
		/// <param name="bankingAlias">IBAN banking alias instance to be created.</param>
		/// <returns>Banking alias object returned from API.</returns>
		public BankingAliasIbanDTO CreateIban(String walletId, BankingAliasIbanPostDTO bankingAlias)
		{
			return this.CreateObject<BankingAliasIbanDTO, BankingAliasIbanPostDTO>(null, MethodKey.BankingAliasCreateIban, bankingAlias, walletId);
		}

		/// <summary>Gets details of a banking alias.</summary>
		/// <param name="bankingAliasId">Banking alias identifier.</param>
		/// <returns>Banking alias object returned from API.</returns>
		public BankingAliasDTO Get(String bankingAliasId)
        {
            return this.GetObject<BankingAliasDTO>(MethodKey.BankingAliasGet, bankingAliasId);
        }

		/// <summary>Gets details of a IBAN banking alias.</summary>
		/// <param name="bankingAliasId">Banking alias identifier.</param>
		/// <returns>IBAN banking alias object returned from API.</returns>
		public BankingAliasIbanDTO GetIban(String bankingAliasId)
		{
			return this.GetObject<BankingAliasIbanDTO>(MethodKey.BankingAliasGet, bankingAliasId);
		}

		/// <summary>Gets list of a banking aliases for a wallet.</summary>
		/// <param name="walletId">Wallet identifier.</param>
		/// <param name="pagination">Pagination.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>Collection of banking aliases instances.</returns>
		public ListPaginated<BankingAliasDTO> GetAll(string walletId, Pagination pagination, Sort sort = null)
		{
			return this.GetList<BankingAliasDTO>(MethodKey.BankingAliasAll, pagination, walletId, sort);
		}

		/// <summary>Updates bank account.</summary>
		/// <param name="bankingAlias">Banking alias instance to be updated.</param>
		/// <param name="bankingAliasId">Banking alias identifier.</param>
		/// <returns>Banking alias object returned from API.</returns>
		public BankingAliasDTO Update(BankingAliasPutDTO bankingAlias, String bankingAliasId)
		{
			return this.UpdateObject<BankingAliasDTO, BankingAliasPutDTO>(MethodKey.BankingAliasSave, bankingAlias, bankingAliasId);
		}
	}
}
