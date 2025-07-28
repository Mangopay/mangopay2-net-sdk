using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    public class FilterSupportedBanks
    {
        public string CountryCodes { get; set; }

        public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(CountryCodes)) result.Add("CountryCodes", CountryCodes);

            return result;
        }
    }
}