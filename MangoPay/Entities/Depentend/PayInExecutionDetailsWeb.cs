using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class representing Web type for execution option in PayIn entity.</summary>
    public class PayInExecutionDetailsWeb : Dto, IPayInExecutionDetails
    {
        /// <summary>URL format expected.</summary>
        public String TemplateURL;

        /// <summary>Culture.</summary>
        public String Culture;

        /// <summary>Mode3DSType { DEFAULT, FORCE }.</summary>
        public String SecureMode;

        /// <summary>Redirect URL.</summary>
        public String RedirectURL;

        /// <summary>Return URL.</summary>
        public String ReturnURL;

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("RedirectURL");

            return result;
        }
    }
}
