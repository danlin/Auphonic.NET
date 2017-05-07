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
	public class SnakeJsonSerializerStrategy : PocoJsonSerializerStrategy
	{
		#region Public Methods
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
				IDictionary<string, object> dict = (IDictionary<string, object>)output;
				Type type = input.GetType();

				if (type == typeof(Preset))
				{
					CheckPreset((Preset)input, dict);
				}

				if (type == typeof(Production))
				{
					CheckProduction((Production)input, dict);
				}
			}
		}

		private void CheckPreset(Preset preset, IDictionary<string, object> output)
		{
			if (string.IsNullOrWhiteSpace((string)output["output_basename"]))
			{
				output.Remove("output_basename");
			}

			if (string.IsNullOrWhiteSpace((string)output["image"]))
			{
				output.Remove("image");
			}
		}

		private void CheckProduction(Production production, IDictionary<string, object> output)
		{
			if (string.IsNullOrWhiteSpace((string)output["output_basename"]))
			{
				output.Remove("output_basename");
			}

			if (string.IsNullOrWhiteSpace((string)output["image"]))
			{
				output.Remove("image");
			}

			if (string.IsNullOrWhiteSpace((string)output["chapters"]))
			{
				output.Remove("chapters");
			}

			if (string.IsNullOrWhiteSpace((string)output["input_file"]))
			{
				output.Remove("input_file");
			}
		}
		#endregion
	}
}