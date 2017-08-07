using Common.Logging;
using Common.Logging.Simple;

namespace MangoPay.SDK.Core
{
    /// <summary>Configuration settings.</summary>
    public class Configuration
    {
        private ILoggerFactoryAdapter _loggerFactoryAdapter;

        /// <summary>Client identifier.</summary>
        public string ClientId = "";

        /// <summary>Client password.</summary>
        public string ClientPassword = "";

        /// <summary>Base URL to MangoPay API.</summary>
        public string BaseUrl = "https://api.sandbox.mangopay.com";

		public int Timeout = 0;

		/// <summary>API version (added in dashboard's SDK only in order to handle both old and new address fields).</summary>
		public string ApiVersion = "v2.01";

        /// <summary>Logger adapter implementation (default: NoOpLoggerFactoryAdapter).</summary>
        public ILoggerFactoryAdapter LoggerFactoryAdapter
        {
            get
            {
                if (_loggerFactoryAdapter == null)
                    _loggerFactoryAdapter = new NoOpLoggerFactoryAdapter();

                return _loggerFactoryAdapter;
            }
            set
            {
                _loggerFactoryAdapter = value;
            }
        }
    }
}
