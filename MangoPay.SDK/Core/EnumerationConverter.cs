﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MangoPay.SDK.Core
{
	/// <summary>Handles incoming NULL values for non-nullable enum fields and sets default value instead throwing an exception.</summary>
	public class EnumerationConverter : StringEnumConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var isNullable = (Nullable.GetUnderlyingType(objectType) != null);

			if (reader.TokenType != JsonToken.Null || (reader.TokenType == JsonToken.Null && isNullable))
				return base.ReadJson(reader, objectType, existingValue, serializer);
			

			var enumType = (Nullable.GetUnderlyingType(objectType) ?? objectType);
			if (!enumType.IsEnum)
				throw new JsonSerializationException($"Type {enumType.FullName} is not an enum type.");

			var result = Enum.GetValues(enumType).GetValue(0);
			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			base.WriteJson(writer, value, serializer);
		}
	}
}
