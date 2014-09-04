
namespace MangoPay.Core
{
    /// <summary>Configuration settings.</summary>
    public class Configuration
    {
        /// <summary>Client identifier.</summary>
        public string ClientId = "";

        /// <summary>Client password.</summary>
        public string ClientPassword = "";

        /// <summary>Base URL to MangoPay API.</summary>
        public string BaseUrl = "https://api.sandbox.mangopay.com";

        /// <summary>Switch debug mode: log all request and response data.</summary>
        public bool DebugMode = false;
    }
}
