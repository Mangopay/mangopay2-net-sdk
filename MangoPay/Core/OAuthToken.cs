using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MangoPay.Core
{
    /// <summary>OAuthToken entity.</summary>
    [Serializable]
    public class OAuthToken : Dto
    {
        /// <summary>Creation date (UNIX timestamp).</summary>
        public long create_time;

        /// <summary>Value of token.</summary>
        public String access_token;

        /// <summary>Token type.</summary>
        public String token_type;

        /// <summary>Denotes how long the token is valid, in seconds.</summary>
        public int expires_in;

        /// <summary>Instantiates new OAuthToken object.</summary>
        public OAuthToken()
        {
            create_time = (long)TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds - 5000;
        }

        /// <summary>Checks if current token is expired.</summary>
        /// <returns>Returns true if token has expired, or false if token is still valid.</returns>
        public bool IsExpired()
        {
            return ((long)TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMilliseconds >= (create_time + (expires_in * 1000)));
        }

        // for debug purposes
        public override String ToString()
        {
            return "access_token = " + this.access_token + ", token_type: " + this.token_type + ", expires_in: " + this.expires_in;
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<string> GetReadOnlyProperties()
        {
            return new List<string> { "create_time" };
        }

        /// <summary>Serializes this instance to JSON-formatted string.</summary>
        /// <returns>Returns JSON string.</returns>
        public string Serialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
            StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, this);
            return textWriter.ToString();
        }

        /// <summary>Creates new instance of OAuthToken class from serialized data.</summary>
        /// <param name="serializedData">Serialized OAuthToken object.</param>
        /// <returns>Returns new instance of OAuthToken class.</returns>
        public static OAuthToken Deserialize(string serializedData)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OAuthToken));

            return (OAuthToken)xmlSerializer.Deserialize(new StringReader(serializedData));
        }
    }
}
