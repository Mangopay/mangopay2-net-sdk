using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.Enumerations
{
    public enum AVSResult
    {
        FULL_MATCH, ADDRESS_MATCH_ONLY, POSTAL_CODE_MATCH_ONLY, NO_MATCH, NO_CHECK
    }
}
