using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Parameter"/> class.
	/// </summary>
	public class Parameter
	{
		#region Public Properties
		public string DisplayName { get; set; }

		public string DefaultValue { get; set; }

		public string Type { get; set; }

		public List<Option> Options { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Parameter"/> class.
		/// </summary>
		public Parameter()
		{
		}
		#endregion

		#region Public Override Methods
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}