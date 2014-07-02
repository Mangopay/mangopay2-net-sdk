using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class represents GB type of bank account.</summary>
    public class BankAccountDetailsGB : Dto, IBankAccountDetails
    {
        /// <summary>Account number.</summary>
        public String AccountNumber;

        /// <summary>Sort code.</summary>
        public String SortCode;
    }
}
