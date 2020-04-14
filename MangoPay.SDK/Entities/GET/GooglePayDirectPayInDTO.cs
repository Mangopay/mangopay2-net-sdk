using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Entities.GET
{
    public class GooglePayDirectPayInDTO : PayInDTO
    {
        /// <summary> A custom description to appear </summary>
        public String StatementDescriptor { get; set; }
    }
}
