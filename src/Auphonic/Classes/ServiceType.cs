using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="ServiceType"/> class.
	/// </summary>
	public class ServiceType
	{
		#region Public Properties
		public string DisplayName { get; set; }

		public Dictionary<string, Parameter> Parameters { get; set; }
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
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}