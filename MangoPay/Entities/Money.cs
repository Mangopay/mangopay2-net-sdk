using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Class represents money value with currency.</summary>
    public class Money : Dto
    {
        /// <summary>Currency code in ISO 4217 standard.</summary>
        public String Currency;

        /// <summary>Amount of money.</summary>
        public Double Amount;
    }
}
