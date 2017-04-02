using RestSharp;
using System.Linq;

namespace AuphonicNet.Api
{
	/// <summary>
	/// Provides a <see cref="SnakeJsonSerializerStrategy"/> class.
	/// </summary>
	public class SnakeJsonSerializerStrategy : PocoJsonSerializerStrategy
	{
		protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
		{
			//PascalCase to snake_case
			string property = string.Concat(clrPropertyName.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();

			return property;
		}
	}
}