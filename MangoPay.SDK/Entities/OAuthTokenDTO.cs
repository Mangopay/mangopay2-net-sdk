using System;
using System.IO;
using System.Xml.Serialization;

namespace MangoPay.SDK.Entities
{
    /// <summary>OAuthToken entity.</summary>
    [Serializable]
    public class OAuthTokenDTO
    {
        /// <summary>Creation date (UNIX timestamp).</summary>
        public long create_time { get; set; }

        /// <summary>Value of token.</summary>
        public string access_token { get; set; }

        /// <summary>Token type.</summary>
        public string token_type { get; set; }

        /// <summary>Denotes how long the token is valid, in seconds.</summary>
        public int expires_in { get; set; }

        /// <summary>Instantiates new OAuthToken object.</summary>
        public OAuthTokenDTO()
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
        public override string ToString()
        {
            return "access_token = " + this.access_token + ", token_type: " + this.token_type + ", expires_in: " + this.expires_in;
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
        public static OAuthTokenDTO Deserialize(string serializedData)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OAuthTokenDTO));

            return (OAuthTokenDTO)xmlSerializer.Deserialize(new StringReader(serializedData));
        }
    }
}
