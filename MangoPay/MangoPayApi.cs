using MangoPay.Core;

namespace MangoPay
{
    /// <summary>
    /// MangoPay API main entry point. 
    /// Provides managers to connect, send and read data from MangoPay API as well as it holds configuration/authorization data.
    /// </summary>
    public class MangoPayApi
    {
        /// <summary>Instantiates new MangoPayApi object.</summary>
        public MangoPayApi()
        {
            // default config setup
            Config = new Configuration();
            OAuthTokenManager = new AuthorizationTokenManager(this);

            // API managers initialization
            AuthenticationManager = new ApiOAuth(this);
            Clients = new ApiClients(this);
            Users = new ApiUsers(this);
            Wallets = new ApiWallets(this);
            PayIns = new ApiPayIns(this);
            PayOuts = new ApiPayOuts(this);
            Refunds = new ApiRefunds(this);
            Transfers = new ApiTransfers(this);
            CardRegistrations = new ApiCardRegistrations(this);
            Cards = new ApiCards(this);
            Events = new ApiEvents(this);
            CardPreAuthorizations = new ApiCardPreAuthorizations(this);
            Hooks = new ApiHooks(this);
        }

        /// <summary>Provides authorization token methods.</summary>
        public AuthorizationTokenManager OAuthTokenManager;

        /// <summary>Configuration instance with default settings (to be reset if required).</summary>
        public Configuration Config;

        #region API managers

        /// <summary>Provides OAuth methods.</summary>
        public ApiOAuth AuthenticationManager;

        /// <summary>Provides Clients methods.</summary>
        public ApiClients Clients;

        /// <summary>Provides Users methods.</summary>
        public ApiUsers Users;

        /// <summary>Provides Wallets methods.</summary>
        public ApiWallets Wallets;

        /// <summary>Provides PayIns methods.</summary>
        public ApiPayIns PayIns;

        /// <summary>Provides PayOuts methods.</summary>
        public ApiPayOuts PayOuts;

        /// <summary>Provides Transfer methods.</summary>
        public ApiTransfers Transfers;

        /// <summary>Provides CardRegistrations methods.</summary>
        public ApiCardRegistrations CardRegistrations;

        /// <summary>Provides CardPreAuthorizations methods.</summary>
        public ApiCardPreAuthorizations CardPreAuthorizations;

        /// <summary>Provides Cards methods.</summary>
        public ApiCards Cards;

        /// <summary>Provides Refunds methods.</summary>
        public ApiRefunds Refunds;

        /// <summary>Provides Events methods.</summary>
        public ApiEvents Events;

        /// <summary>Provides Hooks methods.</summary>
        public ApiHooks Hooks;

        #endregion
    }
}
