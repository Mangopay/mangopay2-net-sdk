using MangoPay.Core;
using MangoPay.Core.Interfaces;
using MangoPay.Entities.Dependend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Bank Account entity.</summary>
    public class BankAccount : EntityBase
    {
        /// <summary>User identifier.</summary>
        public string UserId;

        /// <summary>Type of bank account.</summary>
        public string Type;

        /// <summary>Owner name.</summary>
        public string OwnerName;

        /// <summary>Owner address.</summary>
        public string OwnerAddress;

        /// <summary>One of BankAccountDetails implementations, depending on Type.</summary>
        public IBankAccountDetails Details;

        /// <summary>Gets the structure that maps which property depends on other property.</summary>
        /// <returns></returns>
        public override Dictionary<string, Dictionary<string, Dictionary<string, Type>>> GetDependentObjects()
        {
            return new Dictionary<string, Dictionary<string, Dictionary<string, Type>>>
            {
                { "Type", new Dictionary<string, Dictionary<string, Type>> 
                    {
                        { "IBAN", new Dictionary<string, Type> 
                            {
                                { "Details", typeof(BankAccountDetailsIBAN) }
                            }
                        },
                        { "GB", new Dictionary<string, Type> 
                            {
                                { "Details", typeof(BankAccountDetailsGB) }
                            }
                        },
                        { "US", new Dictionary<string, Type> 
                            {
                                { "Details", typeof(BankAccountDetailsUS) }
                            }
                        },
                        { "CA", new Dictionary<string, Type> 
                            {
                                { "Details", typeof(BankAccountDetailsCA) }
                            }
                        },
                        { "OTHER", new Dictionary<string, Type> 
                            {
                                { "Details", typeof(BankAccountDetailsOTHER) }
                            }
                        },
                        // ...and more in future...
                    }
                }
            };
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<string> GetReadOnlyProperties()
        {
            List<string> result = base.GetReadOnlyProperties();

            result.Add("UserId");
            result.Add("Type");

            return result;
        }
    }
}
