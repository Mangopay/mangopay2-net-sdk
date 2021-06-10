using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayInCITPostDTO : EntityPostBase
    {
        /// <summary>
        /// The recurring's ID
        /// </summary>
        public string RecurringPayinRegistrationId { get; set; }

        /// <summary>
        /// This object describes the Browser being user by an end user
        /// </summary>
        public BrowserInfo BrowserInfo { get; set; }

        /// <summary>
        /// IP Address of the end user(format IPV4 or IPV6)
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// This is the URL where users are automatically redirected after 3D secure validation (if activated)
        /// </summary>
        public string SecureModeReturnURL { get; set; }

        /// <summary>
        /// A custom description to appear on the user's bank statement. It can be up to 10 characters long, and can only include alphanumeric characters or spaces. See here for important info. Note that each bank handles this information differently, some show less or no information.
        /// </summary>
        public string StatementDescriptor { get; set; }
    }
}
