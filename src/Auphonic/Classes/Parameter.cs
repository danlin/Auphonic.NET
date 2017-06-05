using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a parameter for a service.
	/// </summary>
	public class Parameter
	{
		#region Public Properties
		/// <summary>
		/// Gets the default value of the parameter.
		/// </summary>
		public string DefaultValue { get; internal set; }

		/// <summary>
		/// Gets the name of the parameter.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets a list of options for the service parameter; otherweise <strong>null</strong>.
		/// </summary>
		public List<Option> Options { get; internal set; }

		/// <summary>
		/// Gets the type of the parameter.
		/// </summary>
		public string Type { get; internal set; }
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
		/// <inheritdoc/>
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}