using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a service type.
	/// </summary>
	public class ServiceType
	{
		#region Public Properties
		/// <summary>
		/// Gets the name of the service.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets a collection of key/value pairs that provide additional parameters supported by
		/// the service; otherwise <strong>null</strong>.
		/// </summary>
		public Dictionary<string, Parameter> Parameters { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceType"/> class.
		/// </summary>
		public ServiceType()
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