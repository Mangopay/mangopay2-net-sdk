using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    public class FilterWallets
    {
            /// <summary>Possible values: USER_PRESENT, USER_NOT_PRESENT</summary>
            public string ScaContext;
        
        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();
        
            if (!string.IsNullOrEmpty(ScaContext)) result.Add(Constants.SCA_CONTEXT, ScaContext);

            return result;
        }
    }
}
