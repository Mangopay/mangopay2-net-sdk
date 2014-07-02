using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>MangoPay SDK logger.</summary>
    public class Logs
    {
        /// <summary>Logs a message at DEBUG level.</summary>
        /// <param name="message">Message to log.</param>
        /// <param name="data">Additional data.</param>
        public static void Debug(String message, Object data)
        {
            Trace.WriteLine(message + ": " + data);
            Trace.WriteLine("-------------------------------");
        }

        public static void Log(string message, params object[] parameters)
        {
            Trace.WriteLine(String.Format(message, parameters));
            Trace.WriteLine("-------------------------------");
        }
    }
}
