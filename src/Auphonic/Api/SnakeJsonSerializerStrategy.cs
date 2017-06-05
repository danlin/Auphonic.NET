using AuphonicNet.Classes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuphonicNet.Api
{
	/// <summary>
	/// Provides a <see cref="SnakeJsonSerializerStrategy"/> class.
	/// </summary>
	internal class SnakeJsonSerializerStrategy : PocoJsonSerializerStrategy
	{
		#region Public Methods
		public override object DeserializeObject(object value, Type type)
		{
			return base.DeserializeObject(value, type);
		}

		public override bool TrySerializeNonPrimitiveObject(object input, out object output)
		{
			bool result = base.TrySerializeNonPrimitiveObject(input, out output);
			CheckObject(input, output);

			return result;
		}
		#endregion

		#region Protected Methods
		protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
		{
			//PascalCase to snake_case
			string property = string.Concat(clrPropertyName.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();

			return property;
		}
		#endregion

		#region Private Methods
		private void CheckObject(object input, object output)
		{
			if (output is IDictionary<string, object>)
			{
				Type type = input.GetType();
				string[] keys = null;

				if (type == typeof(OutputFile))
				{
					keys = new[] { "size" };
				}

				if (type == typeof(Preset))
				{
					keys = new[] { "output_basename", "image" };
				}

				if (type == typeof(Production))
				{
					keys = new[] { "output_basename", "image", "chapters", "input_file" };
				}

				if (keys != null)
				{
					RemoveEmptyKey((IDictionary<string, object>)output, keys);
				}
			}
		}

		private void RemoveEmptyKey(IDictionary<string, object> output, params string[] keys)
		{
			foreach (string key in keys)
			{
				if (output.ContainsKey(key) && string.IsNullOrWhiteSpace((string)output[key]))
				{
					output.Remove(key);
				}
			}
		}
		#endregion
	}
}