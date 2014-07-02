using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangoPay.Core
{
    /// <summary>Base class for all Api classes.</summary>
    public abstract class ApiBase
    {
        /// <summary>Root/parent instance that holds the OAuthToken and Configuration instance.</summary>
        protected MangoPayApi _root;

        /// <summary>Array with REST URL and request type.</summary>
        private Dictionary<String, String[]> _methods = new Dictionary<String, String[]> {
        { "authentication_base", new String[] { "/api/clients/", RequestType.POST } },
        { "authentication_oauth", new String[] { "/oauth/token", RequestType.POST } },
        
        { "events_all", new String[] { "/events", RequestType.GET } },
        { "events_gethookcallbacks", new String[] { "/events/{0}/hook-callbacks", RequestType.GET } },
        
        { "hooks_create", new String[] { "/hooks", RequestType.POST } },
        { "hooks_all", new String[] { "/hooks", RequestType.GET } },
        { "hooks_get", new String[] { "/hooks/{0}", RequestType.GET } },
        { "hooks_save", new String[] { "/hooks/{0}", RequestType.PUT } },
        
        { "info_get", new String[] { "/info", RequestType.GET } },
        { "info_getfeewallets", new String[] { "/info/fee-wallets", RequestType.GET } },
        { "info_getmeansofpayment", new String[] { "/info/means-of-payment", RequestType.GET } },
     
        { "cardregistration_create", new String[] { "/cardregistrations", RequestType.POST } },
        { "cardregistration_get", new String[] { "/cardregistrations/{0}", RequestType.GET } },
        { "cardregistration_save", new String[] { "/cardregistrations/{0}", RequestType.PUT } },
        
        { "preauthorization_create", new String[] { "/preauthorizations/card/direct", RequestType.POST } },
        { "preauthorization_get", new String[] { "/preauthorizations/{0}", RequestType.GET } },
        { "preauthorization_save", new String[] { "/preauthorizations/{0}", RequestType.PUT } },
        
        { "card_get", new String[] { "/cards/{0}", RequestType.GET } },
        { "card_save", new String[] { "/cards/{0}", RequestType.PUT } },
        
        // pay ins URLs
        { "payins_card-web_create", new String[] { "/payins/card/web/", RequestType.POST } },
        { "payins_card-direct_create", new String[] { "/payins/card/direct/", RequestType.POST } },
        { "payins_card-preauthorized_create", new String[] { "/payins/card/preauthorized/", RequestType.POST } },
        { "payins_card-recurrentexecution_create", new String[] { "/payins/card/recurrent-pay-in-execution/", RequestType.POST } },
        
        { "payins_registeredcard-web_create", new String[] { "/payins/registered-card/web/", RequestType.POST } },
        { "payins_registeredcard-direct_create", new String[] { "/payins/registered-card/direct/", RequestType.POST } },
        { "payins_registeredcard-preauthorized_create", new String[] { "/payins/registered-card/preauthorized/", RequestType.POST } },
        { "payins_registeredcard-recurrentexecution_create", new String[] { "/payins/registered-card/recurrent-pay-in-execution/", RequestType.POST } },
        
        { "payins_bankwirepayin-web_create", new String[] { "/payins/bankwire/web/", RequestType.POST } },
        { "payins_bankwirepayin-direct_create", new String[] { "/payins/bankwire/direct/", RequestType.POST } },
        { "payins_bankwirepayin-preauthorized_create", new String[] { "/payins/bankwire/preauthorized/", RequestType.POST } },
        { "payins_bankwirepayin-recurrentexecution_create", new String[] { "/payins/bankwire/recurrent-pay-in-execution/", RequestType.POST } },
        
        { "payins_directcredit-web_create", new String[] { "/payins/direct-credit/web/", RequestType.POST } },
        { "payins_directcredit-direct_create", new String[] { "/payins/direct-credit/direct/", RequestType.POST } },
        { "payins_directcredit-preauthorized_create", new String[] { "/payins/direct-credit/preauthorized/", RequestType.POST } },
        { "payins_directcredit-recurrentexecution_create", new String[] { "/payins/direct-credit/recurrent-pay-in-execution/", RequestType.POST } },
        { "payins_get", new String[] { "/payins/{0}", RequestType.GET } },
        { "payins_createrefunds", new String[] { "/payins/{0}/refunds", RequestType.POST } },
        
        { "payins_preauthorized-direct_create", new String[] { "/payins/preauthorized/direct/", RequestType.POST } },
        { "payins_bankwire-direct_create", new String[] { "/payins/bankwire/direct/", RequestType.POST } },
        
        { "payouts_bankwire_create", new String[] { "/payouts/bankwire/", RequestType.POST } },
        { "payouts_merchantexpense_create", new String[] { "/payouts/merchant-expense/", RequestType.POST } },
        { "payouts_amazongiftcard_create", new String[] { "/payouts/amazon-giftcard/", RequestType.POST } },
        { "payouts_get", new String[] { "/payouts/{0}", RequestType.GET } },
        { "payouts_createrefunds", new String[] { "/payouts/{0}/refunds", RequestType.POST } },
        { "payouts_getrefunds", new String[] { "/payouts/{0}/refunds", RequestType.GET } },
        
        { "reccurringpayinorders_create", new String[] { "/reccurring-pay-in-orders", RequestType.POST } },
        { "reccurringpayinorders_get", new String[] { "/reccurring-pay-in-orders/{0}", RequestType.GET } },
        { "reccurringpayinorders_gettransactions", new String[] { "/reccurring-pay-in-orders/{0}/transactions", RequestType.GET } },
        
        { "refunds_get", new String[] { "/refunds/{0}", RequestType.GET } },
        
        { "repudiations_get", new String[] { "/repudiations/{0}", RequestType.GET } },
        
        { "transfers_create", new String[] { "/transfers/", RequestType.POST } },
        { "transfers_get", new String[] { "/transfers/{0}", RequestType.GET } },
        { "transfers_getrefunds", new String[] { "/transfers/{0}/refunds", RequestType.GET } },
        { "transfers_createrefunds", new String[] { "/transfers/{0}/refunds", RequestType.POST } },
        
        { "users_all", new String[] { "/users", RequestType.GET } },
        { "users_allkyc", new String[] { "/users/{0}/KYC", RequestType.GET } },
        { "users_allkycrequests", new String[] { "/users/{0}/KYC/requests", RequestType.GET } },
        { "users_allwallets", new String[] { "/users/{0}/wallets", RequestType.GET } },
        { "users_allbankaccount", new String[] { "/users/{0}/bankaccounts", RequestType.GET } },
        { "users_allpaymentcards", new String[] { "/users/{0}/payment-cards", RequestType.GET } },
        { "users_allcards", new String[] { "/users/{0}/cards", RequestType.GET } },
        { "users_alltransactions", new String[] { "/users/{0}/transactions", RequestType.GET } },
        { "users_createnaturals", new String[] { "/users/natural", RequestType.POST } },
        { "users_createlegals", new String[] { "/users/legal", RequestType.POST } },
        { "users_createkycrequests", new String[] { "/users/{0}/KYC/requests", RequestType.POST } },
        { "users_createkycdocument", new String[] { "/users/{0}/KYC/documents", RequestType.POST } },
        { "users_createkycpage", new String[] { "/users/{0}/KYC/documents/{1}/pages", RequestType.POST } },
        { "users_createbankaccounts_iban", new String[] { "/users/{0}/bankaccounts/iban", RequestType.POST } },
        { "users_createbankaccounts_gb", new String[] { "/users/{0}/bankaccounts/gb", RequestType.POST } },
        { "users_createbankaccounts_us", new String[] { "/users/{0}/bankaccounts/us", RequestType.POST } },
        { "users_createbankaccounts_ca", new String[] { "/users/{0}/bankaccounts/ca", RequestType.POST } },
        { "users_createbankaccounts_other", new String[] { "/users/{0}/bankaccounts/other", RequestType.POST } },
        { "users_get", new String[] { "/users/{0}", RequestType.GET } },
        { "users_getnaturals", new String[] { "/users/natural/{0}", RequestType.GET } },
        { "users_getlegals", new String[] { "/users/legal/{0}", RequestType.GET } },
        { "users_getkycdocument", new String[] { "/users/{0}/KYC/documents/{1}", RequestType.GET } },
        { "users_getkycrequests", new String[] { "/users/{0}/KYC/requests/{1}", RequestType.GET } },
        { "users_getproofofidentity", new String[] { "/users/{0}/ProofOfIdentity", RequestType.GET } },
        { "users_getproofofaddress", new String[] { "/users/{0}/ProofOfAddress", RequestType.GET } },
        { "users_getproofofregistration", new String[] { "/users/{0}/ProofOfRegistration", RequestType.GET } },
        { "users_getshareholderdeclaration", new String[] { "/users/{0}/ShareholderDeclaration", RequestType.GET } },
        { "users_getbankaccount", new String[] { "/users/{0}/bankaccounts/{1}", RequestType.GET } },
        { "users_getpaymentcards", new String[] { "/users/{0}/payment-cards/{1}", RequestType.GET } },
        { "users_savenaturals", new String[] { "/users/natural/{0}", RequestType.PUT } },
        { "users_savelegals", new String[] { "/users/legal/{0}", RequestType.PUT } },
        { "users_savekycdocument", new String[] { "/users/{0}/KYC/documents/{1}", RequestType.PUT } },
        
        { "wallets_create", new String[] { "/wallets", RequestType.POST } },
        { "wallets_allrecurringpayinorders", new String[] { "/wallets/{0}/recurring-pay-in-orders", RequestType.GET } },
        { "wallets_alltransactions", new String[] { "/wallets/{0}/transactions", RequestType.GET } },
        { "wallets_alltransactionspage", new String[] { "/wallets/{0}/transactions/pages/{1}", RequestType.GET } },
        { "wallets_get", new String[] { "/wallets/{0}", RequestType.GET } },
        { "wallets_save", new String[] { "/wallets/{0}", RequestType.PUT } },
        
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
        protected String GetRequestUrl(String key)
        {
            String result = "";
            try
            {
                result = this._methods[key][0];
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown method key: " + key);
            }
            return result;
        }

        /// <summary>Gets the HTTP request verb.</summary>
        /// <param name="key">The method key.</param>
        /// <returns>One of the HTTP verbs: GET, PUT or POST.</returns>
        protected String GetRequestType(String key)
        {
            return this._methods[key][1];
        }

        /// <summary>Creates the Dto instance.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="secondEntityId">Second entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T CreateObject<T>(String methodKey, T entity, String entityId, String secondEntityId)
            where T : Dto, new()
        {

            String urlMethod;

            if (entityId.Length == 0)
                urlMethod = this.GetRequestUrl(methodKey);
            else if (secondEntityId.Length == 0)
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId);
            else
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, secondEntityId);

            RestTool rest = new RestTool(this._root, true);
            T result = rest.Request<T>(urlMethod, this.GetRequestType(methodKey), null, null, entity);

            return result;

        }

        /// <summary>Creates the Dto instance.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T CreateObject<T>(string methodKey, T entity, string entityId)
            where T : Dto, new()
        {
            return CreateObject(methodKey, entity, entityId, "");
        }

        /// <summary>Creates the Dto instance.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T CreateObject<T>(string methodKey, T entity)
            where T : Dto, new()
        {
            return CreateObject(methodKey, entity, "");
        }

        /// <summary>Gets the Dto instance from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="secondEntityId">Second entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T GetObject<T>(string methodKey, string entityId, string secondEntityId)
            where T : Dto, new()
        {
            string urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, secondEntityId);

            RestTool rest = new RestTool(this._root, true);
            T response = rest.Request<T>(urlMethod, this.GetRequestType(methodKey));

            return response;
        }

        /// <summary>Gets the Dto instance from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T GetObject<T>(string methodKey, string entityId)
            where T : Dto, new()
        {
            return GetObject<T>(methodKey, entityId, "");
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="additionalUrlParams">Collection of key-value pairs of request parameters.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected List<T> GetList<T>(string methodKey, Pagination pagination, string entityId, Dictionary<String, String> additionalUrlParams)
            where T : Dto, new()
        {
            string urlMethod = "";

            if (entityId.Length > 0)
                urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId);
            else
                urlMethod = this.GetRequestUrl(methodKey);

            if (pagination == null)
            {
                pagination = new Pagination();
            }

            RestTool rest = new RestTool(this._root, true);

            return rest.RequestList<T>(urlMethod, this.GetRequestType(methodKey), additionalUrlParams, pagination);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected List<T> GetList<T>(string methodKey, Pagination pagination, string entityId)
            where T : Dto, new()
        {
            return GetList<T>(methodKey, pagination, entityId, null);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected List<T> GetList<T>(string methodKey, Pagination pagination)
            where T : Dto, new()
        {
            return GetList<T>(methodKey, pagination, "");
        }

        /// <summary>Saves the Dto instance.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T UpdateObject<T>(string methodKey, T entity)
            where T : Dto, new()
        {
            return UpdateObject(methodKey, entity, "");
        }

        /// <summary>Saves the Dto instance.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <param name="entityId">Entity identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected T UpdateObject<T>(string methodKey, T entity, string entityId)
            where T : Dto, new()
        {
            if (entity is EntityBase)
            {

                String urlMethod;

                if (entityId.Length == 0)
                    urlMethod = String.Format(this.GetRequestUrl(methodKey), (entity as EntityBase).Id);
                else
                {
                    urlMethod = String.Format(this.GetRequestUrl(methodKey), entityId, (entity as EntityBase).Id);
                }


                RestTool rest = new RestTool(this._root, true);
                return rest.Request(urlMethod, this.GetRequestType(methodKey), null, null, entity);
            }
            else
            {
                return null;
            }
        }
    }
}
