using System;
using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Core
{
	/// <summary>Encapsulates the details of an API end point</summary>
	public class ApiEndPoint : ICloneable
	{
		private string[] _parameters { get; set; }
		
		/// <summary>End point URL fragment with optional placeholders for one or two parameters</summary>
		public string UrlPattern { private get; set; }

		/// <summary>End point HTTP verb</summary>
		public string RequestType { get; set; }

		/// <summary>Specifies whether this end point URL is preceded by ClientId or not</summary>
		public bool IncludeClientId { get; set; }
		
		/// <summary>Api Version</summary>
		public ApiVersion ApiVersion { get; set; }

		/// <summary>Adds an optional parameter to embed in the end point URL</summary>
		public void SetParameters(string[] parameter)
		{
			_parameters = parameter;
		}
		
		/// <summary>Returns end point URL fragment. If parameters have been set, they are embedded in the URL</summary>
		public string GetUrl()
		{
			if (_parameters==null || _parameters.Length == 0)
			{
				return UrlPattern;
			}
			return string.Format(UrlPattern, _parameters);
		}

		/// <summary>
		/// Contructs an instance of <see cref="ApiEndPoint"/>
		/// </summary>
		/// <param name="urlPattern">End point URL fragment with optional placeholders for one or two parameters</param>
		/// <param name="requestType">End point HTTP verb</param>
		/// <param name="includeClientId">Specifies whether this end point URL is preceded by ClientId or not</param>
		/// <param name="apiVersion">Api Version. Default V2.01</param>
		public ApiEndPoint(string urlPattern, string requestType, bool includeClientId = true, 
			ApiVersion apiVersion = ApiVersion.V2_01)
		{
			UrlPattern = urlPattern;
			RequestType = requestType;
			IncludeClientId = includeClientId;
			ApiVersion = apiVersion;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
