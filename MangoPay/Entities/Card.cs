using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Card entity.</summary>
    public class Card : EntityBase
    {
        /// <summary>Expiration date.</summary>
        public string ExpirationDate;

        /// <summary>Alias.</summary>
        public string Alias;

        /// <summary>Card type.</summary>
        public string CardType;

        /// <summary>The card provider, it could be CB, VISA, MASTERCARD, etc.</summary>
        public string CardProvider;

        /// <summary>Product codes.</summary>
        public string Product;

        /// <summary>Bank code.</summary>
        public string BankCode;

        /// <summary>Active.</summary>
        public bool Active;

        /// <summary>The currency accepted in the wallet { EUR, USD, GBP, PLN, CHF }.</summary>
        public string Currency;

        /// <summary>Validity { UNKNOWN, VALID, INVALID }.</summary>
        public string Validity;
    }
}
