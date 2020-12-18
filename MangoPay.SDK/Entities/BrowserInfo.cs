using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities
{
    public class BrowserInfo
    {
        /// <summary>
        /// Browser Header
        /// </summary>
        public string AcceptHeader { get; set; }

        /// <summary>
        /// If Java is enabled in the browser
        /// </summary>
        public bool JavaEnabled { get; set; }

        /// <summary>
        /// If Javascript is enabled in the browser
        /// </summary>
        public bool JavascriptEnabled { get; set; }

        /// <summary>
        /// The used language by the browser
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The color depth
        /// </summary>
        public string ColorDepth { get; set; }

        /// <summary>
        /// The screen height
        /// </summary>
        public string ScreenHeight { get; set; }

        /// <summary>
        /// The screen width
        /// </summary>
        public string ScreenWidth { get; set; }

        /// <summary>
        /// The timezone offset
        /// </summary>
        public string TimeZoneOffset { get; set; }

        /// <summary>
        /// The user agent
        /// </summary>
        public string UserAgent { get; set; }
    }
}
