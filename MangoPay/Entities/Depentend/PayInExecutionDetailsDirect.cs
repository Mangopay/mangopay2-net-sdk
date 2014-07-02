using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class representing the Direct type for execution option in PayIn entity.</summary>
    public class PayInExecutionDetailsDirect : Dto, IPayInExecutionDetails
    {
        /// <summary>Card identifier.</summary>
        public String CardId;

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        public String SecureMode;

        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL;
    }
}
