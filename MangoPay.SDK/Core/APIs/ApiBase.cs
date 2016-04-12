using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>Base class for all Api classes.</summary>
    public abstract class ApiBase
    {
        /// <summary>Root/parent instance that holds the OAuthToken and Configuration instance.</summary>
        protected MangoPayApi _root;

        /// <summary>Array with REST URL and request type.</summary>
        private Dictionary<MethodKey, String[]> _methods = new Dictionary<MethodKey, String[]> 
        {
            { MethodKey.AuthenticationBase, new String[] { "/api/clients/", RequestType.POST } },
            { MethodKey.AuthenticationOAuth, new String[] { "/oauth/token", RequestType.POST } },
        
            { MethodKey.EventsAll, new String[] { "/events", RequestType.GET } },
        
            { MethodKey.HooksCreate, new String[] { "/hooks", RequestType.POST } },
            { MethodKey.HooksAll, new String[] { "/hooks", RequestType.GET } },
            { MethodKey.HooksGet, new String[] { "/hooks/{0}", RequestType.GET } },
            { MethodKey.HooksSave, new String[] { "/hooks/{0}", RequestType.PUT } },
     
            { MethodKey.CardRegistrationCreate, new String[] { "/cardregistrations", RequestType.POST } },
            { MethodKey.CardRegistrationGet, new String[] { "/cardregistrations/{0}", RequestType.GET } },
            { MethodKey.CardRegistrationSave, new String[] { "/cardregistrations/{0}", RequestType.PUT } },
        
            { MethodKey.PreauthorizationCreate, new String[] { "/preauthorizations/card/direct", RequestType.POST } },
            { MethodKey.PreauthorizationGet, new String[] { "/preauthorizations/{0}", RequestType.GET } },
            { MethodKey.PreauthorizationSave, new String[] { "/preauthorizations/{0}", RequestType.PUT } },
        
            { MethodKey.CardGet, new String[] { "/cards/{0}", RequestType.GET } },
            { MethodKey.CardSave, new String[] { "/cards/{0}", RequestType.PUT } },
        
            { MethodKey.PayinsCardWebCreate, new String[] { "/payins/card/web/", RequestType.POST } },
			{ MethodKey.PayinsCardWebGetCardData, new String[] { "/payins/card/web/{0}/extended/", RequestType.GET } },
            { MethodKey.PayinsCardDirectCreate, new String[] { "/payins/card/direct/", RequestType.POST } },
            { MethodKey.PayinsGet, new String[] { "/payins/{0}", RequestType.GET } },
            { MethodKey.PayinsCreateRefunds, new String[] { "/payins/{0}/refunds", RequestType.POST } },
            { MethodKey.PayinsGetRefunds, new String[] { "/payins/{0}/refunds", RequestType.GET } },
        
            { MethodKey.PayinsPreauthorizedDirectCreate, new String[] { "/payins/preauthorized/direct/", RequestType.POST } },
            { MethodKey.PayinsBankwireDirectCreate, new String[] { "/payins/bankwire/direct/", RequestType.POST } },
            { MethodKey.PayinsDirectDebitCreate, new String[] { "/payins/directdebit/web", RequestType.POST } },
        
            { MethodKey.PayoutsBankwireCreate, new String[] { "/payouts/bankwire/", RequestType.POST } },
            { MethodKey.PayoutsGet, new String[] { "/payouts/{0}", RequestType.GET } },
        
            { MethodKey.RefundsGet, new String[] { "/refunds/{0}", RequestType.GET } },
        
            { MethodKey.TransfersCreate, new String[] { "/transfers/", RequestType.POST } },
            { MethodKey.TransfersGet, new String[] { "/transfers/{0}", RequestType.GET } },
            { MethodKey.TransfersGetRefunds, new String[] { "/transfers/{0}/refunds", RequestType.GET } },
            { MethodKey.TransfersCreateRefunds, new String[] { "/transfers/{0}/refunds", RequestType.POST } },
        
            { MethodKey.UsersAll, new String[] { "/users", RequestType.GET } },
            { MethodKey.UsersAllWallets, new String[] { "/users/{0}/wallets", RequestType.GET } },
            { MethodKey.UsersAllBankAccount, new String[] { "/users/{0}/bankaccounts", RequestType.GET } },
            { MethodKey.UsersAllCards, new String[] { "/users/{0}/cards", RequestType.GET } },
            { MethodKey.UsersAllTransactions, new String[] { "/users/{0}/transactions", RequestType.GET } },
            { MethodKey.UsersCreateNaturals, new String[] { "/users/natural", RequestType.POST } },
            { MethodKey.UsersCreateLegals, new String[] { "/users/legal", RequestType.POST } },
            { MethodKey.UsersCreateKycDocument, new String[] { "/users/{0}/KYC/documents", RequestType.POST } },
            { MethodKey.UsersCreateKycPage, new String[] { "/users/{0}/KYC/documents/{1}/pages", RequestType.POST } },
            { MethodKey.UsersCreateBankAccountsIban, new String[] { "/users/{0}/bankaccounts/iban", RequestType.POST } },
            { MethodKey.UsersCreateBankAccountsGb, new String[] { "/users/{0}/bankaccounts/gb", RequestType.POST } },
            { MethodKey.UsersCreateBankAccountsUs, new String[] { "/users/{0}/bankaccounts/us", RequestType.POST } },
            { MethodKey.UsersCreateBankAccountsCa, new String[] { "/users/{0}/bankaccounts/ca", RequestType.POST } },
            { MethodKey.UsersCreateBankAccountsOther, new String[] { "/users/{0}/bankaccounts/other", RequestType.POST } },
            { MethodKey.UsersGet, new String[] { "/users/{0}", RequestType.GET } },
            { MethodKey.UsersGetNaturals, new String[] { "/users/natural/{0}", RequestType.GET } },
            { MethodKey.UsersGetLegals, new String[] { "/users/legal/{0}", RequestType.GET } },
            { MethodKey.UsersGetKycDocument, new String[] { "/users/{0}/KYC/documents/{1}", RequestType.GET } },
            { MethodKey.UsersGetKycDocuments, new String[] { "/users/{0}/KYC/documents", RequestType.GET } },
            { MethodKey.UsersGetBankAccount, new String[] { "/users/{0}/bankaccounts/{1}", RequestType.GET } },
            { MethodKey.UsersSaveNaturals, new String[] { "/users/natural/{0}", RequestType.PUT } },
            { MethodKey.UsersSaveLegals, new String[] { "/users/legal/{0}", RequestType.PUT } },
            { MethodKey.UsersSaveKycDocument, new String[] { "/users/{0}/KYC/documents/{1}", RequestType.PUT } },
        
            { MethodKey.WalletsCreate, new String[] { "/wallets", RequestType.POST } },
            { MethodKey.WalletsAllTransactions, new String[] { "/wallets/{0}/transactions", RequestType.GET } },
            { MethodKey.WalletsGet, new String[] { "/wallets/{0}", RequestType.GET } },
            { MethodKey.WalletsSave, new String[] { "/wallets/{0}", RequestType.PUT } },

            { MethodKey.ClientGetKycDocuments, new String[] { "/KYC/documents", RequestType.GET } },
            { MethodKey.GetKycDocument, new String[] { "/KYC/documents/{0}", RequestType.GET } },

			{ MethodKey.ClientGetWalletsDefault, new String[] { "/clients/wallets", RequestType.GET } },
			{ MethodKey.ClientGetWalletsFees, new String[] { "/clients/wallets/fees", RequestType.GET } },
			{ MethodKey.ClientGetWalletsCredit, new String[] { "/clients/wallets/credit", RequestType.GET } },
			{ MethodKey.ClientGetWalletsDefaultWithCurrency, new String[] { "/clients/wallets/{0}", RequestType.GET } },
			{ MethodKey.ClientGetWalletsFeesWithCurrency, new String[] { "/clients/wallets/fees/{0}", RequestType.GET } },
			{ MethodKey.ClientGetWalletsCreditWithCurrency, new String[] { "/clients/wallets/credit/{0}", RequestType.GET } },
			{ MethodKey.ClientGetTransactions, new String[] { "/clients/transactions", RequestType.GET } },
			{ MethodKey.ClientGetWalletTransactions, new String[] { "/clients/wallets/{0}/{1}/transactions", RequestType.GET } },
			{ MethodKey.ClientCreateBankwireDirect, new String[] { "/clients/payins/bankwire/direct", RequestType.POST } },
			{ MethodKey.ClientGet, new String[] { "/clients", RequestType.GET } },
			{ MethodKey.ClientSave, new String[] { "/clients", RequestType.PUT } },
			{ MethodKey.ClientUploadLogo, new String[] { "/clients/logo", RequestType.PUT } },

			{ MethodKey.DisputesGet, new String[] { "/disputes/{0}", RequestType.GET } },
			{ MethodKey.DisputesSaveTag, new String[] { "/disputes/{0}", RequestType.PUT } },
			{ MethodKey.DisputesSaveContestFunds, new String[] { "/disputes/{0}/submit", RequestType.PUT } },
			{ MethodKey.DisputeSaveClose, new String[] { "/disputes/{0}/close", RequestType.PUT } },

			{ MethodKey.DisputesGetTransactions, new String[] { "/disputes/{0}/transactions", RequestType.GET } },

			{ MethodKey.DisputesGetAll, new String[] { "/disputes", RequestType.GET } },
			{ MethodKey.DisputesGetForWallet, new String[] { "/wallets/{0}/disputes", RequestType.GET } },
			{ MethodKey.DisputesGetForUser, new String[] { "/users/{0}/disputes", RequestType.GET } },

			{ MethodKey.DisputesDocumentCreate, new String[] { "/disputes/{0}/documents", RequestType.POST } },
			{ MethodKey.DisputesDocumentPageCreate, new String[] { "/disputes/{0}/documents/{1}/pages", RequestType.POST } },
			{ MethodKey.DisputesDocumentSubmit, new String[] { "/disputes/{0}/documents/{1}", RequestType.PUT } },
			{ MethodKey.DisputesDocumentGet, new String[] { "/dispute-documents/{0}", RequestType.GET } },
			{ MethodKey.DisputesDocumentGetForDispute, new String[] { "/disputes/{0}/documents", RequestType.GET } },
			{ MethodKey.DisputesDocumentGetForClient, new String[] { "/dispute-documents", RequestType.GET } },

			{ MethodKey.DisputesRepudiationGet, new String[] { "/repudiations/{0}", RequestType.GET } },

			{ MethodKey.DisputesRepudiationCreateSettlement, new String[] { "/repudiations/{0}/settlementtransfer", RequestType.POST } },
			{ MethodKey.SettlementsGet, new String[] { "/settlements/{0}/", RequestType.GET } },
			
			{ MethodKey.IdempotencyResponseGet, new String[] { "/responses/{0}/", RequestType.GET } },
			
			{ MethodKey.MandateCreate, new String[] { "/mandates/directdebit/web/", RequestType.POST } },
			{ MethodKey.MandateCancel, new String[] { "/mandates/{0}/", RequestType.PUT } },
			{ MethodKey.MandateGet, new String[] { "/mandates/{0}/", RequestType.GET } },
			{ MethodKey.MandatesGetAll, new String[] { "/mandates/", RequestType.GET } },
			{ MethodKey.MandatesGetForUser, new String[] { "/users/{0}/mandates/", RequestType.GET } },
			{ MethodKey.MandatesGetForBankAccount, new String[] { "/users/{0}/bankaccounts/{1}/mandates/", RequestType.GET } }
        };

        /// <summary>Creates new API instance.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiBase(MangoPayApi root)
        {
            _root = root;
        }

        /// <summary>Gets the URL of REST Mango Pay API.</summary>
        /// <param name="key">The method key to get URL of.</param>
        /// <returns>The URL string of given method.</returns>
        protected String GetRequestUrl(MethodKey key)
        {
            String result = "";
            try
            {
                result = this._methods[key][0];
            }
            catch
            {
                throw new Exception("Unknown method key: " + key);
            }
            return result;
        }

        /// <summary>Gets the HTTP request verb.</summary>
        /// <param name="key">The method key.</param>
        /// <returns>One of the HTTP verbs: GET, PUT or POST.</returns>
        protected String GetRequestType(MethodKey key)
        {
            return this._methods[key][1];
        }

        /// <summary>Creates the DTO instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
		/// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">DTO instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="secondEntityId">Second entity identifier.</param>
        /// <returns>The DTO instance returned from API.</returns>
        protected U CreateObject<U, T>(String idempotencyKey, MethodKey methodKey, T entity, String entityId, String secondEntityId)
            where U : EntityBase, new()
            where T : EntityPostBase
        {
            String urlMethod;

            if (String.IsNullOrEmpty(entityId))
                urlMethod = this.GetRequestUrl(methodKey);
            else if (String.IsNullOrEmpty(secondEntityId))
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId);
            else
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, secondEntityId);

            RestTool restTool = new RestTool(this._root, true);
			U result = restTool.Request<U, T>(idempotencyKey, urlMethod, this.GetRequestType(methodKey), null, null, entity);

            return result;
        }

        /// <summary>Creates the DTO instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
		/// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">DTO instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns>The DTO instance returned from API.</returns>
		protected U CreateObject<U, T>(String idempotencyKey, MethodKey methodKey, T entity, string entityId)
            where U : EntityBase, new()
            where T : EntityPostBase
        {
            return CreateObject<U, T>(idempotencyKey, methodKey, entity, entityId, "");
        }

        /// <summary>Creates the DTO instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
		/// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">DTO instance that is going to be sent.</param>
        /// <returns>The DTO instance returned from API.</returns>
		protected U CreateObject<U, T>(String idempotencyKey, MethodKey methodKey, T entity)
            where U : EntityBase, new()
            where T : EntityPostBase
        {
			return CreateObject<U, T>(idempotencyKey, methodKey, entity, "");
        }

        /// <summary>Gets the DTO instance from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="secondEntityId">Second entity identifier.</param>
        /// <returns>The DTO instance returned from API.</returns>
        protected T GetObject<T>(MethodKey methodKey, string entityId, string secondEntityId)
            where T : EntityBase, new()
        {
            string urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, secondEntityId);

            RestTool rest = new RestTool(this._root, true);
            T response = rest.Request<T, T>(urlMethod, this.GetRequestType(methodKey));

            return response;
        }

        /// <summary>Gets the Dto instance from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T GetObject<T>(MethodKey methodKey, string entityId)
            where T : EntityBase, new()
        {
            return GetObject<T>(methodKey, entityId, "");
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entityId">Entity identifier.</param>
		/// <param name="secondEntityId">Entity identifier.</param>
        /// <param name="sort">Sort.</param>
        /// <param name="additionalUrlParams">Collection of key-value pairs of request parameters.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination, string entityId, string secondEntityId, Sort sort, Dictionary<String, String> additionalUrlParams)
            where T : EntityBase, new()
        {
            string urlMethod = "";

			if (!String.IsNullOrEmpty(secondEntityId) && !String.IsNullOrEmpty(entityId))
				urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, secondEntityId);
            else if (!String.IsNullOrEmpty(entityId))
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId);
            else
                urlMethod = this.GetRequestUrl(methodKey);

            if (pagination == null)
            {
                pagination = new Pagination();
            }

            if (sort != null && sort.IsSet)
            {
                if (additionalUrlParams == null)
                    additionalUrlParams = new Dictionary<string, string>();

                additionalUrlParams.Add(Constants.SORT_URL_PARAMETER_NAME, sort.GetFields());
            }

            RestTool restTool = new RestTool(this._root, true);

            return restTool.RequestList<T>(urlMethod, this.GetRequestType(methodKey), additionalUrlParams, pagination);
        }

		protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination, string entityId, Sort sort, Dictionary<String, String> additionalUrlParams)
            where T : EntityBase, new()
		{
			return this.GetList<T>(methodKey, pagination, entityId, null, sort, additionalUrlParams);
		}

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination, string entityId, Sort sort = null)
            where T : EntityBase, new()
        {
            return GetList<T>(methodKey, pagination, entityId, null, sort, null);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination, Sort sort = null)
            where T : EntityBase, new()
        {
            return GetList<T>(methodKey, pagination, "", sort);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination)
            where T : EntityBase, new()
        {
            return GetList<T>(methodKey, pagination, sort: null);
        }

        /// <summary>Saves the Dto instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected U UpdateObject<U, T>(MethodKey methodKey, T entity)
            where U : EntityBase, new()
            where T : EntityPutBase
        {
            return UpdateObject<U, T>(methodKey, entity, "");
        }

        /// <summary>Saves the Dto instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns></returns>
        protected U UpdateObject<U, T>(MethodKey methodKey, T entity, string entityId)
            where U : EntityBase, new()
            where T : EntityPutBase
        {
            return UpdateObject<U, T>(methodKey, entity, entityId, "");
        }

        /// <summary>Saves the Dto instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="secondEntityId">Second entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected U UpdateObject<U, T>(MethodKey methodKey, T entity, string entityId, string secondEntityId)
            where U : EntityBase, new()
            where T : EntityPutBase
        {
            String urlMethod;

            if (String.IsNullOrEmpty(secondEntityId))
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId);
            else
            {
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, secondEntityId);
            }

            RestTool restTool = new RestTool(this._root, true);
            return restTool.Request<U, T>(null, urlMethod, this.GetRequestType(methodKey), null, null, entity);
        }
    }
}
