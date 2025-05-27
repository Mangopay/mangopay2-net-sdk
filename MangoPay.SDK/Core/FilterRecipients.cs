using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for recipients list.</summary>
    public class FilterRecipients
    {
        /// <summary>Recipient scope.</summary>
        public string RecipientScope { get; set; }

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(RecipientScope)) result.Add(Constants.RECIPIENT_SCOPE, RecipientScope);
            return result;
        }
    }
}