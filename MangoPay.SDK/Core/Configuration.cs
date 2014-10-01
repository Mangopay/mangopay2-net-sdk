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
