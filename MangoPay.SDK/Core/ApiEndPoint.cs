using System;

namespace MangoPay.SDK.Core
{
	/// <summary>Encapsulates the details of an API end point</summary>
	public class ApiEndPoint : ICloneable
	{
		private string _parameter1 { get; set; }
		private string _parameter2 { get; set; }

		/// <summary>End point URL fragment with optional placeholders for one or two parameters</summary>
		public string UrlPattern { private get; set; }

		/// <summary>End point HTTP verb</summary>
		public string RequestType { get; set; }

		/// <summary>Specifies whether this end point URL is preceded by ClientId or not</summary>
		public bool IncludeClientId { get; set; }

		/// <summary>Adds an optional parameter to embed in the end point URL</summary>
		public void SetParameters(string parameter)
		{
			_parameter1 = parameter;
		}

		/// <summary>Adds an optional parameters to embed in the end point URL</summary>
		public void SetParameters(string parameter1, string parameter2)
		{
			_parameter1 = parameter1;
			_parameter2 = parameter2;
		}
		
		/// <summary>Returns end point URL fragment. If parameters have been set, they are embedded in the URL</summary>
		public string GetUrl()
		{
			if (String.IsNullOrEmpty(_parameter1))
			{
				return UrlPattern;
			}
			else if (String.IsNullOrEmpty(_parameter2))
			{
				return String.Format(UrlPattern, _parameter1);
			}
			else
			{
				return String.Format(UrlPattern, _parameter1, _parameter2);
			}
		}

		/// <summary>
		/// Contructs an instance of <see cref="ApiEndPoint"/>
		/// </summary>
		/// <param name="urlPattern">End point URL fragment with optional placeholders for one or two parameters</param>
		/// <param name="requestType">End point HTTP verb</param>
		/// <param name="includeClientId">Specifies whether this end point URL is preceded by ClientId or not</param>
		public ApiEndPoint(string urlPattern, string requestType, bool includeClientId = true)
		{
			UrlPattern = urlPattern;
			RequestType = requestType;
			IncludeClientId = includeClientId;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
