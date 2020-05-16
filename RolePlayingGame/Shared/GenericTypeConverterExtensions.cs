namespace RolePlayingGame.Shared
{
	using System;
	using System.Collections.Generic;
	using System.Text.Json;

	public static class GenericTypeConverterExtensions
	{
		public static bool TryConvert<T>(this object? obj, out T value, JsonSerializerOptions jsonSerializerOptions = default!)
		{
			if (obj is null)
			{
				value = default!;
				return false;
			}

			if (typeof(IConvertible).IsAssignableFrom(obj.GetType()))
			{
				value = (T)Convert.ChangeType(obj, typeof(T));
				return true;
			}

			if (obj is T t)
			{
				value = t;
				return true;
			}

			if (obj is JsonElement jsonElement)
			{
				if (jsonSerializerOptions == default)
					jsonSerializerOptions = new JsonSerializerOptions();

				value = JsonSerializer.Deserialize<T>(jsonElement.GetRawText(), jsonSerializerOptions)!;
				return true;
			}

			value = default!;
			return false;
		}

		public static bool TryGetValue<T, TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, out T value, JsonSerializerOptions jsonSerializerOptions = default!)
		{
			if (dictionary.TryGetValue(key, out var result))
			{
				value = result != null && result.TryConvert<T>(out var v, jsonSerializerOptions) ? v : default!;
				return true;
			}

			value = default!;
			return false;
		}
	}

}
